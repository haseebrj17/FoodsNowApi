﻿namespace FoodsNow.DbEntities.Models
{
    public class OrderProductExtraDipping : BaseEntity
    {
        public string? Name { get; set; }
        public string? PriceDetail { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }        
        public Guid ProductExtraDippingId { get; set; }
        public Guid OrderProductId { get; set; }
    }
}
