using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHermes.Controllers.Actionfilters;
using ProjectHermes.Domain;
using ProjectHermes.Models;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Controllers
{
	public class AdminController : Controller
	{
		//
		// GET: /Admin/

		private IOrganisationService _OrganisationService;

		public AdminController(IOrganisationService organisationService)
		{
			_OrganisationService = organisationService;
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

			foreach (var item in organisations)
			{
				
			}


			return adminModel;

		}
		
		[Authorize(Roles = "Administrator")]
		[HttpGet]
		public ActionResult Organisation()
		{

			var model = new AdminCreateModel();
            //var organisation = new OrganisationModel();

            //model.Organisation = organisation;

            //for (int i = 0; i < 6; i++)
            //{
            //    var childitem = new ChildItemModel();

            //    model.ChildItems.Add(childitem);

            //}
			return View(model);
		}

		[Authorize(Roles = "Administrator")]
		[HttpPost]
		public ActionResult Organisation(AdminCreateModel model)
		{

			if (ModelState.IsValid)
			{

 

				return RedirectToAction("Index");

			}

			return View(model);
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
