﻿namespace FoodsNow.Core.RequestModels
{
    public class LoginRequestModel
    {
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
        public string? DeviceToken { get; set; }
    }
}
