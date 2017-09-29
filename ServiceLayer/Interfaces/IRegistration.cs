using CoreEntities.Domain;
using CoreEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IRegistration
    {
        bool  AddUser(APiRegisterViewModel model);
        bool LoginUser(LoginViewModel model);
    }
}
