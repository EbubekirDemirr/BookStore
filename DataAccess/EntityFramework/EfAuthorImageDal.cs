using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework;

public class EfAuthorImageDal : GenericRepository<AuthorImage>, IAuthorImageDal
{
    public EfAuthorImageDal(LibraryContext libraryContext) : base(libraryContext)
    {
    }
}
