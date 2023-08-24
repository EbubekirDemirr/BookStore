namespace Entities.Concrete.Models.Authors;

public class CreateAuthorImageDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
    public int AuthorId { get; set; }
}
