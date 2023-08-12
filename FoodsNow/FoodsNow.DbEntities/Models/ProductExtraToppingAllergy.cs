namespace FoodsNow.DbEntities.Models
{
    public class ProductExtraToppingAllergy : BaseEntity
    {
        public Guid AllergyId { get; set; }
        public required Allergy Allergy { get; set; }
        public Guid ProductExtraToppingId { get; set; }
        public required ProductExtraTopping ProductExtraTopping { get; set; }
    }
}