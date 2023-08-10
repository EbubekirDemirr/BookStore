using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.Models.Books;

public class GetBookDto: BaseEntity
{
    public int Id { get; set; }

    public string BookName { get; set; }
    public string PageCount { get; set; }
    public string Description { get; set; }
}
