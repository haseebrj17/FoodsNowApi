namespace FoodsNow.DbEntities.Models
{
    public class ProductExtraToppingPrice : BaseEntity
    {
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public Guid ProductExtraToppingId { get; set; }
        public required ProductExtraTopping ProductExtraTopping { get; set; }
        
    }
}
