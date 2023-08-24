using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly UserManager<AppUser> _userManager;
    public UsersController(IUserService userService, IConfiguration configuration, UserManager<AppUser> userManager)
    {
        _userService = userService;
        _configuration = configuration;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUser loginUser)
    {
        var userToLogin = await _userService.Login(loginUser);
        if (!userToLogin.Success)
        {
            return BadRequest(userToLogin.Message);
        }

        var authClaims = new List<Claim>
{
    new Claim(ClaimTypes.Name, loginUser.UserName),
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
};
        var token = GetToken(authClaims);

        var responseData = new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo,
            message = userToLogin.Message,
        };

        return Ok(new { data = responseData });

    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
    {
        var result = await _userService.Register(registerUser, registerUser.Password );
        if (result.Success)
        {
            return Ok(result.Message);
        } 
        return BadRequest(result.Message);
    }
    //[HttpGet("verify-userEmail")]
    //public async Task<IActionResult> VerifyUserEmail(string userId, int otpCode)
    //{
    //    var result = await _userService.VerifyUserEmail(userId, otpCode);
    //    if (result.Success)
    //    {
    //        return Ok(result.Message);
    //    }
    //    return BadRequest(result.Message);
    //}

    [HttpPost("registerAdmin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUser registerUser)
    {
        var result = await _userService.RegisterAdmin(registerUser, registerUser.Password);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result.Message);
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}
