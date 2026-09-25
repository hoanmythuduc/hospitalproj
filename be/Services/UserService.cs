using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using Microsoft.Extensions.Logging; // 👉 Bổ sung thư viện Logging
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace THUCTAP.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger; // 👉 Khai báo Logger

        // 👉 Tiêm ILogger vào Constructor
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<User> CreateUserAsync(UserCreateRequest request)
        {
            try
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
            catch (Exception ex)
            {
                // 👉 Ghi log kèm theo mã nhân viên để dễ tìm kiếm
                _logger.LogError(ex, "Lỗi khi tạo Người dùng (User) mới. Mã nhân viên: {UserCode}", request.userCode);
                throw;
            }
        }

        public async Task<User> UpdateUserAsync(int id, UserCreateRequest request)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật thông tin Người dùng (User) có ID: {UserId}", id);
                throw;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdWithGroupsAsync(id);
                if (user == null) return false;

                await _userRepository.DeleteUserAsync(user);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa Người dùng (User) có ID: {UserId}", id);
                throw;
            }
        }
        
        public async Task<List<User>> GetDeletedUsersAsync()
        {
            try
            {
                return await _userRepository.GetDeletedUsersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Người dùng (User) đã xóa (Thùng rác)");
                throw;
            }
        }

        public async Task<bool> RestoreUserAsync(int id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi Khôi phục (Restore) Người dùng (User) có ID: {UserId}", id);
                throw;
            }
        }

        public async Task<List<string>> GetAllDepartmentsAsync()
        {
            try
            {
                return await _userRepository.GetAllDepartmentsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách các Phòng ban");
                throw;
            }
        }

        public async Task<List<UserResponseDto>> GetAllUsersWithPermissionsAsync()
        {
            try
            {
                return await _userRepository.GetAllUsersWithPermissionsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách User kèm theo quyền hạn (Permissions)");
                throw;
            }
        }

        public async Task<PagedResult<UserResponseDto>> GetAllUsersAsync(UserFilterRequest filter)
        {
            try
            {
                return await _userRepository.GetAllUsersAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Người dùng (User)");
                throw;
            }
        }

        // LOGIC XÂY DỰNG CÂY MENU 
        public async Task<List<MenuResponse>> GetUserMenusAsync(int userId)
        {
            try
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
            catch (Exception ex)
            {
                // Lỗi khi gen Menu thường khiến UI Frontend bị lỗi trắng màn hình
                _logger.LogError(ex, "Lỗi nghiêm trọng khi tạo cây Menu động cho Người dùng ID: {UserId}", userId);
                throw;
            }
        }
    }
}