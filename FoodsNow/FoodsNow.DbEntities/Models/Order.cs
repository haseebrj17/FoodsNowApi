using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.DbEntities.Models
{
    public class Order : BaseEntity
    {
        public decimal TotalBill { get; set; }
        public int TotalItems { get; set; }
        public DateTime OrderDeliveryDateTime { get; set; }
        public string? Instructions { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Guid CustomerAddressId { get; set; }
        public CustomerAddress? CustomerAdress { get; set; }
        public Guid FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }
        public OrderStatus OrderStatus { get; set; }        
        public List<OrderProduct>? OrderProducts { get; set; }
    }
}