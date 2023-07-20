using Business.Abstract.CrudInterfaces;
using Core.Utilities.Results;
using Entities.Concrete.Authentication;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Microsoft.AspNet.Identity;

namespace Business.Abstract;

public interface IUserService
{
    Task<IDataResult<RegisterUser>> Register(RegisterUser registerUser, string password);
    Task<IDataResult<LoginUser>> Login(LoginUser loginUser);
    Task<IDataResult<RegisterUser>> RegisterAdmin(RegisterUser registerUser, string password);

}