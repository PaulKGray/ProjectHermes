using ProjectHermes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHermes.Services.Interfaces
{
    interface IPlaceService
    {
        Place CreatePlace(Place place);
        Place GetPlace(int placeId);
        void SavePlace(Place place);
        IList<Place> GetAllPlace();
        void DeletePlace(int placeId);
    }
}
