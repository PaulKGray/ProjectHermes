using ProjectHermes.Controllers.Actionfilters;
using ProjectHermes.Domain;
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

        private IOrganisationService _OrganisationService;
		private IChildItemService _ChildItemService;

        public HomeController(IOrganisationService OrganisationService, IChildItemService childItemService)
        {
					_OrganisationService = OrganisationService;
					_ChildItemService = childItemService;
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

            var organisations = _OrganisationService.GetAllOrganisation();

            foreach (var item in organisations)
            {
                var organisation = new OrganisationModel();

                organisation = convertOrganisationDomainObject(item);

                model.Organisations.Add(organisation);

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            var item = _OrganisationService.GetOrganisation(id);

            var viewmodel = convertOrganisationDomainObject(item);

            return View(viewmodel);
            
        }

        OrganisationModel convertOrganisationDomainObject(Organisation organisation)
        {

            var organisationModel = new OrganisationModel();
            organisationModel.Organisationid = organisation.Organisationid;
            organisationModel.Name = organisation.Name;
            organisationModel.Description = organisation.Description;

            foreach (var childItem in organisation.ChildItems)
            {

                var newChildItem = new ChildItemModel();
                newChildItem.ChildItemId = childItem.ChildItemId;
                newChildItem.Name = childItem.Name;

                organisationModel.ChildItems.Add(newChildItem);

            }

            return organisationModel;

        }


    }

    
}
