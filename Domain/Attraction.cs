
using System.Collections.Generic;
namespace ProjectHermes.Domain
{
	public class Attraction : DomainBase
    {
        public virtual int AttractionId { get; set; }

		public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual Place AttractionPlace { get; set; }

        public virtual IList<AttractionCategories> AttractionCategories { get; set; }

                
        protected Attraction()
        {

        }

        public Attraction(string name, Place place)
        {
            this.Name = name;
            this.AttractionPlace = place;
            this.AttractionCategories = new List<AttractionCategories>();
        }



      

    }
}
