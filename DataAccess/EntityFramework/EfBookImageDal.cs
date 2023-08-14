using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework;

public class EfBookImageDal : GenericRepository<BookImage>, IBookImageDal
{
    public EfBookImageDal(LibraryContext libraryContext) : base(libraryContext)
    {
    }
}
