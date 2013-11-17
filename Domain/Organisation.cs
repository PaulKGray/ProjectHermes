﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHermes.Domain
{
	public class Organisation : DomainBase
    {
        public virtual int Organisationid { get; set; }

		public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<ChildItem> ChildItems { get; set; }

        public virtual Place OrganisationPlace { get; set; }
        
        protected Organisation()
        {

        }

        public Organisation(string name, Place place)
        {
            this.Name = name;
            this.OrganisationPlace = place;
            ChildItems = new List<ChildItem>();
        }


        public virtual void AddChildItem(ChildItem childitem)
        {
            
            this.ChildItems.Add(childitem);
            childitem.Parent = this;

        }


      

    }
}
