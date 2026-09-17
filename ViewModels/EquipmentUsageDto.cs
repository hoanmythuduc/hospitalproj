using System;
using System.Collections.Generic;

namespace THUCTAP.ViewModels
{
    public class EquipmentUsageFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public int? equipmentId { get; set; }
        public int? month { get; set; }
        public int? year { get; set; }
        public int? weekOfMonth { get; set; }
        public int? status { get; set; }
    }

    public class SaveUsageDailyLogRequest
    {
        public int equipmentId { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int weekOfMonth { get; set; }
        public int preparerId { get; set; }

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

    public class ProcessUsageLogRequest
    {
        public int userId { get; set; }
        public bool isApproved { get; set; }
    }

    public class EquipmentUsageDailyLogResponse
    {
        public int id { get; set; }
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

    public class EquipmentUsageLogResponse
    {
        public int id { get; set; }
        public int equipmentId { get; set; }
        public string equipmentCode { get; set; } = string.Empty;
        public string equipmentName { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public int month { get; set; }
        public int year { get; set; }
        public int weekOfMonth { get; set; }
        public string statusName { get; set; } = string.Empty;

        public string preparerName { get; set; } = string.Empty;
        public string inspectorName { get; set; } = string.Empty;
        public string reviewerName { get; set; } = string.Empty;

        public List<EquipmentUsageDailyLogResponse> dailyLogs { get; set; } = new List<EquipmentUsageDailyLogResponse>();
    }
}