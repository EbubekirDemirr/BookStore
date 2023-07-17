namespace Entities.Concrete.Models.UpdateModels;

public class UpdateBookDTO
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public string PageCount { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
