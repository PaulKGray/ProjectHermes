

using ProjectHermes.Services.ServiceModels;
using System.Collections.Generic;
namespace ProjectHermes.Services.Interfaces
{
    public interface IOrganisationService
    {
        OrganisationModel CreateOrganisation(OrganisationModel organisation);
        OrganisationModel GetOrganisation(int organisationId);
        void SaveOrganisation(OrganisationModel organisation);
        IList<OrganisationModel> GetAllOrganisation();
		void DeleteOrganisation(int id);
    }
}
