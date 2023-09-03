﻿namespace FoodsNow.Core.Dto
{
    public class CustomerAddressDto
    {
        public Guid? Id { get; set; }
        public required string StreetAddress { get; set; }
        public required string House { get; set; }
        public string? District { get; set; }
        public string? UnitNumber { get; set; }
        public string? FloorNumber { get; set; }
        public string? Notes { get; set; }
        public string? Tag { get; set; }
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public Guid CityId { get; set; }
    }
}