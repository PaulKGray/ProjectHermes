

using FluentNHibernate.Mapping;
using ProjectHermes.Domain;
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
            HasMany(x => x.OrganisationCategories).Cascade.All().KeyColumns.Add("Organisation_id");
        }
    }
}
