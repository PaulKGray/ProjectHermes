using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHermes.Controllers.Actionfilters;
using ProjectHermes.Domain;
using ProjectHermes.Models;
using ProjectHermes.Services.Interfaces;

namespace ProjectHermes.Controllers
{
	public class AdminController : Controller
	{
		//
		// GET: /Admin/

		private IOrganisationService _OrganisationService;
		private IChildItemService _ChildItemService;

		public AdminController(IOrganisationService organisationService, IChildItemService childItemService)
		{
			_OrganisationService = organisationService;
			_ChildItemService = childItemService;
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
			IList<OrganisationModel> organisationModelItems = new List<OrganisationModel>();

			foreach (var item in organisations)
			{
				var organisation = new OrganisationModel();
				organisation.Name = item.Name;
                organisation.Description = item.Description;
				organisation.Organisationid = item.Organisationid;

				foreach (var childItem in item.ChildItems)
				{
					var childItemModel = new ChildItemModel();
					childItemModel.Name = childItem.Name;
					childItemModel.ChildItemId = childItem.ChildItemId;
					childItemModel.Organisation = organisation;

					organisation.ChildItems.Add(childItemModel);
				}


				organisationModelItems.Add(organisation);
			}

			adminModel.Organisations = organisationModelItems;

			return adminModel;

		}
		
		[Authorize(Roles = "Administrator")]
		[HttpGet]
		public ActionResult Organisation()
		{

			var model = new AdminCreateModel();
			var organisation = new OrganisationModel();

			model.Organisation = organisation;

			for (int i = 0; i < 6; i++)
			{
				var childitem = new ChildItemModel();

				model.ChildItems.Add(childitem);

			}
			return View(model);
		}

		[Authorize(Roles = "Administrator")]
		[HttpPost]
		public ActionResult Organisation(AdminCreateModel model)
		{

			if (ModelState.IsValid)
			{

                var organisation = new Organisation(model.Organisation.Name);
                organisation.Name = model.Organisation.Name;
                organisation.Description = model.Organisation.Description;
				TempData["Message"] = string.Format("{0} has been added to your cart!", model.Organisation.Name);


				foreach (var item in model.ChildItems)
				{
					if (item.Name != null)
					{

						var childItem = new ChildItem(organisation);
						childItem.Name = item.Name;
						organisation.AddChildItem(childItem);

					}
				}


				organisation = _OrganisationService.CreateParent(organisation);

				return RedirectToAction("Index");

			}

			return View(model);
		}
		
		[Authorize(Roles = "Administrator")]
		[HttpGet]
		public ActionResult EditOrganisation(int id)
		{
			var Organisation = _OrganisationService.GetOrganisation(id);
			var OrganisationModel = new OrganisationModel();

			OrganisationModel.Name = Organisation.Name;
            OrganisationModel.Description = Organisation.Description;
            OrganisationModel.Organisationid = Organisation.Organisationid;

			return View(OrganisationModel);
		}

		[Authorize(Roles = "Administrator")]
		[Transaction]
		[HttpPost]
		public ActionResult EditOrganisation(OrganisationModel item)
		{
			if (ModelState.IsValid)
			{

				var Organisation = new Organisation(item.Name);
				Organisation.Name = item.Name;
                Organisation.Description = item.Description;
				Organisation.Organisationid = item.Organisationid;

				_OrganisationService.SaveOrganisation(Organisation);

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
