using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Core.EmailSender;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Business.Concrete;

public class UserServiceManager : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IOtpCodeDal _otpCodeDal;
    private readonly EmailService _emailService;
    private readonly IUnitOfWorkDal _unitOfWorkDal;

    public UserServiceManager(UserManager<AppUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager, IOtpCodeDal otpCodeDal, EmailService emailService, IUnitOfWorkDal unitOfWorkDal)
    {
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _otpCodeDal = otpCodeDal;
        _emailService = emailService;
        _unitOfWorkDal= unitOfWorkDal;
    }

    public async Task<IDataResult<LoginUser>> Login(LoginUser loginUser)
    {
        var result = await _userManager.FindByNameAsync(loginUser.UserName);
        if (result != null && await _userManager.CheckPasswordAsync(result, loginUser.Password))
        {
            if (!result.EmailConfirmed) return new ErrorDataResult<LoginUser>("lütfen kullanıcı doğrula");
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

    public async Task<IDataResult<RegisterUser>> Register(RegisterUser registerUser, string password )
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

        var result = await _userManager.CreateAsync(mappedAppUser, registerUser.Password);     
        if (!result.Succeeded)
        {
            return new ErrorDataResult<RegisterUser>(Messages.UserFailedToCreate);                    
        }
        int otpCode = GenerateOTP();
        _otpCodeDal.Insert(new UserOtpCode
        {
            UserId=mappedAppUser.Id,
            OtpCode=otpCode,          
        });
        _emailService.SendEmail(registerUser.Email, otpCode, mappedAppUser.Id);
        _unitOfWorkDal.Save();
        return new SuccessDataResult<RegisterUser>(Messages.Created);

    }

    private int GenerateOTP()
    {
        Random random = new Random();
        int otpCode = random.Next(100000, 999999);
        return otpCode;
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

    public async Task<IResult> VerifyUserEmail(string userId, int otpCode)
    {
        var data = _otpCodeDal.Get(q=> q.UserId==userId);
        if (data == null)
        {
            return new ErrorResult(Messages.Error);
        }
        if (data.UserId == userId && data.OtpCode == otpCode)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.EmailConfirmed = true;
            user.TwoFactorEnabled = true;

            await _userManager.UpdateAsync(user);
            return new SuccessResult("Kullanıcı doğrulandı");
        }
        return new ErrorResult(Messages.Error);

    }
}
