using ProjectHermes.Domain;
using System.Collections.Generic;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Services.Converters
{

    /// <summary>
    /// Convert that attraction model or domain
    /// </summary>
    public class AttractionConverter : IConverter<Attraction,AttractionModel>
    {
        /// <summary>
        /// This is so we can deal with places effectively
        /// </summary>
        private IConverter<Place, PlaceModel> placeConverter;

        /// <summary>
        /// ToDo: Inject the Place Converter
        /// </summary>
        public AttractionConverter()
        {
           
        }

        public Attraction ConvertToDomain(AttractionModel model)
        {
            placeConverter = new PlaceConverter();
            var attraction = new Attraction(model.Name, placeConverter.ConvertToDomain(model.place));
            attraction.Name = model.Name;
            attraction.Description = model.Description;

            return attraction;
   
        }

        public AttractionModel ConvertFromDomain(Attraction domain)
        {
            placeConverter = new PlaceConverter();
            var attractionModel = new AttractionModel(placeConverter.ConvertFromDomain(domain.AttractionPlace));
            attractionModel.Attrationid = domain.AttractionId;
            attractionModel.Name = domain.Name;
            attractionModel.Description = domain.Description;

            return attractionModel;
        }

        public IList<Attraction> ConvertToDomains(IList<AttractionModel> models)
        {
            IList<Attraction> attractionsDomain = new List<Attraction>();

            foreach (var item in models)
            {
                attractionsDomain.Add(ConvertToDomain(item));
            }

            return attractionsDomain;
        }

        public IList<AttractionModel> ConvertFromDomains(IList<Attraction> domains)
        {
            IList<AttractionModel> attractionModel = new List<AttractionModel>();

            foreach (var item in domains)
            {
                attractionModel.Add(ConvertFromDomain(item));
            }

            return attractionModel;
        }
    }
}