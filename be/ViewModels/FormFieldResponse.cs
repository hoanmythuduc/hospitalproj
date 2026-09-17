using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using THUCTAP.Models;

namespace THUCTAP.ViewModels
{
    public class FormFieldResponse
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("entityName")]
        public string? entityName { get; set; }

        [JsonPropertyName("field")]
        [Required(ErrorMessage = "Field không được để trống!")]
        public string field { get; set; }

        [JsonPropertyName("label")]
        [Required(ErrorMessage = "Label không được để trống!")]
        public string label { get; set; }

        [JsonPropertyName("type")]
        [Required(ErrorMessage = "Type không được để trống!")]
        public string type { get; set; } = "text";

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
        public string? subfield { get; set; }
        public string? tagfield { get; set; }
        public string? tabname { get; set; }
        public string? endpoint { get; set; }

        [JsonPropertyName("menuId")]
        [Required(ErrorMessage = "Menu ID không được để trống!")]
        public int menuId { get; set; }

        [JsonPropertyName("menuName")]
        public string menuName { get; set; }
    }
}