using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FoodsNow.DbEntities.Models
{
    public class Country : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public List<State> States { get; set; } = new List<State>();
    }

    public class State : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public List<CityName> Cities { get; set; } = new List<CityName>();
    }

    public class CityName : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
    }
}
