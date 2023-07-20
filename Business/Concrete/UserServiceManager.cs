using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Business.Concrete;

public class UserServiceManager : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole> _roleManager;
    public UserServiceManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _configuration = configuration;
        _roleManager = roleManager;

    }

    public async Task<IDataResult<LoginUser>> Login(LoginUser loginUser)
    {
        var result = await _userManager.FindByNameAsync(loginUser.UserName);
        if (result != null && await _userManager.CheckPasswordAsync(result, loginUser.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(result);

            var authClaims = new List<Claim>
            {
                    new Claim(ClaimTypes.Name, loginUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            return new SuccessDataResult<LoginUser>(Messages.UserSuccesLogin);
        }
        return new ErrorDataResult<LoginUser>(Messages.PasswordError);
    }

    public async Task<IDataResult<RegisterUser>> Register(RegisterUser registerUser, string password)
    {
        var mappedAppUser = _mapper.Map<AppUser>(registerUser);

        registerUser.Password = password;
        var passwordHasher = new PasswordHasher<AppUser>();
        mappedAppUser.PasswordHash = passwordHasher.HashPassword(mappedAppUser, registerUser.Password);

        var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
        if (userExist!= null)
        {
            return new ErrorDataResult<RegisterUser>(Messages.UserAlreadyExist);
        }
        var result = await _userManager.CreateAsync(mappedAppUser, registerUser.Password);
        if (result != null)
        {
            return new ErrorDataResult<RegisterUser>(Messages.UserFailedToCreate);
        }
        return new SuccessDataResult<RegisterUser>(Messages.UserCreated);

    }

    public async Task<IDataResult<RegisterUser>> RegisterAdmin(RegisterUser registerUser, string password)
    {
        var userExists = await _userManager.FindByNameAsync(registerUser.UserName);
        if (userExists != null)
        {
            return new ErrorDataResult<RegisterUser>(Messages.UserAlreadyExist);
        }

        var mappedAppUser = _mapper.Map<AppUser>(registerUser);
        registerUser.Password = password;
        var passwordHasher = new PasswordHasher<AppUser>();
        mappedAppUser.PasswordHash = passwordHasher.HashPassword(mappedAppUser, registerUser.Password);

        var result = await _userManager.CreateAsync(mappedAppUser, registerUser.Password);
        if (!result.Succeeded)
        {
            return new ErrorDataResult<RegisterUser>(Messages.UserFailedToCreate);
        }         
        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _userManager.AddToRoleAsync(mappedAppUser, UserRoles.Admin);
        }
        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _userManager.AddToRoleAsync(mappedAppUser, UserRoles.User);
        }
        return new SuccessDataResult<RegisterUser>(Messages.UserCreated);
    }
}
