﻿
using System.Web.Mvc;
using ProjectHermes.Models.Admin;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Services.ServiceModels;
using ProjectHermes.Controllers.Actionfilters;
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
            attractionEdit.Places = GetPlaceSelectList();

            if (id != 0)
            {
                attractionEdit.Attraction = AttractionService.GetAttraction(id);
            }
            else {
                attractionEdit.Attraction = new AttractionModel();
            }


            return View(attractionEdit);
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult EditAttraction(AttractionAdministration model)
        {

            if (ModelState.IsValid)
            {

                var selectedplace = PlaceService.GetPlace(model.SelectedPlace);
                model.Attraction.place = selectedplace;

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

            model.Places = GetPlaceSelectList();

            return View(model);
        }

        private SelectList GetPlaceSelectList() {

            var places = PlaceService.GetAllPlace();



            var selectPlaces = new SelectList(places, "PlaceId", "PlaceName");
            
            

            return selectPlaces;

        }

        
		[Authorize(Roles = "Administrator")]
		[Transaction]
		[HttpGet]
		public ActionResult DeleteAttraction(int id)
		{

			AttractionService.DeleteAttraction(id);

			return RedirectToAction("Index");
		}

	}
    
}
