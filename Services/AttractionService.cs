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
    public class AttractionService : IAttractionService
    {

        private IRepository<Attraction> _ParentRepository;
        private IConverter<Attraction, AttractionModel> attractionConverter;
        private ValidationContext vc = null;
        private List<ValidationResult> validationResults = new List<ValidationResult>();

        public AttractionService(IRepository<Attraction> repository)
        {
            _ParentRepository = repository;
            attractionConverter = new AttractionConverter();
        }

        public AttractionModel CreateAttraction(AttractionModel attraction)
        {
            if (Validator.TryValidateObject(attraction, vc, validationResults, true))
            {
                var attractionDomain = attractionConverter.ConvertToDomain(attraction);
                attractionDomain = _ParentRepository.Add(attractionDomain);
                attraction = attractionConverter.ConvertFromDomain(attractionDomain);
            }
            else
            {
                throw new ArgumentException("Create Place could not create a place invalid arguments were sent");
            }
            return attraction;
        }

        public AttractionModel GetAttraction(int id)
        {
            var attractionDomain = _ParentRepository.FindBy(id);
            return attractionConverter.ConvertFromDomain(attractionDomain);
        }

        public void SaveAttraction(AttractionModel attraction)
        {
            var attractionDomain = attractionConverter.ConvertToDomain(attraction);
            _ParentRepository.Update(attractionDomain);
        }

        public IList<AttractionModel> GetAllAttractions()
        {
            return attractionConverter.ConvertFromDomains(_ParentRepository.FindAll());
        }


        public void DeleteAttraction(int id)
        {
            var attraction = _ParentRepository.FindBy(id);
            _ParentRepository.Delete(attraction);
        }
    }
}