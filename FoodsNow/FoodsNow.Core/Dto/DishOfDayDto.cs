using System;
using Newtonsoft.Json;

namespace FoodsNow.Core.Dto
{
    public class DishOfDayDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime Validity { get; set; }
        public Guid? ProductId { get; set; }
        public int Sequence { get; set; }
    }
}

