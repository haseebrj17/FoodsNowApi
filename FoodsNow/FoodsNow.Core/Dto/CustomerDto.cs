namespace FoodsNow.Core.Dto
{
    public class CustomerDto
    {
        public Guid? Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAdress { get; set; }
        public required string Password { get; set; }
        public required string ContactNumber { get; set; }
        public required string VerificationCode { get; set; }
    }
}
