namespace FoodsNow.Core.Dto
{
    public class OrderProductDto
    {
        public int Quantity { get; set; }
        public Guid? OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductPriceId { get; set; }

        public List<OrderProductExtraDippingDto>? ProductExtraDippings { get; set; }
        public List<OrderProductExtraToppingDto>? ProductExtraToppings { get; set; }
    }
}
