using ProjectHermes.Controllers.Actionfilters;
using ProjectHermes.Models;
using ProjectHermes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectHermes.Controllers
{
    public class HomeController : Controller
    {


        private IPlaceService _placeService;

        public HomeController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public ActionResult Index()
        {


            // Lets see if the main site role exists
            if (!Roles.RoleExists("Administrator"))
            {
                return RedirectToAction("SetUpSite", "Account");
            }


            var model = new HomeModel();

            var places = _placeService.GetAllPlace();

           

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            var item = _placeService.GetPlace(id);

            return View(item);

        }



    }


}
