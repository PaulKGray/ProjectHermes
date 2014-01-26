

using ProjectHermes.Services.ServiceModels;
using System.Collections.Generic;
namespace ProjectHermes.Services.Interfaces
{
    public interface IAttractionService
    {
        AttractionModel CreateAttraction(AttractionModel attraction);
        AttractionModel GetAttraction(int attractionId);
        void SaveAttraction(AttractionModel attraction);
        IList<AttractionModel> GetAllAttractions();
		void DeleteAttraction(int id);
    }
}
