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
		Organisation CreateOrganisation(Organisation organisation);
        Organisation GetOrganisation(int organisationId);
        void SaveOrganisation(Organisation organisation);
		IList<Organisation> GetAllOrganisation();
		void DeleteOrganisation(int id);
    }
}
