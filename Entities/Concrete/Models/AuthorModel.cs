using Entities.Concrete.Models.Authors;
using Entities.Concrete.Models.BookImages;

namespace Entities.Concrete.Models;

public class AuthorModel
{
    public int AuthorId { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
    public string Biography { get; set; }
    public ICollection<AuthorImageNavigateDto> AuthorImages { get; set; }
}
