using Entities.Concrete.BaseEntities;

namespace Entities.Concrete;

public class AuthorImage: BaseEntity
{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
