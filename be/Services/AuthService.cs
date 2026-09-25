using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using Microsoft.Extensions.Logging; // 👉 Bổ sung thư viện Logging

namespace THUCTAP.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;
        private readonly ILogger<AuthService> _logger; // 👉 Khai báo Logger

        // 👉 Tiêm ILogger vào Constructor
        public AuthService(IConfiguration config, IUserRepository userRepo, ILogger<AuthService> logger)
        {
            _config = config;
            _userRepo = userRepo;
            _logger = logger;
        }

        public LoginResponse? Authenticate(LoginRequest request)
        {
            try
            {
                User? user = _userRepo.GetUserByCredentials(request.userName, request.password);

                if (user == null)
                {
                    // 👉 Ghi log cảnh báo khi đăng nhập sai tài khoản/mật khẩu
                    _logger.LogWarning("Cảnh báo bảo mật: Đăng nhập thất bại. Tài khoản hoặc mật khẩu không đúng đối với User: {Username}", request.userName);
                    return null;
                }

                string token = GenerateJSONWebToken(user.userName);
                
                // 👉 Ghi log thông báo đăng nhập thành công
                _logger.LogInformation("Đăng nhập thành công. User: {Username} (ID: {UserId})", user.userName, user.id);

                return new LoginResponse()
                {
                    token = token,
                    userId = user.id            
                };
            }
            catch (Exception ex)
            {
                // 👉 Bắt lỗi hệ thống (ví dụ: đứt cáp, sập DB lúc đang login)
                _logger.LogError(ex, "Lỗi hệ thống nghiêm trọng khi xử lý đăng nhập cho User: {Username}", request.userName);
                throw;
            }
        }

        private string GenerateJSONWebToken(string username)
        {
            try
            {
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
                SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                Claim[] claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim("username", username),
                    //new Claim("userid", userid.ToString())
                };

                JwtSecurityToken token = new JwtSecurityToken(
                  issuer: _config["Jwt:Issuer"],
                  audience: _config["Jwt:Audience"],
                  claims: claims,
                  expires: DateTime.UtcNow.AddMinutes(30),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                // 👉 Bắt lỗi nếu file appsettings.json bị mất cấu hình Jwt:Key
                _logger.LogError(ex, "Lỗi khi khởi tạo Token JWT cho User: {Username}. Vui lòng kiểm tra lại cấu hình JWT trong appsettings.json.", username);
                throw;
            }
        }
    }
}