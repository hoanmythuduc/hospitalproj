using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public enum MaintenanceLogStatus
    {
        PendingInspection = 1,
        PendingReview = 2,     
        Completed = 3         
    }

    public class EquipmentMaintenanceLog : BaseModel
    {
        public int equipmentId { get; set; }
        [ForeignKey("equipmentId")]
        public Equipment? equipment { get; set; }

        public DateTime logDate { get; set; }

        public bool isDaily { get; set; }
        public bool isWeekly { get; set; }
        public bool isMonthly { get; set; }
        public bool isQuarterly { get; set; }
        public bool isAsNeeded { get; set; }
        public string note { get; set; } = string.Empty;

        public MaintenanceLogStatus status { get; set; } = MaintenanceLogStatus.PendingInspection;

        public int executorId { get; set; }
        [ForeignKey("executorId")]
        public User? executor { get; set; }

        public int? inspectorId { get; set; }
        [ForeignKey("inspectorId")]
        public User? inspector { get; set; }
        public DateTime? inspectionDate { get; set; }

        public int? reviewerId { get; set; }
        [ForeignKey("reviewerId")]
        public User? reviewer { get; set; }
        public DateTime? reviewDate { get; set; }
        public int? relatedMaintenanceId { get; set; }
        [ForeignKey("relatedMaintenanceId")]
        public EquipmentMaintenance? relatedMaintenance { get; set; }
    }
}