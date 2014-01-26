


using System.Collections.Generic;
namespace ProjectHermes.Domain
{
    public class Category
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual IList<AttractionCategories> AttractionCategories { get; set; }

        protected Category() { 
        
        }

        public Category(string name){

            this.CategoryName = name;
            AttractionCategories = new List<AttractionCategories>();
        }

 
    }
}
