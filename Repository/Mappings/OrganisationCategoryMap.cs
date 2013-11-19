

using FluentNHibernate.Mapping;
using ProjectHermes.Domain;
namespace ProjectHermes.Repository.Mappings
{
    class OrganisationCategoriesMap : ClassMap<OrganisationCategories>
    {
        public OrganisationCategoriesMap()
        {
            Table("OrganisationCategories");
            Id(x => x.OrganisationCategoriesId);
            HasOne(x => x.Organisation).ForeignKey("Organisation_Id");
            HasOne(x => x.Category).ForeignKey("Category_Id");
        }
    }
}
