using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.ViewModels
{
    public class PasswordViewModel
    {
        public int ID { get; set; }
        public int OrganizationId { get; set; }
        public string Description { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string UserName { get; set; }
        public string Password1 { get; set; }
        public string URL { get; set; }
        public string Notes { get; set; }
    }
}
