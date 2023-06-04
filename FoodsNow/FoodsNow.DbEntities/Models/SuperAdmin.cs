namespace FoodsNow.DbEntities.Models
{
    public class SuperAdmin : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAdress { get; set; }
        public required string Password { get; set; }
    }
}
