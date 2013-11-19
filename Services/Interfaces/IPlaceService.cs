
using System.Collections.Generic;
using ProjectHermes.Services.ServiceModels;
namespace ProjectHermes.Services.Interfaces
{
    public interface IPlaceService
    {
        PlaceModel CreatePlace(PlaceModel place);
        PlaceModel GetPlace(int placeId);
        void SavePlace(PlaceModel place);
        IList<PlaceModel> GetAllPlace();
        void DeletePlace(int placeId);
    }
}
