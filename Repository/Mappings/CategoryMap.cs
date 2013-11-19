

using FluentNHibernate.Mapping;
using ProjectHermes.Domain;
namespace ProjectHermes.Repository.Mappings
{
    class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Category");
            Id(x => x.CategoryId);
            Map(x => x.CategoryName);
            HasMany(x => x.OrganisationCategories).Cascade.All().KeyColumns.Add("Category_id");
          
            
        }
    }
}
