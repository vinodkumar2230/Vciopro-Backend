using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.ViewModels
{
 public class LocationsViewModel
    {
        public int LocationId { get; set; }
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public Nullable<bool> isPrimary { get; set; }
    }
}
