

using System.Collections.Generic;
namespace ProjectHermes.Domain
{
    public class Place : DomainBase
    {
        public virtual int PlaceID { get; set; }
        public virtual string PlaceName { get; set; }
        public virtual string PlaceDescription { get; set; }
        public virtual IList<Organisation> PlaceOrganisation { get; set; }


        protected Place() { }

        public Place(string placeName)
        {
            this.PlaceName = placeName;
            this.PlaceOrganisation = new List<Organisation>();
        }

    }
}
