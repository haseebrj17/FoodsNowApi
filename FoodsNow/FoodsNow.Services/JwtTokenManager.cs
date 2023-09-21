using Azure.Core;
using FoodsNow.Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodsNow.Services
{
    public interface IJwtTokenManager
    {
        public string GenerateToken(CustomerDto customer);
        public CustomerDto? ValidateToken(string token);
        public CustomerDto? GetCustomer(HttpRequestData httpRequest);
    }
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly string JwtValidIssuer = "https://foodsnowdevapi.azurewebsites.net";
        private readonly string JwtValidAudience = "https://foodsnowdevapi.azurewebsites.net";
        private readonly string JwtSecret = "2B757F3F930742D88A220";
        public string GenerateToken(CustomerDto customer)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: JwtValidIssuer,
                audience: JwtValidAudience,
                claims: new List<Claim>() {
                    new Claim(nameof(customer.Id), customer.Id.Value.ToString()),
                    new Claim(nameof(customer.FullName), customer.FullName.ToString()),
                    new Claim(nameof(customer.EmailAdress), customer.EmailAdress.ToString()),
                    new Claim(nameof(customer.ContactNumber), customer.ContactNumber.ToString()),
                },
                expires: DateTime.Now.AddDays(365),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }


        public CustomerDto? GetCustomer(HttpRequestData request)
        {
            if (!request.Headers.ContainsKey("Authorization"))
            {                
                return null;
            }

            string authorizationHeader = request.Headers["Authorization"].ToString();

            // Check if the value is empty.
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return null;
            }

            //if (httpContextAccessor.HttpContext == null) throw new UnAuthrozedException();

            //if (!httpContextAccessor.HttpContext.User.Claims.Any()) throw new UnAuthrozedException();

            //var customer = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Customer");

            //if (customer == null) throw new UnAuthrozedException();

            //var claim = customer.Value;

            //var appUser = JsonConvert.DeserializeObject<CustomerDto>(claim);

            //if (appUser == null) throw new UnAuthrozedException();

            //return appUser;
            return null;
        }

        public CustomerDto? ValidateToken(string token)
        {
            if (token == null)
                return null;

            token = token.Replace("Bearer ", "");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSecret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var user = JsonConvert.DeserializeObject<CustomerDto>(jwtToken.Claims.First(x => x.Type == "Customer").Value);

                // return user id from JWT token if validation successful
                return user;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
    public class UnAuthrozedException : Exception
    {
        public UnAuthrozedException() : base() { }

        public override string StackTrace
        {
            get { return "401 Unauthorized Access!"; }
        }
    }
}
