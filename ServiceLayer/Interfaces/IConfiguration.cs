using CoreEntities.ViewModels;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
   public interface IConfiguration
    {
        List<Configuration> GetAllConfigurations();
        bool AddConfigurations(ConfigurationViewModel model);
        bool EditConfigurations(ConfigurationViewModel model);
        bool DeleteConfigurations(int ID);
    }
}
