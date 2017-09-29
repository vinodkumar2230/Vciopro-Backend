using CoreEntities.ViewModels;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
   public interface IContacts
    {
        List<Contact> GetAllContacts();
        bool AddContacts(ContactViewModel model);
        bool EditContacts(ContactViewModel model);
        bool DeleteContacts(int ContactId);
    }
}
