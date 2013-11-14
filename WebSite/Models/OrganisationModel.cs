using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectHermes.Domain;

namespace ProjectHermes.Models
{
    public class OrganisationModel
    {
	    public int Organisationid { get; set; }

        [DisplayName("Parent Item Name")]
        [StringLength(160)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

		public IList<ChildItemModel> ChildItems;

        public OrganisationModel()
        {
			ChildItems = new List<ChildItemModel>();
        }

      
    }
}