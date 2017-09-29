using CoreEntities.ViewModels;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IPassword
    {
        bool AddPwd(PasswordViewModel model);
        List<Password> GetAllPwd();
        bool EditPwd(PasswordViewModel model);
        bool DeletePwd(int ID);
    }
}
