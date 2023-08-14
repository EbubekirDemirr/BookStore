namespace Entities.Concrete.Models.Books;

public class CreateBookImageDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
    public int BookId { get; set; }
}
