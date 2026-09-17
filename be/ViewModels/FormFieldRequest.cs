using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class FormFieldRequest
    {
        [JsonPropertyName("entityName")]
        [Required(ErrorMessage = "Tên bảng (entityName) không được để trống!")]
        public string entityName { get; set; }

        [JsonPropertyName("field")]
        [Required(ErrorMessage = "Field không được để trống!")]
        public string field { get; set; }

        [JsonPropertyName("label")]
        public string? label { get; set; }

        [JsonPropertyName("type")]
        public string? type { get; set; }

        [JsonPropertyName("colSpan")]
        public int colSpan { get; set; }

        [JsonPropertyName("option")]
        public string? option { get; set; }

        [JsonPropertyName("sortOrder")]
        public int sortOrder { get; set; }
        [JsonPropertyName("isSearchAble")]
        public bool isSearchAble { get; set; }

        [JsonPropertyName("isShowInForm")]
        public bool isShowInForm { get; set; }

        [JsonPropertyName("isShowInList")]
        public bool isShowInList { get; set; }
        public string? subField { get; set; }
        public string? tagField { get; set; }
        public string? tabName { get; set; }
        public string? endPoint { get; set; }

        [JsonPropertyName("menuId")]
        [Required(ErrorMessage = "Menu ID không được để trống!")]
        public int menuId { get; set; }
    }
}