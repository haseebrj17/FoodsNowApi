namespace FoodsNow.Core.Dto
{
    public class OrderProductExtraToppingDto
    {
        public int Quantity { get; set; }
        public Guid OrderProductId { get; set; }
        public Guid ProductExtraToppingPriceId { get; set; }
        public Guid ProductExtraToppingId { get; set; }
    }
}
