using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User>CreateUserAsync(UserCreateRequest request)
        {
            var exists = await _userRepository.UserCodeExistsAsync(request.userCode);
            if (exists)
            {
                throw new Exception($"Mã nhân viên {request.userCode} đã tồn tại trong hệ thống.");
            }

            var newUser = request.ToUser();

            if (request.groupId != null && request.groupId.Any())
            {
                newUser.group = await _userRepository.GetGroupsByIdsAsync(request.groupId);
            }

            // Gọi Repository và lưu luôn
            await _userRepository.CreateUserAsync(newUser);

            return newUser;
        }

        public async Task<User>UpdateUserAsync(int id, UserCreateRequest request)
        {
            var user = await _userRepository.GetUserByIdWithGroupsAsync(id);
            if (user == null) return null;

            user.UpdateUser(request);
            user.group.Clear();

            if (request.groupId != null && request.groupId.Any())
            {
                var newGroups = await _userRepository.GetGroupsByIdsAsync(request.groupId);
                foreach (var group in newGroups)
                {
                    user.group.Add(group);
                }
            }

            // Gọi Repository và lưu luôn
            await _userRepository.UpdateUserAsync(user);

            return user;
        }

        public async Task<bool>DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdWithGroupsAsync(id);
            if (user == null) return false;

            await _userRepository.DeleteUserAsync(user);

            return true;
        }
        public async Task<List<User>> GetDeletedUsersAsync()
        {
            return await _userRepository.GetDeletedUsersAsync();
        }

        public async Task<bool>RestoreUserAsync(int id)
        {
            // Tìm người dùng trong thùng rác
            var user = await _userRepository.GetDeletedUserByIdAsync(id);
            if (user == null) return false;

            // Đổi trạng thái sống lại
            user.isActive = true;

            // Tái sử dụng hàm Update của Repository (hoặc dùng hàm Save của bạn)
            await _userRepository.UpdateUserAsync(user);

            return true;
        }


        public async Task<List<string>>GetAllDepartmentsAsync()
        {
            return await _userRepository.GetAllDepartmentsAsync();
        }

        public async Task<List<UserResponseDto>> GetAllUsersWithPermissionsAsync() =>
            await _userRepository.GetAllUsersWithPermissionsAsync();

        public async Task<PagedResult<UserResponseDto>> GetAllUsersAsync(UserFilterRequest filter) =>
            await _userRepository.GetAllUsersAsync(filter);

        // LOGIC XÂY DỰNG CÂY MENU 
        public async Task<List<MenuResponse>>GetUserMenusAsync(int userId)
        {
            var userWithGroups = await _userRepository.GetUserWithFullPermissionsAsync(userId);
            if (userWithGroups == null) return new List<MenuResponse>();

            var allAllowedMenus = userWithGroups.group.SelectMany(g => g.menu).DistinctBy(m => m.id).ToList();
            var allAllowedActions = userWithGroups.group.SelectMany(g => g.action).DistinctBy(a => a.id).ToList();

            var menuTree = new List<MenuResponse>();
            var parentMenus = allAllowedMenus.Where(m => m.parentId == null).OrderBy(m => m.id).ToList();

            foreach (var parent in parentMenus)
            {
                var parentDto = new MenuResponse
                {
                    id = parent.id,
                    label = parent.label,
                    to = parent.to,
                    icon = parent.icon,
                    children = new List<MenuResponse>()
                };

                var childMenus = allAllowedMenus.Where(m => m.parentId == parent.id).OrderBy(m => m.id).ToList();
                foreach (var child in childMenus)
                {
                    var childDto = new MenuResponse
                    {
                        id = child.id,
                        label = child.label,
                        to = child.to,
                        icon = child.icon,
                        action = allAllowedActions.Where(a => a.menuId == child.id).Select(a => a.code).ToList()
                    };
                    parentDto.children.Add(childDto);
                }
                menuTree.Add(parentDto);
            }
            return menuTree;
        }
    }
}