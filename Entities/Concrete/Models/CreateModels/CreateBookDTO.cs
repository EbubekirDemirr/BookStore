using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.Models.CreateModels;

public class CreateBookDTO
{
    public string BookName { get; set; }
    public string PageCount { get; set; }
    public string Description { get; set; }
}
