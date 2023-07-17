
using Entities.Concrete;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataAccess.Concrete;

public class LibraryContext : IdentityDbContext<AppUser>
{
    public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
    {
        
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAndAuthor> BookAndAuthors { get; set; }
    public DbSet<BookAndCategory> BookAndCategories { get; set; }
    public DbSet<BookAndPublisher> BookAndPublishers { get; set; }
    public DbSet<BookImage> BookImages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    
}
