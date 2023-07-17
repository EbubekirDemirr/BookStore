using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Concrete;

public class UserServiceManager : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    public UserServiceManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _config = configuration;

    }

    public async Task<IDataResult<LoginUser>> Login(LoginUser loginUser)
    {
        var result = await _userManager.FindByNameAsync(loginUser.UserName);
        if (result!=null && await _userManager.CheckPasswordAsync(result, loginUser.Password))
        {
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
        if (userExist != null)
        {
            return new ErrorDataResult<RegisterUser>(Messages.UserAlreadyExist);
        }

        await _userManager.CreateAsync(mappedAppUser);
        return new SuccessDataResult<RegisterUser>(registerUser, Messages.UserRegistered);


    }


}
