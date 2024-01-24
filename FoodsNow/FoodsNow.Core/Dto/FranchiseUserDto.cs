using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Core.Dto
{
    public class FranchiseUserDto
    {
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        public UserRole UserRole { get; set; }

        public bool IsActive { get; set; }

        public Guid FranchiseId { get; set; }

        public string FranchiseName { get; set; } = null!;
    }
}