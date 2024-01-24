using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FoodsNow.DbEntities.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedDateTimeUtc { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDateTimeUtc { get; set; }

        [Required]
        public Guid CreatedById { get; set; } = Guid.Parse("8446a68c-8287-450a-b727-7646365b62d8");

        public Guid UpdatedById { get; set; }
    }
}