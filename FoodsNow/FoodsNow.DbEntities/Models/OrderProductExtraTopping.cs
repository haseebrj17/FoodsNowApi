namespace FoodsNow.DbEntities.Models
{
    public class OrderProductExtraTopping : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid OrderProductId { get; set; }
        public required OrderProduct OrderProduct { get; set; }
    }
}
