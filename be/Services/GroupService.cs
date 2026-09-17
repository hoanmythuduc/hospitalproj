using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly AppDbContext _context;

        public GroupService(IGroupRepository groupRepository, AppDbContext context)
        {
            _groupRepository = groupRepository;
            _context = context;
        }

        public async Task<Group>CreateGroupAsync(CreateGroupRequest request)
        {
            var group = new Group
            {
                name = request.groupName,
                code = request.groupCode
            };

            var explicitMenuIds = request.permission != null
                ? request.permission.Select(p => p.menuId).Distinct().ToList()
                : new List<int>();

            var explicitActionIds = request.permission != null
                ? request.permission.SelectMany(p => p.action).Select(a => a.actionId).Distinct().ToList()
                : new List<int>();

            var menuIdsFromActions = await _groupRepository.GetMenuIdsFromActionsAsync(explicitActionIds);
            var allExplicitMenuIds = explicitMenuIds.Union(menuIdsFromActions).Distinct().ToList();
            var parentMenuIds = await _groupRepository.GetParentMenuIdsAsync(allExplicitMenuIds);
            var finalMenuIds = allExplicitMenuIds.Union(parentMenuIds).Distinct().ToList();

            group.menu = await _groupRepository.GetMenusByIdsAsync(finalMenuIds);
            group.action = await _groupRepository.GetActionsByIdsAsync(explicitActionIds);

            // Gọi Repository và lưu luôn
            await _groupRepository.CreateGroupAsync(group);

            return group;
        }

        public async Task<Group>UpdateGroupAsync(int id, CreateGroupRequest request)
        {
            var group = await _groupRepository.GetGroupByIdAsync(id);
            if (group == null) throw new Exception("Không tìm thấy nhóm quyền!");

            group.name = request.groupName;
            group.code = request.groupCode;

            var explicitMenuIds = request.permission != null
                ? request.permission.Select(p => p.menuId).Distinct().ToList()
                : new List<int>();

            var explicitActionIds = request.permission != null
                ? request.permission.SelectMany(p => p.action).Select(a => a.actionId).Distinct().ToList()
                : new List<int>();

            var menuIdsFromActions = await _groupRepository.GetMenuIdsFromActionsAsync(explicitActionIds);
            var allExplicitMenuIds = explicitMenuIds.Union(menuIdsFromActions).Distinct().ToList();
            var parentMenuIds = await _groupRepository.GetParentMenuIdsAsync(allExplicitMenuIds);
            var finalMenuIds = allExplicitMenuIds.Union(parentMenuIds).Distinct().ToList();

            group.menu = await _groupRepository.GetMenusByIdsAsync(finalMenuIds);
            group.action = await _groupRepository.GetActionsByIdsAsync(explicitActionIds);

            // Gọi Repository và lưu luôn
            await _groupRepository.UpdateGroupAsync(group);

            return group;
        }

        public async Task<bool>DeleteGroupAsync(int id)
        {
            var group = await _groupRepository.GetGroupByIdAsync(id);
            if (group == null) return false;

            // Gọi Repository và lưu luôn
            await _groupRepository.DeleteGroupAsync(group);

            return true;
        }

        public async Task<PagedResult<GroupResponse>>GetAllGroupsAsync(GroupFilterRequest filter)
        {
            return await _groupRepository.GetAllGroupsAsync(filter);
        }

        public async Task<List<MenuMatrixDto>>GetGroupPermissionMatrixAsync(int groupId)
        {
            var allMenus = await _context.Menu.AsNoTracking().ToListAsync();
            var allActions = await _context.Action.AsNoTracking().ToListAsync();

            Group? group = null;

            if (groupId > 0)
            {
                group = await _context.Group
                    .Include(g => g.menu)
                    .Include(g => g.action)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(g => g.id == groupId);

                if (group == null) throw new Exception("Không tìm thấy Nhóm quyền này!");
            }

            var matrixTree = new List<MenuMatrixDto>();
            var parentMenus = allMenus.Where(m => m.parentId == null).ToList();

            foreach (var parent in parentMenus)
            {
                var parentDto = new MenuMatrixDto
                {
                    id = parent.id,
                    label = parent.label,
                    icon = parent.icon,
                    isGranted = group != null && group.menu.Any(m => m.id == parent.id),
                    children = new List<MenuMatrixDto>(),

                    action = allActions.Where(a => a.menuId == parent.id).Select(a => new ActionMatrixDto
                    {
                        id = a.id,
                        label = a.label,
                        code = a.code,
                        isGranted = group != null && group.action.Any(ga => ga.id == a.id)
                    }).ToList()
                };

                var childMenus = allMenus.Where(m => m.parentId == parent.id).ToList();
                foreach (var child in childMenus)
                {
                    var childDto = new MenuMatrixDto
                    {
                        id = child.id,
                        label = child.label,
                        icon = child.icon,
                        isGranted = group != null && group.menu.Any(m => m.id == child.id),
                        action = allActions.Where(a => a.menuId == child.id).Select(a => new ActionMatrixDto
                        {
                            id = a.id,
                            label = a.label,
                            code = a.code,
                            isGranted = group != null && group.action.Any(ga => ga.id == a.id)
                        }).ToList()
                    };
                    parentDto.children.Add(childDto);
                }
                matrixTree.Add(parentDto);
            }

            return matrixTree;
        }
    }
}