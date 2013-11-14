﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHermes.Models
{
    public class HomeModel
    {

        public IList<OrganisationModel> Organisations { get; set; }


        public HomeModel()
        {
			Organisations = new List<OrganisationModel>();
        }
    }
}