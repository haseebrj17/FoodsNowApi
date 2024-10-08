﻿namespace FoodsNow.DbEntities.Models
{
    public class DishOfDay : BaseEntity
    {
        public required string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime Validity { get; set; }
        public Guid? ProductId { get; set; }
        public Guid FranchiseId { get; set; }
        public int Sequence { get; set; } = 0;
        public required Franchise Franchise { get; set; }
    }
}
