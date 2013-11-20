using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Models.Admin
{
    public class AdminModel
    {

		public IList<OrganisationModel> Organisations { get; set; }

        public IList<PlaceModel> Places { get; set; }

        public AdminModel()
        {
            this.Places = new List<PlaceModel>();
			this.Organisations = new List<OrganisationModel>();
        }

    }

    public class AdminCreateModel {

        public OrganisationModel Organisation { get; set; }
 

        public AdminCreateModel()
        {

        }
    
    }


}