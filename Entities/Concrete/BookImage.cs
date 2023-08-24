using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookImage : BaseEntity
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
