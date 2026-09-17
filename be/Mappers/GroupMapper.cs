using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class GroupMapper
    {
        public static Group ToGroup(this CreateGroupRequest request)
        {
            return new Group
            {
                name = request.groupName,
                code = request.groupCode,
                createdAt = DateTime.UtcNow,
                updatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateGroup(this Group group, CreateGroupRequest request)
        {
            group.name = request.groupName;
            group.code = request.groupCode;
            group.updatedAt = DateTime.UtcNow;
        }
    }
}