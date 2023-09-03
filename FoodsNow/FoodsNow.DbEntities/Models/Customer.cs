﻿namespace FoodsNow.DbEntities.Models
{
    public class Customer : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAdress { get; set; }
        public required string Password { get; set; }
        public required string ContactNumber { get; set; }
        public required string VerificationCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsNumberVerified { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}
