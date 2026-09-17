namespace THUCTAP.ViewModels 
{
    public class ActionSummaryDto
    {
        public int actionId { get; set; }
        public string? actionLabel { get; set; }
    }
    public class PermissionDto
    {
        public int menuId { get; set; }
        public string? menuLabel { get; set; }
        public string? parentLabel { get; set; }
            
        public List<ActionSummaryDto> action { get; set; } = new List<ActionSummaryDto>();
    
    }

   
    public class CreateGroupRequest
    {
        public string groupName { get; set; }
        public string groupCode { get; set; }

        
        public List<PermissionDto>? permission { get; set; } = new List<PermissionDto>();
    }
}