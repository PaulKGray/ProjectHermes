

using FluentNHibernate.Mapping;
using ProjectHermes.Domain;
namespace ProjectHermes.Repository.Mappings
{
    class AttractionCategoriesMap : ClassMap<AttractionCategories>
    {
        public AttractionCategoriesMap()
        {
            Table("AttractionCategories");
            Id(x => x.AttractionCategoriesId);
            HasOne(x => x.Attraction).ForeignKey("Attraction_Id");
            HasOne(x => x.Category).ForeignKey("Category_Id");
        }
    }
}
