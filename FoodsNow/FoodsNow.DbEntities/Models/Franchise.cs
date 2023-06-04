﻿namespace FoodsNow.DbEntities.Models
{
    public class Franchise : BaseEntity
    {
        public required string Title { get; set; }
        public required string Address { get; set; }
        public required string ZipCode { get; set; }
        public required string ContactNumber { get; set; }
        public required string OpeningTime { get; set; }
        public required string ClosingTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsOffToday { get; set; }
        public DateTime? OffFrom { get; set; }
        public DateTime? OffTo { get; set; }
        public Guid StateId { get; set; }
        public required State State { get; set; }
        public Guid CountryId { get; set; }
        public required Country Country { get; set; }
        public Guid CityId { get; set; }
        public required City City { get; set; }
    }
}
