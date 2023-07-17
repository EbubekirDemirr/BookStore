using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework;

public class EfPublisherDal : GenericRepository<Publisher>, IPublisherDal
{
    public EfPublisherDal(LibraryContext libraryContext) : base(libraryContext)
    {
    }
}
