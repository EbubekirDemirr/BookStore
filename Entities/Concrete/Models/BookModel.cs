using Entities.Concrete.Models.BookImages;

namespace Entities.Concrete.Models;

public class BookModel
{
    public int BookId { get; set; }
    public string BookName { get; set; }
    public string PageCount { get; set; }
    public string Description { get; set; }
    public ICollection<BookImageNavigateDto> BookImages { get; set; }
}
