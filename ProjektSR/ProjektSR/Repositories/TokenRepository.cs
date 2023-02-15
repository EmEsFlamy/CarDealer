using Microsoft.IdentityModel.Tokens;
using ProjektSR.Interfaces;
using ProjektSR.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjektSR.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        public static readonly SymmetricSecurityKey SecretKey = 
            new(Encoding.UTF8.GetBytes("wqWLEYfsB7DsvmPs5Gxhk8mdDBNLNQ6yQYD@345"));
        public string CreateToken(User user)
        {
            var signinCredentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7160",
                audience: "https://localhost:7160",
                claims: GetUserClaims(user),
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
        private static List<Claim> GetUserClaims(User user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
        }
    }
}
