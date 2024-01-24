using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FoodsNow.Core.Dto
{
    public class CategoryDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Cover { get; set; } = null!;

        public string Thumbnail { get; set; } = null!;

        public string? Logo { get; set; }

        public string? Description { get; set; }

        public Guid FranchiseId { get; set; }

        public List<SubCategoryDto> SubCategory { get; set; } = null!;
    }

    public class SubCategoryDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public Guid ParentId { get; set; }

        public Guid FranchiseId { get; set; }

        public string Cover { get; set; } = null!;

        public string Thumbnail { get; set; } = null!;

        public string? Description { get; set; }
    }
}
