using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class CustomerCategoryFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public string? groupName { get; set; }

    }

    public class CustomerCategoryRequest
    {
        [JsonPropertyName("groupName")]
        [Required(ErrorMessage = "Tên nhóm không được để trống!")]
        public string groupName { get; set; } = string.Empty;

        [JsonPropertyName("discount")]
        [Range(0, 100, ErrorMessage = "Chiết khấu phải nằm trong khoảng từ 0 đến 100%")]
        public decimal discount { get; set; }

        [JsonPropertyName("isActive")]
        public bool isActive { get; set; } = true;
    }

    public class CustomerCategoryResponseDto
    {
        public int id { get; set; }
        public string groupName { get; set; } = string.Empty;
        public decimal discount { get; set; }
        public bool isActive { get; set; }
    }
}