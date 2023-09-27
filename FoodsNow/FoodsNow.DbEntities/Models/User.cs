using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.DbEntities.Models
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAdress { get; set; }
        public required string Password { get; set; }
        public required UserRole UserRole { get; set; }
        public bool IsActive { get; set; }
        public Guid FranchiseId { get; set; }
        public required Franchise Franchise { get; set; }
    }
}
