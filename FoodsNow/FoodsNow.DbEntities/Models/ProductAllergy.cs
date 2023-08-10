namespace FoodsNow.DbEntities.Models
{
    public class ProductAllergy : BaseEntity
    {
        public Guid AllergyId { get; set; }
        public required Allergy Allergy { get; set; }
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
    }
}