using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User? GetUserByCredentials(string username, string password)
        {
            return _context.User
                .Where(u => u.userName == username && u.password == password)
                .Include(u => u.group).ThenInclude(g => g.menu).ThenInclude(m => m.parent)
                .Include(u => u.group).ThenInclude(g => g.action)
                .FirstOrDefault();
        }

        public async Task<bool>UserCodeExistsAsync(string userCode) =>
            await _context.User.AnyAsync(u => u.userCode == userCode);

        public async Task<User?>GetUserByIdWithGroupsAsync(int id) =>
            await _context.User.Include(u => u.group).FirstOrDefaultAsync(u => u.id == id);

        public async Task<User?>GetUserWithFullPermissionsAsync(int userId) =>
            await _context.User
                .Include(u => u.group).ThenInclude(g => g.menu)
                .Include(u => u.group).ThenInclude(g => g.action)
                .FirstOrDefaultAsync(u => u.id == userId);

        public async Task<List<Group>>GetGroupsByIdsAsync(List<int> groupIds) =>
            await _context.Group.Where(g => groupIds.Contains(g.id)).ToListAsync();

        public async Task CreateUserAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>>GetDeletedUsersAsync()
        {
            return await _context.User
                                 .IgnoreQueryFilters() 
                                 .Where(u => u.isActive == false)
                                 .ToListAsync();
        }

        public async Task<User?>GetDeletedUserByIdAsync(int id)
        {
            return await _context.User
                                 .IgnoreQueryFilters()
                                 .FirstOrDefaultAsync(u => u.id == id && u.isActive == false);

        }

        public async Task<List<UserResponseDto>>GetAllUsersWithPermissionsAsync()
        {
            var rawUsers = await _context.User
                .Include(u => u.group).ThenInclude(g => g.action)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();

            return rawUsers.Select(u => new UserResponseDto
            {
                id = u.id,
                userName = u.userName,
                userCode = u.userCode,
                email = u.email,
                department = u.department,
                group = u.group.Select(g => g.name).ToList(),
                permission = u.group.SelectMany(g => g.action).Select(a => a.label).Distinct().ToList()
            }).ToList();
        }

        public async Task<List<string>>GetAllDepartmentsAsync()
        {
            return await _context.User
                .Where(u => !string.IsNullOrWhiteSpace(u.department))
                .Select(u => u.department)
                .Distinct()
                .ToListAsync();
        }

        public async Task<PagedResult<UserResponseDto>>GetAllUsersAsync(UserFilterRequest filter)
        {
            var query = _context.User.Include(u => u.group).AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.userName)) query = query.Where(u => u.userName.Contains(filter.userName));
                if (!string.IsNullOrWhiteSpace(filter.userCode)) query = query.Where(u => u.userCode.Contains(filter.userCode));
                if (!string.IsNullOrWhiteSpace(filter.email)) query = query.Where(u => u.email.Contains(filter.email));
                if (!string.IsNullOrWhiteSpace(filter.department)) query = query.Where(u => u.department.Contains(filter.department));
                if (!string.IsNullOrWhiteSpace(filter.userGroup))
                    query = query.Where(u => u.group.Any(g => g.name.Contains(filter.userGroup) || g.code.Contains(filter.userGroup)));
                if (filter.id > 0) query = query.Where(u => u.id == filter.id);
            }

            var pagedRawUsers = await query
                .OrderByDescending(u => u.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawUsers.Map(u => new UserResponseDto
            {
                id = u.id,
                userName = u.userName,
                userCode = u.userCode,
                email = u.email,
                department = u.department,
                group = u.group.Select(g => g.name).ToList()
            });
        }
    }
}