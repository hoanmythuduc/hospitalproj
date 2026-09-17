using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public class EquipmentUsageDailyLog : BaseModel
    {
        public int usageLogId { get; set; }
        [ForeignKey("usageLogId")]
        public EquipmentUsageLog? usageLog { get; set; }

        public DateTime logDate { get; set; }
        public int dayOfWeek { get; set; } 

        public string shift1 { get; set; } = string.Empty;
        public string shift2 { get; set; } = string.Empty;
        public string shift3 { get; set; } = string.Empty;
        public string shift4 { get; set; } = string.Empty;
        public string shift5 { get; set; } = string.Empty;

        public string usageCount { get; set; } = string.Empty;
        public string maintenanceCallTime { get; set; } = string.Empty;

        public string dailyDecon { get; set; } = string.Empty;
        public string preMaintenanceDecon { get; set; } = string.Empty;

        public bool? isNormal { get; set; }
        public bool? qcResult { get; set; }
    }
}