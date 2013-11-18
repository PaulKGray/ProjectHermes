using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHermes.Models
{
    public class PlaceModel 
    {
        public int PlaceId { get; set; }

        [DisplayName("Place Name")]
        [Required]
        public string PlaceName { get; set; }

        [DisplayName("Place Descrition")]
        [Required]
        public string PlaceDescription { get; set; }

        public IList<OrganisationModel> Organisations { get; set; }

        public PlaceModel()
        {
            Organisations = new List<OrganisationModel>();
        }
    }
}