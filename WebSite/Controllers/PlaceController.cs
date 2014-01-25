using ProjectHermes.Models.Admin;
using ProjectHermes.Services.Interfaces;
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

        [HttpGet]
        public ActionResult EditPlace(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditPlace(PlaceAdministration model) {

            if (ModelState.IsValid)
            { 

            _PlaceService.CreatePlace(model.place);

            return RedirectToAction("Index","Admin");
            }

            return View();
        }

    }
}
    