using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Repository.Interfaces;
using ProjectHermes.Domain;

namespace ProjectHermes.Services
{
    public class OrganisationService : IOrganisationService
    {

        private IRepository<Organisation> _ParentRepository;


        public OrganisationService(IRepository<Organisation> repository)
        {
            _ParentRepository = repository;
        }

        public Organisation CreateParent(Organisation parent)
        {
            _ParentRepository.Add(parent);

            return parent;
        }

        public Organisation GetOrganisation(int OrganisationId)
        {
            var Organisation = _ParentRepository.FindBy(OrganisationId);
            return Organisation;
        }

        public void SaveOrganisation(Organisation Organisation)
        {
            _ParentRepository.Update(Organisation);
        }

 				public IList<Organisation> GetAllOrganisation()
				{
					return _ParentRepository.FindAll();
				}


				public void DeleteOrganisation(int id)
				{
					var Organisation = _ParentRepository.FindBy(id);
					_ParentRepository.Delete(Organisation);
				}
		}
}