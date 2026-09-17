using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public enum MaintenanceScheduleStatus
    {
        Draft = 0,           
        PendingApproval = 1, 
        Approved = 2,        
        Rejected = 3         
    }
    public class EquipmentMaintenanceSchedule : BaseModel
    {
        public int id { get; set; }

        public int equipmentId { get; set; }
        [ForeignKey("equipmentId")]
        public Equipment? equipment { get; set; }

        public int year { get; set; }
        public string task { get; set; } = string.Empty;
        public string note { get; set; } = string.Empty;

        public bool m1 { get; set; }
        public bool m2 { get; set; }
        public bool m3 { get; set; }
        public bool m4 { get; set; }
        public bool m5 { get; set; }
        public bool m6 { get; set; }
        public bool m7 { get; set; }
        public bool m8 { get; set; }
        public bool m9 { get; set; }
        public bool m10 { get; set; }
        public bool m11 { get; set; }
        public bool m12 { get; set; }

        public MaintenanceScheduleStatus status { get; set; } = MaintenanceScheduleStatus.Draft;

        public int? preparerId { get; set; }
        [ForeignKey("preparerId")]
        public User? preparer { get; set; }

        public int? approverId { get; set; }
        [ForeignKey("approverId")]
        public User? approver { get; set; }

        
    }
}