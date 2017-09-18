using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        //[Display(Name = "Email")]
       
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
  
        public string Password { get; set; }

        //[Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public int UserId { get; set; }
        public string SubDomain { get; set; }
    }
   


    public class APiRegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte UserType { get; set; }
        public string LastLoginIP { get; set; }
        public int UserID { get; set; }
        public string ProfilePic { get; set; }
        public string Password { get; set; }
        public byte Status { get; set; }
        public string CompanyLogo { get; set; }
        public string StripeCustId { get; set; }
        public string StripeChargeId { get; set; }
        public string StripeBalanceTransactionId { get; set; }
        // public string ConfirmPassword { get; set; }
        public string CompanyName { get; set; }
        public string SubDomain { get; set; }
        public int PlanId { get; set; }
        public string BillingEmail { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public string City { get; set; }
        public string Postalcode { get; set; }
        public string CardNo { get; set; }
        public string SecurityCode { get; set; }
        public string PromoCode { get; set; }
        public string ReferalCode { get; set; }
        public Nullable<byte> CardType { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public bool Active { get; set; }
      
    }
}

