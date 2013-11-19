using ProjectHermes.Services.Converters;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Services.ServiceModels;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectHermes.Controllers
{
    public class OrganisationAPIController : ApiController
    {
        
        private IOrganisationService _OrganisationService;


        public OrganisationAPIController(IOrganisationService OrganisationService)
        {
            _OrganisationService = OrganisationService;
        }

 
        public IList<OrganisationModel> GetAllParents()
        { 
            var Organisations = _OrganisationService.GetAllOrganisation();
            return Organisations;
        }

    }
}
