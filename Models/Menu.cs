using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace THUCTAP.Models
{
    [Table("Menu")]
    public class Menu : BaseModel
    {
        [JsonPropertyName("to")]
        public string to { get; set; } = string.Empty;

        [JsonPropertyName("parentId")]
        public int? parentId { get; set; } 

        [JsonIgnore]
        [ForeignKey(nameof(parentId))]
        public Menu? parent { get; set; }

        [JsonPropertyName("children")]
        public ICollection<Menu> children { get; set; } = new List<Menu>();

        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string icon { get; set; } = string.Empty;

        [JsonPropertyName("action")]
        public ICollection<AppAction> action { get; set; } = new List<AppAction>();

        [JsonIgnore]
        public ICollection<Group> group { get; set; } = new List<Group>();
        public ICollection<FormField> formFields { get; set; } = new List<FormField>();
    }
}