using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;

        public AuthService(IConfiguration config, IUserRepository userRepo)
        {
            _config = config;
            _userRepo = userRepo;
        }

        public LoginResponse? Authenticate(LoginRequest request)
        {
            User? user = _userRepo.GetUserByCredentials(request.userName, request.password);

            if (user == null)
            {
                return null;
            }

            string token = GenerateJSONWebToken(user.userName);
            return new LoginResponse()
            {
                token = token,
                userId = user.id            };
        }

        private string GenerateJSONWebToken(string username)
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
    }
}