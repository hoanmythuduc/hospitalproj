using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class GroupResponse
    {
        public int id { get; set; } 
        public string? groupName { get; set; }
        public string? groupCode { get; set; }
        public List<PermissionDto> permission { get; set; } = new List<PermissionDto>();
    }
}