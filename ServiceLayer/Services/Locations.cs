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
  public class Locations:ILocations
    {
        private vCIOPRoEntities _ctx = new vCIOPRoEntities();

        private UnitOfWork unitOfWork { get; set; }

        public Locations(UnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;
        }
        public List<Location> GetAllLocations(int id)
        {
            // var locdata = unitOfWork.LocationRepository.Get().ToList();
            var query = (from result in _ctx.Locations
                         where result.OrganizationID == id
                         select result).ToList();
            return query;
        }
        public bool AddLocations(LocationsViewModel model)
        {
            vCIOPRoEntities context = new vCIOPRoEntities();
        bool flag = false;

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    Guid UniqueTenantId = System.Guid.NewGuid();

                Location LocDtl = new Location()
    {
                    OrganizationID=model.OrganizationID,
                    Name = model.Name,  
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    CountryID = model.CountryID,
                    StateID = model.StateID,
                    City = model.City,
                    Zip = model.Zip,
                    Phone=model.Phone,
                    isPrimary = model.isPrimary
    };
    unitOfWork.GetRepositoryInstance<Location>().Insert(LocDtl);
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
        public bool EditLocations(LocationsViewModel model)
        {
            var success = false;
            if (model != null)
            {
                using (var scope = new TransactionScope())
                {
                    var locationModel = unitOfWork.LocationRepository.GetByID(model.LocationId);
                    if (locationModel != null)
                    {
                        locationModel.LocationId = model.LocationId;
                        locationModel.Name = model.Name;
                        locationModel.Address1 = model.Address1;
                        locationModel.Address2 = model.Address2;
                        locationModel.StateID = model.StateID;
                        locationModel.CountryID = model.CountryID;
                        locationModel.City = model.City;
                        locationModel.Zip = model.Zip;
                        locationModel.Phone = model.Phone;
                        unitOfWork.LocationRepository.Update(locationModel);
                        unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        public bool DeleteLocations(int LocationId   )
        {
            var success = false;
            if (LocationId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var location = unitOfWork.LocationRepository.GetByID(LocationId);
                    if (location != null)
                    {
                        unitOfWork.LocationRepository.Delete(location);
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
