namespace FoodsNow.DbEntities.Models
{
    public class OrderProductExtraDipping : BaseEntity
    {
        public required string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }        
        public Guid ProductExtraDippingId { get; set; }
        public Guid OrderProductId { get; set; }
    }
}
