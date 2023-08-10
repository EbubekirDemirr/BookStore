using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class EfAuthorDal : GenericRepository<Author>, IAuthorDal
{
    public EfAuthorDal(LibraryContext libraryContext) : base(libraryContext)
    {
    }
}
