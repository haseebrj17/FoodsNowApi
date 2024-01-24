using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.DbEntities.Models
{
    public class Franchise : BaseEntity
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string ZipCode { get; set; } = null!;

        [Required]
        public string ContactNumber { get; set; } = null!;

        [Required]
        public string OpeningTime { get; set; } = null!;

        [Required]
        public string ClosingTime { get; set; } = null!;

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public float CoverageAreaInMeters { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public Guid CityId { get; set; }

        [Required]
        public string CityName { get; set; } = null!;

        [Required]
        public Guid StateId { get; set; }

        [Required]
        public string StateName { get; set; } = null!;

        public List<FranchiseTiming> FranchiseTimings { get; set; } = new List<FranchiseTiming>();

        public List<FranchiseHoliday> FranchiseHolidays { get; set; } = new List<FranchiseHoliday>();

        public List<DishOfDay> DishOfDay { get; set; } = new List<DishOfDay>();

        public List<Banner> Banner { get; set; } = new List<Banner>();

        [Required]
        public List<FranchiseSetting> FranchiseSetting { get; set; } = new List<FranchiseSetting>();

        public List<Discounts> Discounts { get; set; } = new List<Discounts>();
    }

    public class FranchiseTiming : BaseEntity
    {
        [Required]
        public string Day { get; set; } = null!;

        [Required]
        public TimeSpan OpeningTime { get; set; }

        [Required]
        public TimeSpan ClosingTime { get; set; }

        [Required]
        public bool Open { get; set; } = true;

        [Required]
        public List<ServingTimings> ServingTimings { get; set; } = new List<ServingTimings>();
    }

    public class ServingTimings : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public List<ServingTime> ServingTime { get; set; } = new List<ServingTime>();
    }

    public class ServingTime : BaseEntity
    {
        [Required]
        public TimeSpan SlotStart { get; set; }

        [Required]
        public TimeSpan SlotEnd { get; set; }
    }

    public class FranchiseHoliday : BaseEntity
    {
        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }
    }

    public class DishOfDay : BaseEntity
    {
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime Validity { get; set; }

        [Required]
        public Guid? ProductId { get; set; }

        [Required]
        public int Sequence { get; set; } = 0;
    }

    public class Banner : BaseEntity
    {
        [Required]
        public string ImageUrl { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public int Sequence { get; set; } = 0;

        public DateTime Validity { get; set; }

        public Guid? BrandId { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? CategoryId { get; set; }
    }

    public class FranchiseSetting : BaseEntity
    {
        [Required]
        public List<ServingDays> ServingDays { get; set; } = new List<ServingDays>();
    }

    public class ServingDays : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;
    }

    public class Discounts : BaseEntity
    {
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
