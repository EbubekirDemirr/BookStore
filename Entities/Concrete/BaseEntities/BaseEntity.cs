using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.BaseEntities
{
     public abstract class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }  
        public bool IsDeleted { get; set; }
    }
}
