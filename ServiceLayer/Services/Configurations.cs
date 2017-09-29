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
    public class Configurations:IConfiguration
    {

        private UnitOfWork unitOfWork { get; set; }

        public Configurations(UnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;
        }
        public List<Configuration> GetAllConfigurations()
        {
            var locdata = unitOfWork.ConfigRepository.Get().ToList();

            return locdata;
        }
        public bool AddConfigurations(ConfigurationViewModel model)
        {
            vCIOPRoEntities context = new vCIOPRoEntities();
            bool flag = false;

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    Guid UniqueTenantId = System.Guid.NewGuid();

                    Configuration ConfigDtl = new Configuration()
                    {
                        Name=model.Name,
                        Typeid=model.Typeid,
                        StatusId=model.StatusId,
                        SerialNo=model.SerialNo,
                        OrganizationId=model.OrganizationId,
                        ExpirationDate=model.ExpirationDate,
                        Notes = model.Notes,
                        PurchaseDate = model.PurchaseDate,
                        PurchasedBy = model.PurchasedBy,
                        AssetTag = model.AssetTag,
                        ManufacturerId = model.ManufacturerId,
                        Model = model.Model,
                        LocationId = model.LocationId,
                        ContactId = model.ContactId,
                        InstallDate = model.InstallDate,
                        InstalledBy = model.InstalledBy,
                        PhysicalPosition = model.PhysicalPosition,
                        Hostname = model.Hostname,
                        PrimaryIP = model.PrimaryIP,
                        MacAddress = model.MacAddress,
                        DefaultGateway = model.DefaultGateway,
                        PlatformId = model.PlatformId,
                        OperatingSystemId = model.OperatingSystemId,
                        OperatingSystemNotes = model.OperatingSystemNotes,
                        DataSourceType = model.DataSourceType
                    };
                    unitOfWork.GetRepositoryInstance<Configuration>().Insert(ConfigDtl);
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
        public bool EditConfigurations(ConfigurationViewModel model)
        {
            var success = false;
            if (model != null)
            {
                using (var scope = new TransactionScope())
                {
                    var configModel = unitOfWork.ConfigRepository.GetByID(model.ID);
                    if (configModel != null)
                    {
                        configModel.Name = model.Name;
                        unitOfWork.ConfigRepository.Update(configModel);
                        unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        public bool DeleteConfigurations(int ID)
        {
            var success = false;
            if (ID > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var config = unitOfWork.ConfigRepository.GetByID(ID);
                    if (config != null)
                    {
                        unitOfWork.ConfigRepository.Delete(config);
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

