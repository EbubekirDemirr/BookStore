using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework;

public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
{
    public EfCategoryDal(LibraryContext libraryContext) : base(libraryContext)
    {
    }
}
