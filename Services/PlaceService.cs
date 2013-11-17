using ProjectHermes.Domain;
using ProjectHermes.Repository.Interfaces;
using ProjectHermes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHermes.Services
{
    class PlaceService : IPlaceService
    {
        private IRepository<Place> placeRepository;

        public PlaceService(IRepository<Place> repository)
        {
            placeRepository = repository;
        }

        public Place CreatePlace(Place place)
        {
            return placeRepository.Add(place);
        }

        public Place GetPlace(int placeId)
        {
            return placeRepository.FindBy(placeId);
        }

        public void SavePlace(Place place)
        {
            placeRepository.Update(place);
        }

        public IList<Place> GetAllPlace()
        {
            return placeRepository.FindAll();
        }

        public void DeleteOrganisation(int placeId)
        {
            var place = placeRepository.FindBy(placeId);

            //ToDo: need to add some logic deal with orgs linked to places

            placeRepository.Delete(place);
        }
    }
}
