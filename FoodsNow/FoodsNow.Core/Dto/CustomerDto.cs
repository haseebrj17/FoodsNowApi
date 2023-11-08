using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Core.Dto
{
    public class CustomerDto
    {
        public Guid? Id { get; set; }
        public required string FullName { get; set; }
        public required string EmailAdress { get; set; }
        public required string ContactNumber { get; set; }
        public string? Code { get; set; }
        public UserRole? UserRole { get; set; }
    }
}
