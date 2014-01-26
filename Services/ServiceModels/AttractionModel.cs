using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectHermes.Domain;

namespace ProjectHermes.Services.ServiceModels
{
    public class AttractionModel
    {
	    public int Attrationid { get; set; }

        [DisplayName("Attraction Name")]
        [StringLength(160)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "A description is required is required")]
        public string Description { get; set; }


        public PlaceModel place {get; set;}

        public AttractionModel()
        { 
        }


      
    }
}