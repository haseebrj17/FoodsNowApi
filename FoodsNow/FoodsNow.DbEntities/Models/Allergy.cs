﻿namespace FoodsNow.DbEntities.Models
{
    public class Allergy : BaseEntity
    {
        public required string Description { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
