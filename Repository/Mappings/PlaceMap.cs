

using FluentNHibernate.Mapping;
using ProjectHermes.Domain;
namespace ProjectHermes.Repository.Mappings
{
    class PlaceMap : ClassMap<Place>
    {
        public PlaceMap()
        {
            Table("Place");
            Id(x => x.PlaceID);
            Map(x => x.PlaceName);
            Map(x => x.PlaceDescription);
            Map(x => x.Latitude);
            Map(x => x.Longitude);
            HasMany(x => x.PlaceAttraction).Cascade.All().KeyColumns.Add("Place_Id");
        }
    }
}
