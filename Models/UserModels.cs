using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace THUCTAP.Models
{
    [Table("User")]
    [Index(nameof(userCode), IsUnique = true)]
    public class User : BaseModel
    {
        [JsonPropertyName("userName")]
        public string userName { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("userCode")]
        public string userCode { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string password { get; set; } = string.Empty;

        [JsonPropertyName("department")]
        public string department { get; set; } = string.Empty;


        [JsonIgnore]
        public ICollection<Group> group { get; set; } = new List<Group>();
    }
}