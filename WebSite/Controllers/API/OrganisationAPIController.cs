using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ProjectHermes.Helpers.Converters;
using ProjectHermes.Models;
using ProjectHermes.Services.Interfaces;

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
            var converter = new OrganisationConverter();  
            var Organisations = converter.convertOrganisationDomainObject(_OrganisationService.GetAllOrganisation());
            return Organisations;
        }

    }
}
