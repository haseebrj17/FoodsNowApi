namespace FoodsNow.Core.Dto
{
    public class OrderDto
    {
        public Guid? Id { get; set; }
        public decimal? TotalBill { get; set; }
        public string? Instructions { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CustomerAddressId { get; set; }
        public Guid FranchiseId { get; set; }
        public required List<OrderProductDto> Products { get; set; }
    }
}
