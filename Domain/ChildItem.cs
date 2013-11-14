using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHermes.Domain
{
	public class ChildItem : DomainBase
    {
        public virtual int ChildItemId { get; set; }
        public virtual Organisation Parent { get; set; }

		    public virtual string Name { get; set; }

        protected ChildItem()
        {

        }

        public ChildItem(Organisation parent)
        {
            Parent = parent; 
        }

      
        


      
    }


}
