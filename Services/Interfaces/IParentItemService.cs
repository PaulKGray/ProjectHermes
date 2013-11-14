using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHermes.Domain;

namespace ProjectHermes.Services.Interfaces
{
    public interface IOrganisationService
    {
		Organisation CreateParent(Organisation parent);
        Organisation GetOrganisation(int OrganisationId);
        void SaveOrganisation(Organisation Organisation);
		IList<Organisation> GetAllOrganisation();
		void DeleteOrganisation(int id);
    }
}
