

namespace ProjectHermes.Domain
{
    public class AttractionCategories
    {
        public virtual int AttractionCategoriesId { get; set; }
        public virtual Attraction Attraction { get; set; }
        public virtual Category Category { get; set; } 


    }
}
