﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHermes.Domain;
using FluentNHibernate.Mapping;

namespace ProjectHermes.Repository.Mappings
{
    public class OrganisationMap : ClassMap<Organisation>
    {
        public OrganisationMap()
        {
            Table("Organisation");
            Id(x => x.Organisationid);
			Map(x => x.Name);
            Map(x => x.Description);
            HasOne(x => x.OrganisationPlace).ForeignKey("Place_Id");
        }
    }
}
