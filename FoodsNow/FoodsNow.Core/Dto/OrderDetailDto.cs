namespace FoodsNow.Core.Dto
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public decimal TotalBill { get; set; }
        public int TotalItems { get; set; }
        public DateTime OrderDeliveryDateTime { get; set; }
        public string? Instructions { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid CustomerAddressId { get; set; }
        public Guid FranchiseId { get; set; }
        public required string OrderStatus { get; set; }
        public required CustomerAddressDto CustomerAdress { get; set; }
        public required List<OrderDetailProductDto> Products { get; set; }
    }

    public class OrderDetailProductDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int Quanity { get; set; }
        public decimal Price { get; set; }
        public  List<OrderDetailProductExtraDto>? ExtraDippingProducts { get; set; }
        public  List<OrderDetailProductExtraDto>? ExtraToppingProducts { get; set; }
    }

    public class OrderDetailProductExtraDto
    {
        public required string Name { get; set; }
        public int Quanity { get; set; }
        public decimal Price { get; set; }
    }
}
