using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfBookDal : GenericRepository<Book>, IBookDal
    {
        public EfBookDal(LibraryContext libraryContext) : base(libraryContext)
        {
        }
    }
}
