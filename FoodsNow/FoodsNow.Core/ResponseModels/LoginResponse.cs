namespace FoodsNow.Core.ResponseModels
{
    public class LoginResponse
    {
        public bool IsLoggedIn { get; set; }
        public bool IsNumberVerified { get; set; }
        public string? Token { get; set; }
    }
}
