using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public class EquipmentMaintenance : BaseModel
    {
        public int equipmentId { get; set; }
        [ForeignKey("equipmentId")]
        public Equipment? equipment { get; set; }

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
}