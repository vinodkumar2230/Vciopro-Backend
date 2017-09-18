using CoreEntities.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeUser.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string UserName { get; set; }
    }

    //public class LoginViewModel
    //{
    //    [Required]
    //    [Display(Name = "Email")]
    //    [EmailAddress]
    //    public string Email { get; set; }

    //    [Required]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string Password { get; set; }

    //    [Display(Name = "Remember me?")]
    //    public bool RememberMe { get; set; }
    //}

    //public class RegisterViewModel
    //{
    //    [Required]
    //    [EmailAddress]
    //    [Display(Name = "Email")]
    //    public string Email { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string Password { get; set; }

    //    [DataType(DataType.Password)]
    //    [Display(Name = "Confirm password")]
    //    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    //    public string ConfirmPassword { get; set; }


    //     public UserViewModel AccObj { get; set; }
    //    //Tanant Table Properties
    //    // public int TenantPrmId { get; set; }
    //    //public int TenantId { get; set; }
    //    //public string CompanyName { get; set; }
    //    //public string SubDomain { get; set; }
    //    //public int PlanId { get; set; }
    //    //public string CreatedDate { get; set; }
    //    //public byte Status { get; set; }
    //    //public int TenantModifiedBy { get; set; }
    //    //public string TenantModifiedDate { get; set; }

    //    ////Tenant TenantBillingInfo
    //    //public int TenantBillingInfoID { get; set; }
    //    //public int TenantBillingInfoTenantId { get; set; }
    //    //public string BillingEmail { get; set; }
    //    //public string Phone { get; set; }
    //    //public string Address1 { get; set; }
    //    //public string Address2 { get; set; }
    //    //public int CountryId { get; set; }
    //    //public int StateId { get; set; }
    //    //public string City { get; set; }
    //    //public string ZipCode { get; set; }
    //    //public int CreatedBy { get; set; }
    //    //public string TenantBillingInfoCreatedDate { get; set; }
    //    //public int TenantBillingInfoModifiedBy { get; set; }
    //    //public string TenantBillingInfoModifiedDate { get; set; }

    //    //public int TenantCardInfoID { get; set; }
    //    //public int TenantCardInfoTenantId { get; set; }
    //    //public string FirstName { get; set; }
    //    //public string LastName { get; set; }
    //    //public string CardNo { get; set; }
    //    //public string SecurityCode { get; set; }
    //    //public string ExpiryDate { get; set; }
    //    //public byte CardType { get; set; }
    //    //public bool Active { get; set; }
    //    //public int UsersID { get; set; }

    //    ////Users Table
    //    //public int UsersTenantId { get; set; }
    //    //public int OrganizationId{ get; set; }
    //    //public string UsersFirstName { get; set; }
    //    //public string UsersLastName { get; set; }
    //    //public string UsersUserName { get; set; }
    //    ////public string Password { get; set; }
    //    //public int UsersCreatedBy { get; set; }
    //    //public string UsersCreatedDate { get; set; }
    //    //public byte UsersType { get; set; }
    //    //public int UserModifiedBy { get; set; }
    //    //public string UsersModifiedDate { get; set; }
    //    //public string LastLoginDate { get; set; }
    //    //public string LastLoginIP { get; set; }
    //    //public bool IsDeleted { get; set; }
    //}

    public class ResetPasswordViewModel
    {

        
        [Display(Name = "Email")]
        public string Email { get; set; }

       
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
    }


    public class ForgetPassword
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
        public string UserName { get; set; }
        public string DateTime { get; set; }

    
    }

    public class ForgotPasswordViewModel
    {
    
        public string UserName { get; set; }
    }
}
