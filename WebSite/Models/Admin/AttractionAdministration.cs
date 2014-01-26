using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectHermes.Services.ServiceModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ProjectHermes.Models.Admin
{
    public class AttractionAdministration
    {

        public AttractionModel Attraction { get; set; }
        public SelectList Places { get; set; }

        [DisplayName("Place")]
        [Required(ErrorMessage = "Place is required")]
        public int SelectedPlace { get; set; }

    }
}