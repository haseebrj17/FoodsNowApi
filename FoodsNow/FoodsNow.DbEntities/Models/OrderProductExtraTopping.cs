namespace FoodsNow.DbEntities.Models
{
    public class OrderProductExtraTopping : BaseEntity
    {        
        
        public Guid ProductExtraDippingId { get; set; }               
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid OrderProductId { get; set; }
        public required OrderProduct OrderProduct { get; set; }
        public Guid ProductExtraToppingPriceId { get; set; }
        public required ProductExtraToppingPrice ProductExtraToppingPrice { get; set; }
    }
}
