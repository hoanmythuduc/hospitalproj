using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace THUCTAP.Models
{
    [Table("Group")]
    [Index(nameof(name), IsUnique = true)]
    [Index(nameof(code), IsUnique = true)]
    public class Group : BaseModel
    {
        [JsonPropertyName("name")]
        public string name { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public string code { get; set; } = string.Empty;

        [JsonPropertyName("menu")]
        public ICollection<Menu> menu { get; set; } = new List<Menu>();

        [JsonPropertyName("action")]
        public ICollection<AppAction> action { get; set; } = new List<AppAction>();

        [JsonIgnore]
        public ICollection<User> user { get; set; } = new List<User>();
    }
}