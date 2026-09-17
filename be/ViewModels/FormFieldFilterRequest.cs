namespace THUCTAP.ViewModels
{
    public class FormFieldFilterRequest : PagingRequestBase
    {
        public int? id { get; set; }
        public string? label { get; set; }
        public string? field { get; set; }
        public string? entityName { get; set; }
        public string? type { get; set; } 
        public int? menuId { get; set; }
    }
}