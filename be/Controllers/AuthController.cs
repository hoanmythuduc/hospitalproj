using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using THUCTAP.Models; 

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IUserRepository userRepository, IConfiguration configuration)
        {
            _authService = authService;
            _userRepository = userRepository;
            _configuration = configuration;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            
            var user = _userRepository.GetUserByCredentials(request.userName, request.password);

            if (user == null)
            {
                return Unauthorized(new { Message = "Tài khoản hoặc mật khẩu không chính xác!" });
            }

            
            var allAllowedMenus = user.group
                .SelectMany(g => g.menu)
                .DistinctBy(m => m.id)
                .ToList();

            var allAllowedActions = user.group
                .SelectMany(g => g.action)
                .DistinctBy(a => a.id)
                .ToList();

            var userPermissions = allAllowedMenus.Select(m => new PermissionDto
            {
                menuId = m.id,
                menuLabel = m.label,
                parentLabel = m.parent != null ? m.parent.label : null,
                action = allAllowedActions
                                .Where(a => a.menuId == m.id)
                                .Select(a => new ActionSummaryDto
                                {
                                    actionId = a.id,
                                    actionLabel = a.label
                                })
                                .ToList()
            }).ToList();
            var tokenString = GenerateJwtToken(user);

           
            return Ok(new
            {
                Message = "Đăng nhập thành công!",
                
                Data = new
                {
                    id = user.id,
                    username = user.userName,
                    userCode = user.userCode,
                    department = user.department,
                    token = tokenString,
                    permissions = userPermissions
                }
            });
        }
       
        private string GenerateJwtToken(User user)
        {
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

           
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.userName),
        new Claim("userId", user.id.ToString()),
        new Claim("userCode", user.userCode ?? ""),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

           
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2), 
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}