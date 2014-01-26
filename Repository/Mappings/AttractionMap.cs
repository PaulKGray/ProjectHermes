

using FluentNHibernate.Mapping;
using ProjectHermes.Domain;
namespace ProjectHermes.Repository.Mappings
{
    public class AttractionMap : ClassMap<Attraction>
    {
        public AttractionMap()
        {
            Table("Attraction");
            Id(x => x.AttractionId);
			Map(x => x.Name);
            Map(x => x.Description);
            HasOne(x => x.AttractionPlace).ForeignKey("Place_Id");
            HasMany(x => x.AttractionCategories).Cascade.All().KeyColumns.Add("Attraction_id");
        }
    }
}
