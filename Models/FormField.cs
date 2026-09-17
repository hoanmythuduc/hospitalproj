using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace THUCTAP.Models
{
    [Table("FormField")]
    public class FormField : BaseModel
    {
        [JsonPropertyName("entityName")]
        public string entityName { get; set; } = string.Empty;

        [JsonPropertyName("field")]
        public string field { get; set; } = string.Empty;

        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string type { get; set; } = string.Empty;

        [JsonPropertyName("colSpan")]
        public int colSpan { get; set; }

        [JsonPropertyName("option")]
        public string? option { get; set; } = string.Empty;

        [JsonPropertyName("sortOrder")]
        public int sortOrder { get; set; }
        public bool isSearchAble { get; set; }
        public bool isShowInForm { get; set; }
        public bool isShowInList { get; set; }
        public string? subField { get; set; }
        public string? tagField { get; set; }
        public string? tabName { get; set; }
        public string? endPoint { get; set; }

        [JsonPropertyName("menuId")]
        public int? menuId { get; set; }

        [ForeignKey("menuId")]
        [JsonIgnore] 
        public Menu? menu { get; set; }
    }
}