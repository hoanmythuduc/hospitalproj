using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group?>GetGroupByIdAsync(int id);
        Task CreateGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(Group group);
        Task<PagedResult<GroupResponse>>GetAllGroupsAsync(GroupFilterRequest filter);

        Task<List<int>>GetChildMenuIdsAsync(List<int> explicitMenuIds);
        Task<List<int>>GetAutoActionIdsAsync(List<int> childMenuIds);
        Task<List<int>>GetMenuIdsFromActionsAsync(List<int> explicitActionIds);
        Task<List<int>>GetParentMenuIdsAsync(List<int> allMenuIds);

        Task<List<Menu>>GetMenusByIdsAsync(List<int> menuIds);
        Task<List<AppAction>>GetActionsByIdsAsync(List<int> actionIds);
     
    }
}