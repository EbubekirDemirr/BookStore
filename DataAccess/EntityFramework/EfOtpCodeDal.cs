using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete.Authentication;

namespace DataAccess.EntityFramework;

public class EfOtpCodeDal : GenericRepository<UserOtpCode>, IOtpCodeDal
{
    public EfOtpCodeDal(LibraryContext libraryContext) : base(libraryContext)
    {
    }
}
