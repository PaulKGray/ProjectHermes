


using System.Collections.Generic;
namespace ProjectHermes.Domain
{
    public class Category
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual IList<OrganisationCategories> OrganisationCategories { get; set; }

        protected Category() { 
        
        }

        public Category()
        {
            OrganisationCategories = new List<OrganisationCategories>();
        }

 
    }
}
