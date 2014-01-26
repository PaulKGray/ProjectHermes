using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHermes.Controllers.Actionfilters;
using ProjectHermes.Models.Admin;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private IAttractionService AttractionService;
        private IPlaceService PlaceService;

        public AdminController(IAttractionService attractionService, IPlaceService placeService)
        {
            AttractionService = attractionService;
            PlaceService = placeService;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {

            AdminModel adminModel = PopulateAdminModel();

            return View(adminModel);
        }

        [Authorize(Roles = "Administrator")]
        private AdminModel PopulateAdminModel()
        {
            var adminModel = new AdminModel();

            var attractions = AttractionService.GetAllAttractions();

            var places = PlaceService.GetAllPlace();

            adminModel.Places = places;
            adminModel.Attractions = attractions;

            return adminModel;

        }



    }

}
