namespace FoodsNow.Core.Dto
{
    public class OrderProductExtraToppingDto
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? PriceDetail { get; set; }
        public decimal? UnitPrice { get; set; }
        public Guid? OrderProductId { get; set; }
        public Guid ProductExtraToppingPriceId { get; set; }
        public Guid ProductExtraToppingId { get; set; }
    }
}
