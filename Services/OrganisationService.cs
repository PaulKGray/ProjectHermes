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
    public class OrganisationService : IOrganisationService
    {

        private IRepository<Organisation> _ParentRepository;
        private IConverter<Organisation, OrganisationModel> organisationConverter;
        private ValidationContext vc = null;
        private List<ValidationResult> validationResults = new List<ValidationResult>();

        public OrganisationService(IRepository<Organisation> repository)
        {
            _ParentRepository = repository;
            organisationConverter = new OrganisationConverter();
        }

        public OrganisationModel CreateOrganisation(OrganisationModel organisation)
        {
            if (Validator.TryValidateObject(organisation, vc, validationResults, true))
            {
                var organisationDomain = organisationConverter.ConvertToDomain(organisation);
                organisationDomain = _ParentRepository.Add(organisationDomain);
                organisation = organisationConverter.ConvertFromDomain(organisationDomain);
            }
            else
            {
                throw new ArgumentException("Create Place could not create a place invalid arguments were sent");
            }
            return organisation;
        }

        public OrganisationModel GetOrganisation(int organisationId)
        {
            var organisationDomain = _ParentRepository.FindBy(organisationId);
            return organisationConverter.ConvertFromDomain(organisationDomain);
        }

        public void SaveOrganisation(OrganisationModel organisation)
        {
            var organisationDomain = organisationConverter.ConvertToDomain(organisation);
            _ParentRepository.Update(organisationDomain);
        }

        public IList<OrganisationModel> GetAllOrganisation()
        {
            return organisationConverter.ConvertFromDomains(_ParentRepository.FindAll());
        }


        public void DeleteOrganisation(int id)
        {
            var Organisation = _ParentRepository.FindBy(id);
            _ParentRepository.Delete(Organisation);
        }
    }
}