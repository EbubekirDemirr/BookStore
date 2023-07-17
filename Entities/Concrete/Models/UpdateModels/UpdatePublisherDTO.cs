using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Models.UpdateModels;

public class UpdatePublisherDTO
{
    public int Id { get; set; }
    public string PublisherName { get; set; }
    public string PhoneNumber { get; set; }
}
