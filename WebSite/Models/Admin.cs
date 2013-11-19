using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectHermes.Domain;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Models
{
    public class AdminModel
    {

		public IList<OrganisationModel> Organisations;

        public AdminModel()
        {
			Organisations = new List<OrganisationModel>();
        }

    }

    public class AdminCreateModel {

        public OrganisationModel Organisation { get; set; }
 

        public AdminCreateModel()
        {

        }
    
    }


}