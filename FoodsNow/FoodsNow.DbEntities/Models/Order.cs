using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.DbEntities.Models
{
    public class Order : BaseEntity
    {
        public decimal TotalBill { get; set; }
        public int TotalItems { get; set; }
        public string? Instructions { get; set; }
        public Guid CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public Guid CustomerAddressId { get; set; }
        public required CustomerAddress CustomerAdress { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
