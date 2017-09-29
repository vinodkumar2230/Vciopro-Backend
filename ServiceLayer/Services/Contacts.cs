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
   public class Contacts:IContacts
    {
        private UnitOfWork unitOfWork { get; set; }

        public Contacts(UnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;
        }
        public List<Contact> GetAllContacts()
        {
            var contactdata = unitOfWork.ContactRepository.Get().ToList();
            return contactdata;
        }
        public bool AddContacts(ContactViewModel model)
        {
            vCIOPRoEntities context = new vCIOPRoEntities();
            bool flag = false;

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    Guid UniqueTenantId = System.Guid.NewGuid();

                    Contact ContactDtl = new Contact()
                    {
                        OrganizationID = model.OrganizationID,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        LocationID = model.LocationID,
                        IsImportantContact = model.IsImportantContact,
                        Title = model.Title,
                        TypeID = model.TypeID,
                    };
                    unitOfWork.GetRepositoryInstance<Contact>().Insert(ContactDtl);
                    unitOfWork.Save();
                    ContactEmail ContactDt2 = new ContactEmail()
                    {
                        ContactId= ContactDtl.ContactId,
                        EmailTypeId=model.EmailTypeId,
                        Email=model.Email,
                        isPrimaryEmail=model.isPrimaryEmail
                    };
                    unitOfWork.GetRepositoryInstance<ContactEmail>().Insert(ContactDt2);
                    unitOfWork.Save();
                    ContactPhone ContactDt3 = new ContactPhone()
                    {
                      ContactId = ContactDtl.ContactId,
                      PhoneTypeId =model.PhoneTypeId,
                      Phone=model.Phone,
                      Ext=model.Ext,
                      isPrimaryPhone=model.isPrimaryPhone
                    };
                    unitOfWork.GetRepositoryInstance<ContactPhone>().Insert(ContactDt3);
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
        public bool EditContacts(ContactViewModel model)
        {
            var success = false;
            if (model != null)
            {
                using (var scope = new TransactionScope())
                {
                    var contactModel = unitOfWork.ContactRepository.GetByID(model.ContactId);
                    if (contactModel != null)
                    {
                        contactModel.FirstName = model.FirstName;
                        contactModel.LastName = model.LastName;
                        contactModel.LocationID = model.LocationID;
                        contactModel.IsImportantContact = model.IsImportantContact;
                        contactModel.Title = model.Title;
                        contactModel.TypeID = model.TypeID;
                        unitOfWork.ContactRepository.Update(contactModel);
                    }

                        var contact1Model = unitOfWork.Contact1Repository.GetByID(model.ContactId);
                    if (contact1Model != null)
                    {
                        contact1Model.EmailTypeId = model.EmailTypeId;
                        contact1Model.Email = model.Email;
                        contact1Model.isPrimaryEmail = model.isPrimaryEmail;
                        unitOfWork.Contact1Repository.Update(contact1Model);
                    }
                    var contact2Model = unitOfWork.Contact2Repository.GetByID(model.ContactId);
                    if (contact2Model != null)
                    {
                        contact2Model.PhoneTypeId = model.PhoneTypeId;
                            contact2Model.Phone = model.Phone;
                        contact2Model.Ext = model.Ext;
                        contact2Model.isPrimaryPhone = model.isPrimaryPhone;
                        unitOfWork.Contact2Repository.Update(contact2Model);
                    }
                            unitOfWork.Save();
                            scope.Complete();
                            success = true;
                        
                }      
            }
            return success;
        }
        public bool DeleteContacts(int ContactId)
        {
            var success = false;
            if (ContactId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var contact = unitOfWork.ContactRepository.GetByID(ContactId);
                    if (contact != null)
                    {
                        unitOfWork.ContactRepository.Delete(contact);
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
