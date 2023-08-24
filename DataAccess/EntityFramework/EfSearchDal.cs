using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class EfSearchDal : ISearchDal
{

    //public IQueryable GetSearchedData()
    //{
    //    using (LibraryContext context= new LibraryContext(new DbContextOptions<LibraryContext>()))
    //    {
    //        context.Books.Include(b=>b.BooksAndAuthors).ThenInclude(b =>b.Authors).Include(b => b.BooksAndCategories).ThenInclude(b=>b.Categories).ToList();


    //    }
    //}
    public IQueryable GetSearchedData()
    {
        throw new NotImplementedException();
    }
}
