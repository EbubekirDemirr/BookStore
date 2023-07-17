using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Author : BaseEntity
    {
        public int Id { get; set; }
        public string AuthorFirstName { get; set; } 
        public string AuthorLastName { get; set; }
        public string Biography { get; set; }

        public ICollection<BookAndAuthor> BooksAndAuthors { get; set; }

    }
}
