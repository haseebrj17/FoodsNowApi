namespace FoodsNow.DbEntities.Models
{
    public class CustomerAddress : BaseEntity
    {
        public required string StreetAddress { get; set; }
        public required string House { get; set; }
        public required string PostalCode { get; set; }
        public string? District { get; set; }
        public string? UnitNumber { get; set; }
        public string? FloorNumber { get; set; }
        public string? Notes { get; set; }
        public bool IsDefault { get; set; }
        public string? Tag { get; set; }
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public Guid CityId { get; set; }
        public required City City { get; set; }
        public Guid CustomerId { get; set; }
        public required Customer Customer { get; set; }
    }
}
