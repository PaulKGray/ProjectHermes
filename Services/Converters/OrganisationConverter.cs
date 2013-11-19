using ProjectHermes.Domain;
using System.Collections.Generic;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Services.Converters
{

    /// <summary>
    /// Convert that organisation model or domain
    /// </summary>
    public class OrganisationConverter : IConverter<Organisation,OrganisationModel>
    {
        /// <summary>
        /// This is so we can deal with places effectively
        /// </summary>
        private IConverter<Place, PlaceModel> placeConverter;

        /// <summary>
        /// ToDo: Inject the Place Converter
        /// </summary>
        public OrganisationConverter()
        {
           
        }

        public Organisation ConvertToDomain(OrganisationModel model)
        {
            placeConverter = new PlaceConverter();
            var organisation = new Organisation(model.Name, placeConverter.ConvertToDomain(model.place));
            organisation.Name = model.Name;
            organisation.Description = model.Description;

            return organisation;
   
        }

        public OrganisationModel ConvertFromDomain(Organisation domain)
        {
            placeConverter = new PlaceConverter();
            var organisationModel = new OrganisationModel(placeConverter.ConvertFromDomain(domain.OrganisationPlace));
            organisationModel.Organisationid = domain.Organisationid;
            organisationModel.Name = domain.Name;
            organisationModel.Description = domain.Description;

            return organisationModel;
        }

        public IList<Organisation> ConvertToDomains(IList<OrganisationModel> models)
        {
            IList<Organisation> organisationsDomain = new List<Organisation>();

            foreach (var item in models)
            {
                organisationsDomain.Add(ConvertToDomain(item));
            }

            return organisationsDomain;
        }

        public IList<OrganisationModel> ConvertFromDomains(IList<Organisation> domains)
        {
            IList<OrganisationModel> organisationModel = new List<OrganisationModel>();

            foreach (var item in domains)
            {
                organisationModel.Add(ConvertFromDomain(item));
            }

            return organisationModel;
        }
    }
}