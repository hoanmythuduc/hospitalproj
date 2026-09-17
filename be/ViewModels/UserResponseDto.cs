using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class UserResponseDto
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("userName")]
        public string userName { get; set; } = string.Empty;

        [JsonPropertyName("userCode")]
        public string userCode { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string email { get; set; } = string.Empty;

        [JsonPropertyName("department")]
        public string department { get; set; } = string.Empty;

        [JsonPropertyName("group")]
        public List<string> group { get; set; } = new List<string>();

        [JsonPropertyName("permission")]
        public List<string> permission { get; set; } = new List<string>();
    }
}