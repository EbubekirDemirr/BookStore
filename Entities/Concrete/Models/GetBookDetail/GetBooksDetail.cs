using Entities.Concrete.Models.Authors;
using Entities.Concrete.Models.Books;
using Entities.Concrete.Models.Category;

namespace Entities.Concrete.Models.BookAndAuthor;

public class GetBooksDetail
{
    public int Id { get; set; }
    public BookNavigateDto Books { get; set; }
    public AuthorNavigateDto Authors { get; set; }
    public CategoryNavigateDto Categories { get; set; }
}
