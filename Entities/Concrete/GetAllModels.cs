using Entities.Concrete.BaseEntities;

namespace Entities.Concrete;

public class GetAllModels: BaseEntity
{
    public ICollection<BookAndCategory> BooksAndCategories { get; set; }
    public ICollection<BookAndAuthor> BooksAndAuthors { get; set; }
    public ICollection<BookAndPublisher> BooksAndPublishers { get; set; }
    public Author Authors { get; set; }
    public Book Books { get; set; }
    public Category Categories { get; set; }
}
