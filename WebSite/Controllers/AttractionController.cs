
using System.Web.Mvc;
using ProjectHermes.Models.Admin;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Services.ServiceModels;
namespace ProjectHermes.Controllers
{
    public class AttractionController : Controller
    {

        private IAttractionService AttractionService;
        private IPlaceService PlaceService;
        //
        // GET: /Attraction/

        public AttractionController(IAttractionService attractionService, IPlaceService placeService)
        {
            this.AttractionService = attractionService;
            this.PlaceService = placeService;
        }


        public ActionResult Index()
        {
            var attractions = AttractionService.GetAllAttractions();
            return View(attractions);
        }



        public ActionResult EditAttraction(int id) {

            AttractionAdministration attractionEdit = new AttractionAdministration();
            attractionEdit.Places = PlaceService.GetAllPlace();

            if (id!=0)
            {
                attractionEdit.Attraction = AttractionService.GetAttraction(id);
            }


            return View(attractionEdit);
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult EditAttraction(AttractionAdministration model)
        {

            if (ModelState.IsValid)
            {

                if (model.Attraction.Attrationid == 0)
                {
                    AttractionService.CreateAttraction(model.Attraction);
                }
                else
                {
                    AttractionService.SaveAttraction(model.Attraction);
                }

                return RedirectToAction("Index");

            }

            model.Places = PlaceService.GetAllPlace();

            return View(model);
        }

    }
}
