using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace FoodsNow.DbEntities.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Cover { get; set; } = null!;

        [Required]
        public string Thumbnail { get; set; } = null!;

        [Required]
        public int Sequence { get; set; } = 0;

        public string? Logo { get; set; }

        public string? Description { get; set; }

        public string? Color { get; set; }

        public bool IsVisibleOnDashboard { get; set; }

        public bool IsVisibleOnCheckOut { get; set; }

        public bool IsVisibleOnCart { get; set; }

        public bool IsBrand { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public Guid FranchiseId { get; set; }

        public List<SubCategory> SubCategory { get; set; } = new List<SubCategory>();
    }

    public class SubCategory : BaseEntity
    {
        public string Name { get; set; } = null!;

        public Guid ParentId { get; set; }

        public Guid FranchiseId { get; set; }

        public string Cover { get; set; } = null!;

        public string Thumbnail { get; set; } = null!;

        public int Sequence { get; set; } = 0;

        public string? Description { get; set; }

        public string? Color { get; set; }

        public bool IsVisibleOnDashboard { get; set; }

        public bool IsVisibleOnCheckOut { get; set; }

        public bool IsVisibleOnCart { get; set; }

        public bool IsActive { get; set; }
    }
}
