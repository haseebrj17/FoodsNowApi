﻿namespace FoodsNow.DbEntities.Models
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Detail { get; set; }
        public required string IngredientSummary { get; set; }
        public required string IngredientDetail { get; set; }
        public required string Image { get; set; }        
        public bool IsActive { get; set; }
        public bool showExtraTropping { get; set; }
        
    }
}
