using ProjectHermes.Domain;
using System.Collections.Generic;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Services.Converters
{
    public class PlaceConverter : IConverter<Place,PlaceModel>
    {

        private IConverter<Attraction, AttractionModel> attractionConverter;

        public PlaceConverter()
        {
      
        }

        public Place ConvertToDomain(PlaceModel model)
        {
            attractionConverter = new AttractionConverter();
            var place = new Place(model.PlaceName);
            place.PlaceID = model.PlaceId;
            place.PlaceDescription = model.PlaceDescription;
            place.Latitude = model.Latitude;
            place.Longitude = model.Longitude;

            place.PlaceAttraction = attractionConverter.ConvertToDomains(model.Attractions);

            return place;

        }

        public PlaceModel ConvertFromDomain(Place domain)
        {
            attractionConverter = new AttractionConverter();
            var placeModel = new PlaceModel();
            placeModel.PlaceId = domain.PlaceID;
            placeModel.PlaceName = domain.PlaceName;
            placeModel.PlaceDescription = domain.PlaceDescription;
            placeModel.Latitude = domain.Latitude;
            placeModel.Longitude = domain.Longitude;

            placeModel.Attractions = attractionConverter.ConvertFromDomains(domain.PlaceAttraction);
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