namespace THUCTAP.ViewModels
{
    public class ExportReportRequest
    {
        public string? base64Template { get; set; }
        public string templateName { get; set; } = string.Empty;
    }
    public class DynamicReportRequest
    {
        public string tableName { get; set; } = string.Empty;
        public string selectColumns { get; set; } = "*";
        public string? whereCondition { get; set; }

        public string? base64Template { get; set; }
        public string templateName { get; set; } = string.Empty;
    }
}