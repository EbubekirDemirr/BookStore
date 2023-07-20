using Entities.Concrete;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class LibraryContext : IdentityDbContext<AppUser>
{
    public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
    {
        
    }
    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    SeedRoles(builder);
    //}
    //private void SeedRoles(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<IdentityRole>().HasData
    //     (
    //        new IdentityRole("Admin"),
    //        new IdentityRole("User")
    //     );
    //}
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAndAuthor> BookAndAuthors { get; set; }
    public DbSet<BookAndCategory> BookAndCategories { get; set; }
    public DbSet<BookAndPublisher> BookAndPublishers { get; set; }
    public DbSet<BookImage> BookImages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    
}
