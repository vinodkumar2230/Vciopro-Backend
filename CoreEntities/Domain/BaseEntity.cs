using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Domain
{
    class BaseEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
