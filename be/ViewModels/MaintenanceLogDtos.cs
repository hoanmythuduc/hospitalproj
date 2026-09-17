using System;
using System.Collections.Generic;

namespace THUCTAP.ViewModels
{
    public class MaintenanceLogFilterRequest : PagingRequestBase
    {
        public int? equipmentId { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public int? status { get; set; }
    }
    public class MaintenanceLogRequest
    {
        public int equipmentId { get; set; }
        public DateTime logDate { get; set; }
        public bool isDaily { get; set; }
        public bool isWeekly { get; set; }
        public bool isMonthly { get; set; }
        public bool isQuarterly { get; set; }
        public bool isAsNeeded { get; set; }
        public string note { get; set; } = string.Empty;

        public int executorId { get; set; }
        public int? relatedMaintenanceId { get; set; }
    }

    public class InspectLogRequest
    {
        public int inspectorId { get; set; }
    }

    public class ReviewLogRequest
    {
        public int reviewerId { get; set; }
    }

    public class MaintenanceLogResponseDto
    {
        public int id { get; set; }
        public int equipmentId { get; set; }

        public string equipmentCode { get; set; } = string.Empty;
        public string equipmentName { get; set; } = string.Empty;

        public DateTime logDate { get; set; }
        public string isDaily { get; set; } = string.Empty;
        public string isWeekly { get; set; } = string.Empty;
        public string isMonthly { get; set; } = string.Empty;
        public string isQuarterly { get; set; } = string.Empty;
        public string isAsNeeded { get; set; } = string.Empty;
        public string note { get; set; } = string.Empty;
        public string statusName { get; set; } = string.Empty;

        public string executorName { get; set; } = string.Empty;
        public string inspectorName { get; set; } = string.Empty;
        public DateTime? inspectionDate { get; set; }
        public string reviewerName { get; set; } = string.Empty;
        public DateTime? reviewDate { get; set; }

    }

    public class MonthlyMaintenanceReportDto
    {
        public int equipmentId { get; set; }
        public string equipmentCode { get; set; } = string.Empty;
        public string equipmentName { get; set; } = string.Empty;
        public string dailyTask { get; set; } = string.Empty;
        public string weeklyTask { get; set; } = string.Empty;
        public string monthlyTask { get; set; } = string.Empty;
        public string quarterlyTask { get; set; } = string.Empty;
        public string asNeededTask { get; set; } = string.Empty;
        public int month { get; set; }
        public int year { get; set; }

        public List<MaintenanceLogResponseDto> dailyLogs { get; set; } = new List<MaintenanceLogResponseDto>();

        public string allInspectors { get; set; } = string.Empty;
        public string allReviewers { get; set; } = string.Empty;
    }
}