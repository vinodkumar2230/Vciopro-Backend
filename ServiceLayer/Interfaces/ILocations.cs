using CoreEntities.ViewModels;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
   public interface ILocations
    {
       // List<Location> GetAllLocations();
        bool AddLocations(LocationsViewModel model);
        bool EditLocations(LocationsViewModel model);
        bool DeleteLocations(int LocationId);
        List<Location> GetAllLocations(int id);
    }
}
