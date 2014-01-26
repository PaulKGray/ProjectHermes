using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectHermes.Services.ServiceModels;

namespace ProjectHermes.Models.Admin
{
    public class AttractionAdministration
    {

        public AttractionModel Attraction { get; set; }
        public IList<PlaceModel> Places { get; set; }

    }
}