

namespace ProjectHermes.Domain
{
    public class OrganisationCategories
    {
        public virtual int OrganisationCategoriesId { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual Category Category { get; set; } 


    }
}
