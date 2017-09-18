using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.ViewModels
{
    public class UserDetailsViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<bool> MaritalStatus { get; set; }
        public int UserType { get; set; }

        public int ID { get; set; }
        public Guid TenantId { get; set; }
        public string CompanyName { get; set; }
        public string SubDomain { get; set; }
        public int PlanId { get; set; }
        public string EmailId { get; set; }
        public int? Organizations { get; set; }
        public int? UserPerOrg { get; set; }
        public int? OrganizationId { get; set; }
        public string LogoImage { get; set; }
        public string OrganizationName { get; set; }
        public string CompanyLogo { get; set; }
        public string ProfilePic { get; set; }
        public bool? IsActive { get; set; }
        public bool? AllowWhiteLabeling { get; set; }

        public bool? IsTrial { get; set; }
        public int? RoleID { get; set; } 
        public bool? AllowSupport { get; set; }

        public string StripeCustomerId { get; set; }
        public Decimal? AmountPaid { get; set; }
        public Decimal? BasePrice { get; set; }
        public Decimal? Tax { get; set; }
        public bool? AllowBasecamp { get; set; }
        public bool? AllowChatSupport { get; set; }
    }
}
