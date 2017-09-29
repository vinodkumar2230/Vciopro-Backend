using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.ViewModels
{
     public class ContactViewModel
    {
        public int OrganizationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string IsImportantContact { get; set; }
        public Nullable<int> ContactId { get; set; }
        public int EmailTypeId { get; set; }
        public string Email { get; set; }
        public Nullable<bool> isPrimaryPhone { get; set; }
        public int PhoneTypeId { get; set; }
        public string Phone { get; set; }
        public string Ext { get; set; }
         public Nullable<bool> isPrimaryEmail { get; set; }
    }
}
