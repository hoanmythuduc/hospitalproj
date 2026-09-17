using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations; 

namespace THUCTAP.ViewModels
{
    public class UserCreateRequest
    {
        [JsonPropertyName("userName")]
        [Required(ErrorMessage = "Tên người dùng không được để trống!")]
        public string userName { get; set; } = string.Empty;

        [JsonPropertyName("userCode")]
        [Required(ErrorMessage = "Mã nhân viên không được để trống!")]
        public string userCode { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Email không được để trống!")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Hệ thống chỉ chấp nhận email có đuôi @gmail.com!")]
        public string email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Mật khẩu phải chứa ít nhất chữ hoa, chữ thường, số và ký tự đặc biệt!")]                
        public string password { get; set; } = string.Empty;

        [JsonPropertyName("department")]
        public string department { get; set; } = string.Empty;

        [JsonPropertyName("groupId")]
        public List<int> groupId { get; set; } = new List<int>();
    }
}