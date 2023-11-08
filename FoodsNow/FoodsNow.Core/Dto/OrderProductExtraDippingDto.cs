namespace FoodsNow.Core.Dto
{
    public class OrderProductExtraDippingDto
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public Guid ProductExtraDippingId { get; set; }
        public Guid ProductExtraDippingPriceId { get; set; }
        public Guid? OrderProductId { get; set; }
    }
}
