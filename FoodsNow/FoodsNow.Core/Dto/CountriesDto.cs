using System;
using Newtonsoft.Json;

namespace FoodsNow.Core.Dto
{
    public class CountryDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public List<StateDto> States { get; set; } = new List<StateDto>();
    }

    public class StateDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public List<CityNameDto> Cities { get; set; } = new List<CityNameDto>();
    }

    public class CityNameDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
    }
}

