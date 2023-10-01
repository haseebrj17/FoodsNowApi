namespace FoodsNow.Core.Dto
{
    public class OrderProductDto
    {
        public int Quantity { get; set; }
        public Guid? OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductPriceId { get; set; }

        public List<OrderProductExtraDippingDto>? OrderProductExtraDippings { get; set; }
        public List<OrderProductExtraToppingDto>? OrderProductExtraToppings { get; set; }
    }
}
