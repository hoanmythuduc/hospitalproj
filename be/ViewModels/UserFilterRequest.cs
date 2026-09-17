namespace THUCTAP.ViewModels
{
    public class UserFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public string? userName { get; set; }
        public string? userCode { get; set; }
        public string? email { get; set; }
        public string? department { get; set; }
        public string? userGroup { get; set; }
    }
}