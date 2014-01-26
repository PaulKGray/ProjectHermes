using ProjectHermes.Controllers.Actionfilters;
using ProjectHermes.Models.Admin;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHermes.Controllers
{
    public class PlaceController : Controller
    {

        private IPlaceService _PlaceService;

        public PlaceController(IPlaceService placeService)
        {
            _PlaceService = placeService;

        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult EditPlace(int id)
        {

            PlaceAdministration placeAdmin = new PlaceAdministration();

            if (id == 0)
            {
                placeAdmin.place = new PlaceModel();
            }
            else {

                placeAdmin.place = _PlaceService.GetPlace(id);

            }

            return View(placeAdmin);
        }



        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Transaction]
        public ActionResult EditPlace(PlaceAdministration model) {

            if (ModelState.IsValid)
            {

                if (model.place.PlaceId == 0)
                {
                    _PlaceService.CreatePlace(model.place);
                }
                else {
                    _PlaceService.SavePlace(model.place);
                }



            return RedirectToAction("Index","Admin");
            }

            return View(model);
        }

        [HttpGet]
        [Transaction]
        public ActionResult DeletePlace(int id) {

            _PlaceService.DeletePlace(id);

            return RedirectToAction("Index","Admin");
        }

    }

    
}
    