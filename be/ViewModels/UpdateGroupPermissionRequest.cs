namespace THUCTAP.ViewModels
{
    public class UpdateGroupPermissionRequest
    {
        public List<int> menuId { get; set; } = new List<int>();
        public List<int> actionId { get; set; } = new List<int>();
    }
}