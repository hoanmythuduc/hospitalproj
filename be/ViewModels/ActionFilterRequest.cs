namespace THUCTAP.ViewModels
{
    public class ActionFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public string? label { get; set; }
        public string? code { get; set; }
        public string? endpoint { get; set; }
        public string? method { get; set; } 
    }
}