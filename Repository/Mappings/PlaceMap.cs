

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
            HasMany(x => x.PlaceOrganisation).Cascade.All().KeyColumns.Add("Place_Id");
        }
    }
}
