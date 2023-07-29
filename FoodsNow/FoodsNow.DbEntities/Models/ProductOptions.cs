namespace FoodsNow.DbEntities.Models
{
    public class ProductOptions : BaseEntity
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
    }
}
