using FoodsNow.Core.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Azure.Functions.Worker.Http;
using static FoodsNow.Core.Enum.Enums;
using FoodsNow.Core;

namespace FoodsNow.Services
{
    public interface IJwtTokenManager
    {
        public string GenerateToken(CurrentAppUser user);
        public CurrentAppUser? ValidateToken(HttpRequestData req, UserRole requiredRole);
    }
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly string JwtValidIssuer = "https://foodsnowdevapi.azurewebsites.net";
        private readonly string JwtValidAudience = "https://foodsnowdevapi.azurewebsites.net";
        private readonly string JwtSecret = "2B757F3F930742D88A220";
        public string GenerateToken(CurrentAppUser user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: JwtValidIssuer,
                audience: JwtValidAudience,
                claims: new List<Claim>() {
                    new Claim(nameof(user.Id), (user.Id ?? Guid.NewGuid()).ToString()),
                    new Claim(nameof(user.FullName), user.FullName.ToString()),
                    new Claim(nameof(user.EmailAdress), user.EmailAdress.ToString()),
                    new Claim(nameof(user.ContactNumber), user.ContactNumber.ToString()),
                    new Claim(nameof(user.ContactNumber), user.ContactNumber.ToString()),
                    new Claim(nameof(user.UserRole), (user.UserRole ?? UserRole.Customer).ToString()),
                    new Claim(nameof(user.FranchiseId), (user.FranchiseId ?? Guid.NewGuid()).ToString()),
                },
                expires: DateTime.Now.AddDays(365),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }

        public CurrentAppUser? ValidateToken(HttpRequestData req, UserRole requiredRole)
        {
            var authorizationHeader = req.Headers.FirstOrDefault(h => h.Key == "Authorization");

            // Check if the value is empty.
            if (authorizationHeader.Equals(default(KeyValuePair<string, IEnumerable<string>>)))
            {
                return null;
            }
            if (string.IsNullOrEmpty(authorizationHeader.Value.FirstOrDefault()))
            {
                return null;
            }

            var token = authorizationHeader.Value.First();

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

                var currentAppUser = new CurrentAppUser()
                {
                    Id = new Guid(jwtToken.Claims.First(x => x.Type == nameof(CurrentAppUser.Id)).Value),
                    FranchiseId = new Guid(jwtToken.Claims.First(x => x.Type == nameof(CurrentAppUser.FranchiseId)).Value),
                    ContactNumber = jwtToken.Claims.First(x => x.Type == nameof(CurrentAppUser.ContactNumber)).Value,
                    EmailAdress = jwtToken.Claims.First(x => x.Type == nameof(CurrentAppUser.EmailAdress)).Value,
                    UserRole = Enum.Parse<UserRole>(jwtToken.Claims.First(x => x.Type == nameof(CurrentAppUser.UserRole)).Value),
                    FullName = jwtToken.Claims.First(x => x.Type == nameof(CurrentAppUser.FullName)).Value
                };

                return currentAppUser;
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
