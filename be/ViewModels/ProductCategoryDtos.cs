using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class ProductCategoryFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public string? equipmentCode { get; set; }
        public string? equipmentName { get; set; }
        public int? supplierId { get; set; }
    }

    public class ProductCategoryRequest
    {
        [Required(ErrorMessage = "Mã thiết bị không được để trống!")]
        public string equipmentCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tên thiết bị không được để trống!")]
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

        [Required(ErrorMessage = "Vui lòng chọn nhà cung cấp!")]
        public int supplierId { get; set; }
        public string? dailyTask { get; set; } = string.Empty;
        public string? weeklyTask { get; set; } = string.Empty;
        public string? monthlyTask { get; set; } = string.Empty;
        public string? quarterlyTask { get; set; } = string.Empty;
        public string? asNeededTask { get; set; } = string.Empty;
    }

    public class ProductCategoryResponseDto
    {
        public int id { get; set; }
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
        public string? supplierName { get; set; } = string.Empty;
        public string? dailyTask { get; set; } = string.Empty;
        public string? weeklyTask { get; set; } = string.Empty;
        public string? monthlyTask { get; set; } = string.Empty;
        public string? quarterlyTask { get; set; } = string.Empty;
        public string? asNeededTask { get; set; } = string.Empty;
    }
}