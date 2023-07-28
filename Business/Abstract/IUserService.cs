using Core.Utilities.Results;
using Entities.Concrete.Authentication;

namespace Business.Abstract;

public interface IUserService
{
    Task<IDataResult<RegisterUser>> Register(RegisterUser registerUser, string password);
    Task<IDataResult<LoginUser>> Login(LoginUser loginUser);
    Task<IDataResult<RegisterUser>> RegisterAdmin(RegisterUser registerUser, string password);
    Task<IResult> VerifyUserEmail(string userId, int otpCode  );


}