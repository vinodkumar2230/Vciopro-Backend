using CoreEntities.ViewModels;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IOrganisations
    {
        bool AddOrg(OrganisationsViewModel model);
        bool EditOrg(OrganisationsViewModel model);
        bool DeleteOrg(int OrganisationId);
        List<Organisation> GetAllOrganisations();
        Organisation GetOrgById(int id);
        // List<Organisation> GetAllOrganisationbyID(OrganisationsViewModel model, int OrganisationId);
    }
}