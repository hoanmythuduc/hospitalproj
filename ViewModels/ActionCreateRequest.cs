using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class ActionCreateRequest
    {
        [Required(ErrorMessage = "Tên hành động (label) không được để trống!")]
        public string label { get; set; }

        [Required(ErrorMessage = "Mã hành động (code) không được để trống!")]
        public string code { get; set; }
        public string? endpoint { get; set; }
        public string? method { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ID của Menu (menuId)!")]
        public int menuId { get; set; }

    }
}