using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using Microsoft.Extensions.Logging; // 👉 Bổ sung thư viện Logging
using System;
using System.Collections.Generic;

namespace THUCTAP.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly ILogger<TokenService> _logger; // 👉 Khai báo Logger

        // 👉 Tiêm ILogger vào Constructor
        public TokenService(IConfiguration config, ILogger<TokenService> logger)
        {
            _config = config;
            _logger = logger;
            
            try
            {
                // Lấy Secret Key từ appsettings.json
                var secretKey = _config["Jwt:Key"] ?? string.Empty;
                _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            }
            catch (Exception ex)
            {
                // 👉 Ghi log nếu file cấu hình appsettings.json bị thiếu hoặc sai chuẩn Jwt:Key
                _logger.LogError(ex, "Lỗi nghiêm trọng khi khởi tạo chữ ký Secret Key cho JWT. Vui lòng kiểm tra lại 'Jwt:Key' trong appsettings.json.");
                throw;
            }
        }

        public string GenerateToken(User user)
        {
            try
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
                    new Claim("UserCode", user.userCode ?? "") // Có thể thêm các claim tùy chỉnh
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
            catch (Exception ex)
            {
                // 👉 Ghi log chi tiết Token đang được gen cho User nào thì bị lỗi
                _logger.LogError(ex, "Lỗi khi khởi tạo Token JWT cho User: {UserName} (ID: {UserId})", user?.userName ?? "Unknown", user?.id);
                throw;
            }
        }
    }
}