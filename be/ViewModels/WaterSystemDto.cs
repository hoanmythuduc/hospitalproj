using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace THUCTAP.ViewModels
{
    public class WaterSystemFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public int? equipmentId { get; set; }
        public string? equipmentCode { get; set; }
        public int? month { get; set; }
        public int? year { get; set; }
        public int? status { get; set; }
    }

    public class WaterSystemLogExportWord
    {
        public string equipmentCode { get; set; } = string.Empty;
        public string allowedRange { get; set; } = string.Empty;
        public string trackingTime { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public string month { get; set; } = string.Empty;
        public string year { get; set; } = string.Empty;
        public string inspectionDate { get; set; } = string.Empty;
        public string inspectorName { get; set; } = string.Empty;
        public string reviewDate { get; set; } = string.Empty;
        public string reviewerName { get; set; } = string.Empty;
        public List<Dictionary<string, object>> item { get; set; } = new List<Dictionary<string, object>>();
    }

    public class SaveDailyLogRequest
    {
        [Required(ErrorMessage = "Mã thiết bị không được để trống!")]
        public string equipmentCode { get; set; } = string.Empty;
        public string? allowedRange { get; set; }
        public string? trackingTime { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int day { get; set; }
        public string usValue { get; set; } = string.Empty;
        public int trackerId { get; set; }
    }
    

    public class InspectWaterLogRequest
    {
        public int inspectorId { get; set; }
        public bool isApproved { get; set; }
        public string? detail { get; set; }
    }

    public class ReviewWaterLogRequest
    {
        public int reviewerId { get; set; }
        public bool isApproved { get; set; }
        public string? detail { get; set; }
    }

    public class WaterSystemDailyLogResponse
    {
        public int day { get; set; }
        public string usValue { get; set; } = string.Empty;
        public string trackerName { get; set; } = string.Empty;
    }

    public class WaterSystemLogResponse
    {
        public int id { get; set; }
        public int equipmentId { get; set; }
        public string equipmentCode { get; set; } = string.Empty;
        public int month { get; set; }
        public int year { get; set; }
        public string statusName { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public string allowedRange { get; set; } = string.Empty;
        public string trackingTime { get; set; } = string.Empty;

        public string preparerName { get; set; } = string.Empty;
        public string inspectorName { get; set; } = string.Empty;
        public string reviewerName { get; set; } = string.Empty;
        public string inspectorDetail { get; set; } = string.Empty;
        public string reviewerDetail { get; set; } = string.Empty;

        public List<WaterSystemDailyLogResponse> dailyLogs { get; set; } = new List<WaterSystemDailyLogResponse>();
    }
}