using Microsoft.IdentityModel.Tokens;
using onlatn_tv_project.AllDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace onlatn_tv_project.Services
{
    public class JwtService
    {
        private readonly string userName;
        private readonly string password;
        private readonly string secretKey;
        private readonly string issuer;
        private readonly string audience;
        private readonly int tokenLifetime;
        public JwtService(string userName, string password, string secretKey, string issuer, string audience, int tokenLifetime)
        {
            this.userName = userName;
            this.password = password;
            this.secretKey = secretKey;
            this.issuer = issuer;
            this.audience = audience;
            this.tokenLifetime = tokenLifetime;
        }

        public object GenerateToken(LoginDTO model)
        {
            if (!model.Username.Equals(userName) || !model.Password.Equals(password)) // && => || ni o'zgartirdim
            {
                throw new Exception("Username yoki parol noto'g'ri");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, "Admin") // Faqat adminlar uchun
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(tokenLifetime),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public object Logout()
        {
            throw new NotImplementedException();
        }
    }
}
