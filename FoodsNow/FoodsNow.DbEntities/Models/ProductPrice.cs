namespace FoodsNow.DbEntities.Models
{
    public class ProductPrice : BaseEntity
    {
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
        
    }
}
