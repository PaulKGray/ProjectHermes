using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHermes.Services.ServiceModels
{
    public class PlaceModel 
    {
        public int PlaceId { get; set; }

        [DisplayName("Place Name")]
        [Required(ErrorMessage = "A place must have a name")]
        public string PlaceName { get; set; }

        [DisplayName("Place Descrition")]
        [Required(ErrorMessage = "A place needs a description")]
        public string PlaceDescription { get; set; }

        [DisplayName("Latitude")]
        [Required(ErrorMessage = "A place needs a latitude")]
        [Range(-90, 90, ErrorMessage = "Latitude degrees must be between {1} and {2}")]
        public decimal Latitude { get; set; }

        [DisplayName("Longitude")]
        [Required(ErrorMessage = "A place needs a Longitude")]
        [Range(-180, 180, ErrorMessage = "Longitude degrees must be between {1} and {2}")]
        public decimal Longitude { get; set; }

        public IList<AttractionModel> Attractions { get; set; }

        public PlaceModel()
        {
            Attractions = new List<AttractionModel>();
        }
    }
}