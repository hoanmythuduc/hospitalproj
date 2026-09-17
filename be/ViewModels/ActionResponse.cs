using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class ActionResponse 
    {
        public int id { get; set; }
        public int menuId { get; set; }
        public string label { get; set; }
        public string code { get; set; }
        public string endpoint { get; set; } = string.Empty;
        public string method { get; set; } = string.Empty;
    }
}