using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IGroupService
    {
        Task<Group>CreateGroupAsync(CreateGroupRequest request);
        Task<Group>UpdateGroupAsync(int id, CreateGroupRequest request);
        Task<bool>DeleteGroupAsync(int id);
        Task<PagedResult<GroupResponse>>GetAllGroupsAsync(GroupFilterRequest filter);
        Task<List<MenuMatrixDto>>GetGroupPermissionMatrixAsync(int groupId);
    }
}