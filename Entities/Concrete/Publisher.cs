using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Publisher : BaseEntity
    {
        public int Id { get; set; }
        public string PublisherName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<BookAndPublisher> BooksAndPublishers { get; set; }
    }
}
