namespace THUCTAP.ViewModels
{
    public class LoginResponse
    {
        public string token { get; set; } = string.Empty;
        public int userId { get; set; }
        public List<PermissionDto> permission { get; set; } = new List<PermissionDto>();
    }
}