namespace FoodsNow.DbEntities.Models
{
    public class OrderProduct : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public required Order Order { get; set; }
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
        public Guid ProductPriceId { get; set; }
        public required ProductPrice ProductPrice { get; set; }
        public List<OrderProductExtraDipping>? OrderProductExtraDippings { get; set; }
        public List<OrderProductExtraTopping>? OrderProductExtraToppings { get; set; }
    }
}
