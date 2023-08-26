namespace FoodsNow.DbEntities.Models
{
    public class Order : BaseEntity
    {
        public decimal TotalBill { get; set; }
        public string? Intructions { get; set; }
        public Guid CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public Guid CustomerAddressId { get; set; }
        public required CustomerAdress CustomerAdress { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
