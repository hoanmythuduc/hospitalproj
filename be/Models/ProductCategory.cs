using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    [Table("ProductCategory")]
    public class ProductCategory : BaseModel
    {
        public string equipmentCode { get; set; } = string.Empty;
        public string equipmentName { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;
        public string manufacturer { get; set; } = string.Empty;
        public string countryOfOrigin { get; set; } = string.Empty;
        public string serialNumber { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public DateTime? receivedDate { get; set; }
        public string conditionWhenReceived { get; set; } = string.Empty;
        public DateTime? startDateOfUse { get; set; }
        public string conditionWhenStarted { get; set; } = string.Empty;
        public int supplierId { get; set; }
        [ForeignKey("supplierId")]
        public CustomerMaster? supplier { get; set; }
        public string? dailyTask { get; set; } = string.Empty;
        public string? weeklyTask { get; set; } = string.Empty;
        public string? monthlyTask { get; set; } = string.Empty;
        public string? quarterlyTask { get; set; } = string.Empty;
        public string? asNeededTask { get; set; } = string.Empty;
    }
}