using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using THUCTAP.Models;

namespace THUCTAP.ViewModels
{
    public class EquipmentFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public string? equipmentName { get; set; }
        public string? equipmentCode { get; set; }
    }

    public class EquipmentRequest
    {
        public int productCategoryId { get; set; }
        public List<EquipmentManagerRequest> managers { get; set; } = new List<EquipmentManagerRequest>();
        public List<EquipmentMaintenanceRequest> maintenances { get; set; } = new List<EquipmentMaintenanceRequest>();
        public bool isActive { get; set; } = true;
    }

    public class EquipmentResponseDto
    {
        public int id { get; set; }
        public int productCategoryId { get; set; }
        public string equipmentName { get; set; } = string.Empty;
        public string equipmentCode { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;
        public string manufacturer { get; set; } = string.Empty;
        public string countryOfOrigin { get; set; } = string.Empty;
        public string supplierName { get; set; } = string.Empty;
        public string supplierAddress { get; set; } = string.Empty;
        public string engineerInCharge { get; set; } = string.Empty;
        public string supplierPhone { get; set; } = string.Empty;
        public string supplierEmail { get; set; } = string.Empty;
        public string serialNumber { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public DateTime? receivedDate { get; set; }
        public string conditionWhenReceived { get; set; } = string.Empty;
        public DateTime? startDateOfUse { get; set; }
        public string conditionWhenStarted { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
        public List<EquipmentManagerResponseDto> managers { get; set; } = new List<EquipmentManagerResponseDto>();
        public List<EquipmentMaintenanceResponseDto> maintenances { get; set; } = new List<EquipmentMaintenanceResponseDto>();
    }
    public class EquipmentManagerRequest
    {
        public int userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public DateTime? fromDate { get; set; }
    }
    public class EquipmentMaintenanceRequest
    {
        public DateTime? maintenanceDate { get; set; }
        public DateTime? incidentTime { get; set; }
        public DateTime? engineerArrivedTime { get; set; }
        public DateTime? completedTime { get; set; }
        public string actionType { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public string purpose { get; set; } = string.Empty;
        public string labSignature { get; set; } = string.Empty;
        public string engineerSignature { get; set; } = string.Empty;
    }
    public class EquipmentManagerResponseDto
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string userName { get; set; } = string.Empty; 
        public DateTime? fromDate { get; set; }
    }
    public class EquipmentMaintenanceResponseDto
    {
        public int id { get; set; }
        public DateTime? maintenanceDate { get; set; }
        public string incidentTime { get; set; } = string.Empty;
        public string engineerArrivedTime { get; set; } = string.Empty;
        public string completedTime { get; set; } = string.Empty;
        public string actionType { get; set; } = string.Empty;
        public string isMaintenance { get; set; } = string.Empty;
        public string isRepair { get; set; } = string.Empty;
        public string isCalibration { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public string purpose { get; set; } = string.Empty;
        public string labSignature { get; set; } = string.Empty;
        public string engineerSignature { get; set; } = string.Empty;
    }
}