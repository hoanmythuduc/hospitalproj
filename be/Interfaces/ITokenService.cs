using THUCTAP.Models;

namespace THUCTAP.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}