namespace FoodsNow.DbEntities.Models
{
    public class ProductCategory : BaseEntity
    {
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
        public Guid CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
