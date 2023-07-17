using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookAndAuthor : BaseEntity
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Books { get; set; }

        public int AuthorId { get; set; }
        public Author Authors { get; set; }
    }
}
