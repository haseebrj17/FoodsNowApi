using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FoodsNow.DbEntities.Models
{
    public class Client : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string AppLogo { get; set; } = null!;

        [Required]
        public string WebsiteLogo { get; set; } = null!;

        [Required]
        public string Slogon { get; set; } = null!;

        [Required]
        public string ZipCode { get; set; } = null!;

        [Required]
        public string ContactNumber { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime MembershipValidityDate { get; set; }

        [Required]
        public int NumberOfFranchisesAllowed { get; set; }

        public List<ClientFranchises> ClientFranchises { get; set; } = new List<ClientFranchises>();
    }

    public class ClientFranchises
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
    }
}
