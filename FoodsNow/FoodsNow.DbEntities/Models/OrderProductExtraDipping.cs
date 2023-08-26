namespace FoodsNow.DbEntities.Models
{
    public class OrderProductExtraDipping : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }        
        public Guid OrderProductId { get; set; }
        public required OrderProduct OrderProduct { get; set; }
    }
}
