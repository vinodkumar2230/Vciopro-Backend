using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using CoreEntities.Domain;
using CoreEntities.ViewModels;
using System.Web;
using RepositoryLayer;
using System.Transactions;
using ServiceLayer.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Net.Mail;

namespace ServiceLayer
{
    public class Registration : IRegistration
    {
        private UnitOfWork unitOfWork { get; set; }

        public Registration(UnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;
        }
        public bool LoginUser(LoginViewModel model)
        {
            vCIOPRoEntities db = new vCIOPRoEntities();
            var user = db.Users.SingleOrDefault(x => x.UserName == model.Email && x.Password == model.Password);
            if (user != null) { return true; }
            else
                return false;   
        }

        public bool AddUser(APiRegisterViewModel model)
        {
            vCIOPRoEntities context = new vCIOPRoEntities();
            bool flag = false;

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    Guid UniqueTenantId = System.Guid.NewGuid();
                    User TntDtl = new User()
                    {
                        TenantId = UniqueTenantId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Password = model.Password,
                        UserName = model.Email,
                        UserType = 1,
                        LastLoginIP = "wqee",
                        UserID = 12,
                        ProfilePic = "rewr"
                    };
                    unitOfWork.GetRepositoryInstance<User>().Insert(TntDtl);
                    unitOfWork.Save();
                    Tenant TntDt2 = new Tenant()
                    {

                        TenantId = UniqueTenantId,
                        PlanId = 1,
                        CompanyName = model.CompanyName,
                        SubDomain = "dfsf",
                        EmailId = model.Email,
                        Status = 1,
                        CompanyLogo = "dfgd",
                        StripeCustId = "hgfhy",
                        StripeChargeId = "gftyh",
                        StripeBalanceTransactionId = "hdtrt"
                    };
                    unitOfWork.GetRepositoryInstance<Tenant>().Insert(TntDt2);
                    unitOfWork.Save();
                
                    TenantBillingInfo TntDt3 = new TenantBillingInfo()
                    {
                        // BillingId=model.BillingId,
                        TenantId = UniqueTenantId,
                        BillingEmail = model.BillingEmail,
                        Phone = model.Phonenumber,
                        Address1 = model.Address,
                        Address2 = model.Address2,
                        CountryId =model.CountryId,
                        StateId =model.StateId,
                        City = model.City,
                        ZipCode = model.Postalcode
                    };
                    unitOfWork.GetRepositoryInstance<TenantBillingInfo>().Insert(TntDt3);
                    unitOfWork.Save();

                    TenantCardInfo TntDt4 = new TenantCardInfo()
                    {
                        // CreditId=model.CreditId,
                        TenantId = UniqueTenantId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        CardNo = model.CardNo,
                        SecurityCode = model.SecurityCode,
                        ExpiryDate = model.ExpiryDate,
                        CardType = 1,
                        Active = true
                    };
                    unitOfWork.GetRepositoryInstance<TenantCardInfo>().Insert(TntDt4);

                    unitOfWork.Save();
                    dbContextTransaction.Commit();
                    flag = true;
                    var toEmailIds1 = model.Email;
                    string mailBody1 = "Greetings of The Day<br/> Congratulations you have been successfully registered with vCIOPRo.";
                    Attachment attachedfile = null;
                    ServiceLayer.EmailHelper.EmailHelper.SendEmail(toEmailIds1, mailBody1, "Registration Successful", attachedfile, true);
                }

                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
            return true;
        } 
   
    }
}
