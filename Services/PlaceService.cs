using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectHermes.Domain;
using ProjectHermes.Repository.Interfaces;
using ProjectHermes.Services.Converters;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Services
{
    class PlaceService : IPlaceService
    {
        private IRepository<Place> placeRepository;
        private IConverter<Place, PlaceModel> placeConverter;
        private ValidationContext vc = null;
        private List<ValidationResult> validationResults = new List<ValidationResult>();

        public PlaceService(IRepository<Place> repository)
        {
            placeRepository = repository;
            placeConverter = new PlaceConverter();
        }

        public PlaceModel CreatePlace(PlaceModel place)
        {

            if (Validator.TryValidateObject(place, vc, validationResults, true))
            {

                var placeDomain = placeConverter.ConvertToDomain(place);
                placeDomain = placeRepository.Add(placeDomain);

                place = placeConverter.ConvertFromDomain(placeDomain);

            } else {

                throw new ArgumentException("Create Place could not create a place invalid arguments were sent");
            }

            return place;
            

        }

        public PlaceModel GetPlace(int placeId)
        {

            var placeDomain = placeRepository.FindBy(placeId);
            return placeConverter.ConvertFromDomain(placeDomain);
        }

        public void SavePlace(PlaceModel place)
        {


            if (Validator.TryValidateObject(place, vc, validationResults, true))
            {
                var placeDomain = placeConverter.ConvertToDomain(place);
                placeRepository.Update(placeDomain);
            }
            else
            {

                throw new ArgumentException("Create Place could not create a place invalid arguments were sent");
            }

        }

        public IList<PlaceModel> GetAllPlace()
        {
            var placeDomains =  placeRepository.FindAll();
            return placeConverter.ConvertFromDomains(placeDomains);

        }

        public void DeletePlace(int placeId)
        {
            var place = placeRepository.FindBy(placeId);

            //ToDo: need to add some logic deal with orgs linked to places

            placeRepository.Delete(place);
        }


    }
}
