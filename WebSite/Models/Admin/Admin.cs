using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Models.Admin
{
    public class AdminModel
    {

		public IList<AttractionModel> Attractions { get; set; }

        public IList<PlaceModel> Places { get; set; }

        public AdminModel()
        {
            this.Places = new List<PlaceModel>();
			this.Attractions = new List<AttractionModel>();
        }

    }

    public class AdminCreateModel {

        public AttractionModel Attraction { get; set; }
 

        public AdminCreateModel()
        {

        }
    
    }


}