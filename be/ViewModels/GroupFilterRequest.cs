namespace THUCTAP.ViewModels
{
    public class GroupFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public string? groupName { get; set; }
        public string? groupCode { get; set; }
    }
}