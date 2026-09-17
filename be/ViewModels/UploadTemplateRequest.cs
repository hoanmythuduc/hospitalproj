using Microsoft.AspNetCore.Http;

namespace THUCTAP.ViewModels
{
    public class UploadTemplateRequest
    {
        public string tableName { get; set; } = string.Empty;
        public string selectColumns { get; set; } = "*";
        public string? whereCondition { get; set; }
        public IFormFile templateFile { get; set; }
    }
}