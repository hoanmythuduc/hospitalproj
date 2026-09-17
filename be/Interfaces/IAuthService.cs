using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IAuthService
    {
        LoginResponse? Authenticate(LoginRequest request);
    }
}