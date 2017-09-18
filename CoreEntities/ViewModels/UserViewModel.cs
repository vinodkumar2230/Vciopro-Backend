using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.ViewModels
{
    //public class UserViewModel
    //{
    //    public int UserId { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string Phone { get; set; }
    //    public string DOB { get; set; }
    //    public string Country { get; set; }
    //    public string State { get; set; }
    //    public string City { get; set; }
    //    public string ImageUrl { get; set; }
    //    public Nullable<bool> MaritalStatus { get; set; }
    //}

    public class UsersViewModel
    {
        public int ID { get; set; }
        public Guid TanentID { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? OrganizationId { get; set; }
        public string Password { get; set; }
        public int CreatedBy { get; set; }
        public string OrganizationName { get; set; }
        public int UsersPerOrg { get; set; }

        public byte UserType { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIP { get; set; }
        public bool IsDeleted { get; set; }
        public int UserID { get; set; }


        public int RoleID { get; set; }
    }

    public class UsersBillingInfoViewModel
    {


        public int ID { get; set; }
        public Guid TenantId { get; set; }
        public string BillingEmail { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    
    
    }

    public class UsersProfileInfoViewModel
    {

        public int ID { get; set; }
        public Guid TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePic { get; set; }

    }

    public class CompanyProfileViewModel
    {
        public int ID { get; set; }
        public string CompanyLogo { get; set; }
    
    }

    public class RecieverListViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
    
    }

    public class AddRoleViewModel
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public Guid? TenantId { get; set; }

        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
    }
   

    public class PermissionModelClass
    {
        public int ID { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool List { get; set; }
        public bool ImportData { get; set; }
        public string Module { get; set; }
        
    }  
    public class AddPErmissionViewModel
    {
        public List<PermissionModelClass> PermissionList { get; set; }
        
    }

    public class PermissionViewModel
    {
        public int ID { get; set; }
        public string Module { get; set; }
        public int ModuleId { get; set; }
        public bool? Add { get; set; }
        public bool? Edit { get; set; }
        public bool? Delete { get; set; }
        public bool? List { get; set; }
        public bool? ImportData { get; set; }
        public object abc { get; set; }
        
    }
}
