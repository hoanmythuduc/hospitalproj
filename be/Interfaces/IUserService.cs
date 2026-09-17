using System.Threading.Tasks;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IUserService
    {
        Task<User>CreateUserAsync(UserCreateRequest request);
        Task<User>UpdateUserAsync(int id, UserCreateRequest request);
        Task<bool>DeleteUserAsync(int id);
        Task<List<User>>GetDeletedUsersAsync();
        Task<bool>RestoreUserAsync(int id);
        Task<List<MenuResponse>>GetUserMenusAsync(int userId);
        Task<List<UserResponseDto>>GetAllUsersWithPermissionsAsync();
        Task<PagedResult<UserResponseDto>>GetAllUsersAsync(UserFilterRequest filter);
        Task<List<string>>GetAllDepartmentsAsync();

    }
}