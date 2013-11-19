using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Models
{
    public class HomeModel
    {

        public IList<PlaceModel> Places { get; set; }


        public HomeModel()
        {
			Places = new List<PlaceModel>();
        }
    }
}