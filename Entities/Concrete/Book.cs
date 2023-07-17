using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book: BaseEntity
    {
        public int Id { get; set; }

        public string BookName { get; set; }
        public string PageCount { get; set; }
        public string Description { get; set; }

        public ICollection<BookAndCategory> BooksAndCategories { get; set; }
        public ICollection<BookAndAuthor> BooksAndAuthors { get; set; }
        public ICollection<BookAndPublisher> BooksAndPublishers { get; set; }
        public ICollection<BookImage> BookImages { get; set; }


    }
}
