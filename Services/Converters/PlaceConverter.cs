using ProjectHermes.Domain;
using System.Collections.Generic;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Services.Converters
{
    public class PlaceConverter : IConverter<Place,PlaceModel>
    {

        private IConverter<Organisation, OrganisationModel> organisationConverter;

        public PlaceConverter()
        {
      
        }

        public Place ConvertToDomain(PlaceModel model)
        {
            organisationConverter = new OrganisationConverter();
            var place = new Place(model.PlaceName);
            place.PlaceID = model.PlaceId;
            place.PlaceDescription = model.PlaceDescription;
            place.PlaceOrganisation = organisationConverter.ConvertToDomains(model.Organisations);

            return place;

        }

        public PlaceModel ConvertFromDomain(Place domain)
        {
            organisationConverter = new OrganisationConverter();
            var placeModel = new PlaceModel();
            placeModel.PlaceName = domain.PlaceName;
            placeModel.PlaceDescription = domain.PlaceDescription;
            placeModel.Organisations = organisationConverter.ConvertFromDomains(domain.PlaceOrganisation);
            return placeModel;
        }

        public IList<Place> ConvertToDomains(IList<PlaceModel> models)
        {
            IList<Place> places = new List<Place>();

            foreach (var item in models)
            {
                places.Add(ConvertToDomain(item));
            }

            return places;
        }

        public IList<PlaceModel> ConvertFromDomains(IList<Place> domains)
        {
            IList<PlaceModel> places = new List<PlaceModel>();

            foreach (var item in domains)
            {
                places.Add(ConvertFromDomain(item));
            }

            return places;

        }
    }
}