
using System.Web.Mvc;
using ProjectHermes.Models.Admin;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Services.ServiceModels;
namespace ProjectHermes.Controllers
{
    public class OrganisationController : Controller
    {

        private IOrganisationService _OrganisationService;
        private IPlaceService _PlaceService;
        //
        // GET: /Organisation/

        public OrganisationController(IOrganisationService organisationService, IPlaceService placeService)
        {
            this._OrganisationService = organisationService;
            this._PlaceService = placeService;
        }


        public ActionResult Index()
        {
            var organisations = _OrganisationService.GetAllOrganisation();
            return View(organisations);
        }


        public ActionResult OrganisationDetail(int id)
        {

            var organisationAdmin = new OrganisationAdministration();

            //ToDo: if administrator
            if (User.IsInRole("Administrator"))
            {

                organisationAdmin.Places = _PlaceService.GetAllPlace();

                if (id!=0)
                {
                    organisationAdmin.Organisation = new OrganisationModel(new PlaceModel());
                    return View(organisationAdmin);
                }

            }
            
            organisationAdmin.Organisation = _OrganisationService.GetOrganisation(id);

            return View(organisationAdmin);

        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult CreateOrUpdateOrganisation(OrganisationModel model)
        {

            if (ModelState.IsValid)
            {

                if (model.Organisationid == 0)
                {
                    model = _OrganisationService.CreateOrganisation(model);
                }
                else
                {

                    _OrganisationService.SaveOrganisation(model);

                }

                return RedirectToAction("Index");

            }

            return View(model);
        }

    }
}
