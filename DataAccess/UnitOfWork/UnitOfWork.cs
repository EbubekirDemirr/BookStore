using DataAccess.Concrete;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWorkDal
{
    private readonly LibraryContext _libraryContext;

    public UnitOfWork(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }

    public void Save()
    {
        _libraryContext.SaveChanges();
    }

    public async Task SaveAsync( )
    {
      await _libraryContext.SaveChangesAsync();
    }
}
