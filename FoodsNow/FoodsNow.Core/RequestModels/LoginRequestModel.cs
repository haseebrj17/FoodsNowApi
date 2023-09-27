namespace FoodsNow.Core.RequestModels
{
    public class LoginRequestModel
    {
        public required string EmailAdress { get; set; }
        public required string Password { get; set; }
    }
}
