using Entities.Concrete.Models.BookImages;

namespace Entities.Concrete.Models.Books;

public class BookNavigateDto
{
    public string Id { get; set; }
    public string BookName { get; set; }
    public string PageCount { get; set; }
    public string Description { get; set; }

    public IEnumerable<BookImageNavigateDto> BookImages { get; set; }
}
