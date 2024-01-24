using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Core.Dto
{
    public class FranchiseDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string ZipCode { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string OpeningTime { get; set; } = null!;

        public string ClosingTime { get; set; } = null!;

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public float CoverageAreaInMeters { get; set; }

        public bool IsActive { get; set; }

        public Guid ClientId { get; set; }

        public Guid CityId { get; set; }

        public string CityName { get; set; } = null!;

        public Guid StateId { get; set; }

        public string StateName { get; set; } = null!;

        public List<FranchiseTimingDto> FranchiseTimings { get; set; } = new List<FranchiseTimingDto>();

        public List<FranchiseHolidayDto> FranchiseHolidays { get; set; } = new List<FranchiseHolidayDto>();

        public List<DishOfDayDto> DishOfDay { get; set; } = new List<DishOfDayDto>();

        public List<BannerDto> Banner { get; set; } = new List<BannerDto>();

        public List<FranchiseSettingDto> FranchiseSetting { get; set; } = new List<FranchiseSettingDto>();

        public List<DiscountsDto> Discounts { get; set; } = new List<DiscountsDto>();
    }

    public class FranchiseTimingDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Day { get; set; } = null!;

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }

        public bool Open { get; set; } = true;

        public List<ServingTimingsDto> ServingTimings { get; set; } = new List<ServingTimingsDto>();
    }

    public class FranchiseHolidayDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }

    public class FranchiseSettingDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public List<ServingDaysDto> ServingDays { get; set; } = new List<ServingDaysDto>();
    }

    public class ServingDaysDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
    }

    public class ServingTimingsDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public List<ServingTimeDto> ServingTime { get; set; } = new List<ServingTimeDto>();
    }

    public class ServingTimeDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public TimeSpan SlotStart { get; set; }

        public TimeSpan SlotEnd { get; set; }
    }

    public class DiscountsDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public double Percent { get; set; }

        public string Eligibility { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public DiscountType Type { get; set; }

        public string Conditions { get; set; } = null!;
    }
}