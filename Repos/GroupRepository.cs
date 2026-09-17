using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Group?>GetGroupByIdAsync(int id)
        {
            return await _context.Group
                .Include(g => g.menu)
                .Include(g => g.action)
                .FirstOrDefaultAsync(g => g.id == id);
        }

        public async Task<PagedResult<GroupResponse>>GetAllGroupsAsync(GroupFilterRequest filter)
        {
            var query = _context.Group
                .Include(g => g.menu)
                .Include(g => g.action)
                .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.groupName))
                    query = query.Where(g => g.name.Contains(filter.groupName));

                if (!string.IsNullOrWhiteSpace(filter.groupCode))
                    query = query.Where(g => g.code.Contains(filter.groupCode));
                if(filter.id>0)
                    query = query.Where(g => g.id == filter.id);
            }

            var pagedRawGroups = await query
                .OrderByDescending(g => g.id) 
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawGroups.Map(g =>
            {
                var menuList = g.menu.Select(m => new PermissionDto
                {
                    menuId = m.id,
                    menuLabel = m.label,
                    parentLabel = _context.Menu.FirstOrDefault(p => p.id == m.parentId)?.label,
                    action = g.action.Where(a => a.menuId == m.id).Select(a => new ActionSummaryDto
                    {
                        actionId = a.id,
                        actionLabel = a.label
                    }).ToList()
                }).ToList();

                return new GroupResponse
                {
                    id = g.id,
                    groupName = g.name,
                    groupCode = g.code,
                    permission = menuList
                };
            });
        }

        public async Task CreateGroupAsync(Group group)
        {
            _context.Group.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(Group group)
        {
            _context.Group.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(Group group)
        {
            _context.Group.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task<List<int>>GetChildMenuIdsAsync(List<int> explicitMenuIds) =>
            await _context.Menu
                .Where(m => m.parentId != null && explicitMenuIds.Contains(m.parentId.Value))
                .Select(m => m.id)
                .ToListAsync();

        public async Task<List<int>>GetAutoActionIdsAsync(List<int> childMenuIds) =>
            await _context.Action
                .Where(a => childMenuIds.Contains(a.menuId))
                .Select(a => a.id)
                .ToListAsync();

        public async Task<List<int>> GetMenuIdsFromActionsAsync(List<int> explicitActionIds) =>
            await _context.Action
                .Where(a => explicitActionIds.Contains(a.id))
                .Select(a => a.menuId)
                .Distinct()
                .ToListAsync();

        public async Task<List<int>> GetParentMenuIdsAsync(List<int> allMenuIds) =>
            await _context.Menu
                .Where(m => allMenuIds.Contains(m.id) && m.parentId != null)
                .Select(m => m.parentId.Value)
                .ToListAsync();

        public async Task<List<Menu>> GetMenusByIdsAsync(List<int> menuIds) =>
            await _context.Menu
                .Where(m => menuIds.Contains(m.id))
                .ToListAsync();

        public async Task<List<AppAction>> GetActionsByIdsAsync(List<int> actionIds) =>
            await _context.Action
                .Where(a => actionIds.Contains(a.id))
                .ToListAsync();
    }
}