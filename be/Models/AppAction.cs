using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace THUCTAP.Models
{
    [Table("Action")]
    public class AppAction : BaseModel
    {
        [JsonPropertyName("menuId")]
        public int menuId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(menuId))]
        public Menu? menu { get; set; }

        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public string code { get; set; } = string.Empty;

        [JsonPropertyName("endpoint")]
        public string endpoint { get; set; } = string.Empty;

        [JsonPropertyName("method")]
        public string method { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Group> group { get; set; } = new List<Group>();

    }
}