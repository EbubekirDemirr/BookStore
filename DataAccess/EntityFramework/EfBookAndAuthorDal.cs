using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework;

public class EfBookAndAuthorDal : GenericRepository<BookAndAuthor>, IBookAndAuthorDal
{


    public EfBookAndAuthorDal(LibraryContext libraryContext) : base(libraryContext)
    {

    }

    
}
