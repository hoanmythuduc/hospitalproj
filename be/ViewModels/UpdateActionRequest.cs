namespace THUCTAP.ViewModels
{
    public class UpdateActionRequest
    {
        public int menuId { get; set; }
        public string label { get; set; }
        public string code { get; set; }
        public string? endpoint { get; set; }
        public string? method { get; set; }
    }
}