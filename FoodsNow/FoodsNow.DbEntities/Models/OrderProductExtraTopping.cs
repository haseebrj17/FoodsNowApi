﻿namespace FoodsNow.DbEntities.Models
{
    public class OrderProductExtraTopping : BaseEntity
    {
        public string? Name { get; set; }
        public string? PriceDetail { get; set; }
        public Guid ProductExtraDippingId { get; set; }               
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid OrderProductId { get; set; }
    }
}
