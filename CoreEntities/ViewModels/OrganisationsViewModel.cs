using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.ViewModels
{
    public class OrganisationsViewModel
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string ShortName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public int OrgTypeId { get; set; }
        //public string TypeName { get; set; }
        //public int OrgStatusId { get; set; }
        //public string StatusName { get; set; }
    }
}
