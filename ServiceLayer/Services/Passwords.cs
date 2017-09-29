using CoreEntities.ViewModels;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServiceLayer.Services
{
    public class Passwords : IPassword
    {
        private UnitOfWork unitOfWork { get; set; }

        public Passwords(UnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;
        }

        public List<Password> GetAllPwd()
        {
            var data1 = unitOfWork.PasswordRepository.Get().ToList();
            return data1;
        }

        #region "Create"
        public bool AddPwd(PasswordViewModel model)
        {
            vCIOPRoEntities context = new vCIOPRoEntities();
            bool flag = false;

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    Guid UniqueTenantId = System.Guid.NewGuid();

                    Password PwdDtl = new Password()
                    {
                        OrganizationId = model.OrganizationId,
                        Description = model.Description,
                        CategoryId = model.CategoryId,
                        UserName = model.UserName,
                        Password1 = model.Password1,
                        URL = model.URL,
                        Notes = model.Notes,
                    };
                    unitOfWork.GetRepositoryInstance<Password>().Insert(PwdDtl);
                    unitOfWork.Save();
                    dbContextTransaction.Commit();
                    flag = true;
                }

                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
            return true;
        }
        #endregion

        #region "Update"
        public bool EditPwd(PasswordViewModel model)
        {
            var success = false;
            if (model != null)
            {
                using (var scope = new TransactionScope())
                {
                    var passwordModel = unitOfWork.PasswordRepository.GetByID(model.ID);
                    if (passwordModel != null)
                    {
                        passwordModel.ID = model.ID;
                        passwordModel.OrganizationId = model.OrganizationId;
                        passwordModel.Description = model.Description;
                        passwordModel.CategoryId = model.CategoryId;
                        passwordModel.UserName = model.UserName;
                        passwordModel.Password1 = model.Password1;
                        passwordModel.URL = model.URL;
                        passwordModel.Notes = model.Notes;

                        unitOfWork.PasswordRepository.Update(passwordModel);
                        unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        #endregion

        #region "Delete"
        public bool DeletePwd(int ID)
        {
            var success = false;
            if (ID > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var password = unitOfWork.PasswordRepository.GetByID(ID);
                    if (password != null)
                    {
                        unitOfWork.PasswordRepository.Delete(password);
                        unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        #endregion

    }
}
