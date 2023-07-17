using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework;

public class EfAuthorDal : GenericRepository<Author>, IAuthorDal
{
    public EfAuthorDal(LibraryContext libraryContext) : base(libraryContext)
    {
    }
}
