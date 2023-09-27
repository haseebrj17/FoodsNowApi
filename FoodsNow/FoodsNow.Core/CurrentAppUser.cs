using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Core
{
    public class CurrentAppUser
    {
        public Guid? Id { get; set; }
        public Guid? FranchiseId { get; set; }
        public required string FullName { get; set; }
        public required string EmailAdress { get; set; }
        public string? Password { get; set; }
        public required string ContactNumber { get; set; }
        public string? VerificationCode { get; set; }
        public UserRole? UserRole { get; set; }
    }
}
