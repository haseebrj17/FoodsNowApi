namespace FoodsNow.DbEntities.Models
{
    public class Client : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAdress { get; set; }
        public required string Password { get; set; }
        public required string Address { get; set; }
        public required string AppLogo { get; set; }
        public required string WebsiteLogo { get; set; }
        public required string Slogon { get; set; }
        public required string ZipCode { get; set; }
        public required string ContactNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime MembershipValidityDate { get; set; }
        public int NumberOfFranchisesAllowed { get; set; }
    }
}
