using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByCredentials(string username, string password);
        Task<bool>UserCodeExistsAsync(string userCode);
        Task<User?>GetUserByIdWithGroupsAsync(int id);
        Task<User?>GetUserWithFullPermissionsAsync(int userId);
        Task<List<Group>>GetGroupsByIdsAsync(List<int> groupIds);

        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);

        Task<List<User>>GetDeletedUsersAsync();
        Task<User?>GetDeletedUserByIdAsync(int id);
        Task<List<UserResponseDto>>GetAllUsersWithPermissionsAsync();
        Task<PagedResult<UserResponseDto>>GetAllUsersAsync(UserFilterRequest filter);
        Task<List<string>>GetAllDepartmentsAsync();
    }
}