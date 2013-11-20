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

		private IOrganisationService _OrganisationService;
        private IPlaceService _PlaceService;

		public AdminController(IOrganisationService organisationService, IPlaceService placeService)
		{
			_OrganisationService = organisationService;
            _PlaceService = placeService;
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

			var organisations = _OrganisationService.GetAllOrganisation();

            var places = _PlaceService.GetAllPlace();

            adminModel.Places = places;
            adminModel.Organisations = organisations;

			return adminModel;

		}
		

		
		[Authorize(Roles = "Administrator")]
		[HttpGet]
		public ActionResult EditOrganisation(int id)
		{
			var Organisation = _OrganisationService.GetOrganisation(id);

            return View(Organisation);
		}

		[Authorize(Roles = "Administrator")]
		[Transaction]
		[HttpPost]
		public ActionResult EditOrganisation(OrganisationModel item)
		{
			if (ModelState.IsValid)
			{

                //var Organisation = new Organisation(item.Name, item.place);
                //Organisation.Name = item.Name;
                //Organisation.Description = item.Description;
                //Organisation.Organisationid = item.Organisationid;

                //_OrganisationService.SaveOrganisation(Organisation);

				return RedirectToAction("Index");
			}

			return View(item);
		}

		[Authorize(Roles = "Administrator")]
		[Transaction]
		[HttpGet]
		public ActionResult DeleteOrganisation(int id)
		{

			_OrganisationService.DeleteOrganisation(id);

			return RedirectToAction("Index");
		}

	}
}
