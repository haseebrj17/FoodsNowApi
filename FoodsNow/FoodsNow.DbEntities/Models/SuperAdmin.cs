using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FoodsNow.DbEntities.Models
{
    public class SuperAdmin : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = "";

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;
    }
}

