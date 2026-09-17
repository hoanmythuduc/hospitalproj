using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using THUCTAP.Interfaces;
using THUCTAP.Models;

namespace THUCTAP.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _config = config;
            // Lấy Secret Key từ appsettings.json
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        }

        public string GenerateToken(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User không được phép null khi in Token");
            }
            // 1. Tạo các "Claims" (Thông tin đính kèm vào Token)
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.userName),
                new Claim("UserCode", user.userCode) // Có thể thêm các claim tùy chỉnh
            };

            // Nếu user có chứa Groups, có thể lặp qua và thêm Claim Role ở đây
            // if (user.groups != null)
            // {
            //     foreach (var group in user.groups)
            //     {
            //         claims.Add(new Claim(ClaimTypes.Role, group.code));
            //     }
            // }

            // 2. Tạo chữ ký (Credentials)
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            // 3. Thiết lập thông số của Token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // Token có hạn trong 7 ngày
                SigningCredentials = creds,
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"]
            };

            // 4. Tạo và trả về chuỗi Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}