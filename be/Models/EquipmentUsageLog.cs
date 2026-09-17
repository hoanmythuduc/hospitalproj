using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public enum UsageLogStatus
    {
        Tracking = 0,
        PendingInspection = 1,
        PendingReview = 2,
        Completed = 3
    }

    public class EquipmentUsageLog : BaseModel
    {
        public int equipmentId { get; set; }
        [ForeignKey("equipmentId")]
        public Equipment? equipment { get; set; }

        public int month { get; set; }
        public int year { get; set; }
        public int weekOfMonth { get; set; }

        public UsageLogStatus status { get; set; } = UsageLogStatus.Tracking;

        public int? preparerId { get; set; }
        [ForeignKey("preparerId")]
        public User? preparer { get; set; }

        public int? inspectorId { get; set; }
        [ForeignKey("inspectorId")]
        public User? inspector { get; set; }
        public DateTime? inspectionDate { get; set; }

        public int? reviewerId { get; set; }
        [ForeignKey("reviewerId")]
        public User? reviewer { get; set; }
        public DateTime? reviewDate { get; set; }

        public ICollection<EquipmentUsageDailyLog> dailyLogs { get; set; } = new List<EquipmentUsageDailyLog>();
    }
}