namespace FoodsNow.DbEntities.Models
{
    public class ProductExtraDippingAllergy : BaseEntity
    {
        public Guid AllergyId { get; set; }
        public required Allergy Allergy { get; set; }
        public Guid ProductExtraDippingId { get; set; }
        public required ProductExtraDipping ProductExtraDipping { get; set; }
    }
}