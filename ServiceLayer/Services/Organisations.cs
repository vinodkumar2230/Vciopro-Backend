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
    public class Organisations : IOrganisations
    {

        private UnitOfWork unitOfWork { get; set; }

        public Organisations(UnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;
        }
        public List<Organisation> GetAllOrganisations()
        {
            var orgdata = unitOfWork.OrganisationRepository.Get().ToList();

            return orgdata;
        }
        public Organisation GetOrgById(int id)
        {
            var data = unitOfWork.OrganisationRepository.GetByID(id);
            return data;
        }
        //public List<Organisation> GetAllOrganisations(OrganisationsViewModel model)
        //{
        //    var data = unitOfWork.OrganisationRepository.Get().ToList();

        //    return data;
        //}

        //public List<Organisation> GetAllOrganisationbyID(int OrganisationId,OrganisationsViewModel model)
        //{
        //     var data = unitOfWork.OrganisationRepository.GetByID(model.OrganisationId);

        //    return data;
        //}
        public bool AddOrg(OrganisationsViewModel model)
        {
            vCIOPRoEntities context = new vCIOPRoEntities();
            bool flag = false;

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    Guid UniqueTenantId = System.Guid.NewGuid();

                    Organisation TntDtl = new Organisation()
                    {
                        OrgName = model.OrgName,
                        ShortName = model.ShortName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Description = model.Description,
                        Email = model.Email,
                        Phone = model.Phone,
                        ImagePath="fghuir",
                        AlertMessage="fjg"
                    };
                    unitOfWork.GetRepositoryInstance<Organisation>().Insert(TntDtl);
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

        public bool EditOrg(OrganisationsViewModel model)
        {
            var success = false;
            if (model != null)
            {
                using (var scope = new TransactionScope())
                {
                    var organisationModel = unitOfWork.OrganisationRepository.GetByID(model.OrganisationId);
                    if (organisationModel != null)
                    {
                        organisationModel.OrgName = model.OrgName;
                        unitOfWork.OrganisationRepository.Update(organisationModel);
                        unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        public bool DeleteOrg(int OrganisationId)
        {
            var success = false;
            if (OrganisationId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var organisation = unitOfWork.OrganisationRepository.GetByID(OrganisationId);
                    if (organisation != null)
                    {
                        unitOfWork.OrganisationRepository.Delete(organisation);
                        unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}


