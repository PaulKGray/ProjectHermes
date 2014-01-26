using ProjectHermes.Services.Converters;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Services.ServiceModels;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectHermes.Controllers
{
    public class attractionAPIController : ApiController
    {
        
        private IAttractionService AttractionService;


        public attractionAPIController(IAttractionService attractionService)
        {
            AttractionService = attractionService;
        }

 
        public IList<AttractionModel> GetAllAttractions()
        { 
            var attractions = AttractionService.GetAllAttractions();
            return attractions;
        }

    }
}
