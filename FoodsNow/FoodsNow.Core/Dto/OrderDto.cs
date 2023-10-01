using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Core.Dto
{
    public class OrderDto
    {
        public Guid? Id { get; set; }
        public decimal TotalBill { get; set; }
        public int TotalItems { get; set; }
        public DateTime OrderDeliveryDateTime { get; set; }
        public string? Instructions { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid CustomerAddressId { get; set; }
        public Guid FranchiseId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        private string? _Status;
        public string Status
        {
            get { return OrderStatus.ToString(); }
            set { _Status = value; }
        }
        public CustomerAddressDto? CustomerAdress { get; set; }
        public List<OrderProductDto>? OrderProducts { get; set; }
    }
}
