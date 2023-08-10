using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework;

public class EfBookAndCategoryDal : GenericRepository<BookAndCategory>, IBookAndCategoryDal
{
    public EfBookAndCategoryDal(LibraryContext libraryContext) : base(libraryContext)
    {
    }
}
