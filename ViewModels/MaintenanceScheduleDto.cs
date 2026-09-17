using System;
using THUCTAP.Models; // Giả sử bạn để enum MaintenanceScheduleStatus ở đây

namespace THUCTAP.ViewModels
{
    public class MaintenanceScheduleExportWord
    {
        public int year { get; set; }
        public string day { get; set; } = string.Empty;
        public string month { get; set; } = string.Empty;
        public string yearNow { get; set; } = string.Empty;

        public string preparerName { get; set; } = string.Empty;
        public string approverName { get; set; } = string.Empty;

        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> item { get; set; }
            = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>>();
    }
    public class MaintenanceScheduleRequest
    {
        public int equipmentId { get; set; }
        public int year { get; set; }
        public string task { get; set; } = string.Empty;
        public string note { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
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
        
        public int preparerId { get; set; }
    }

    public class ApproveScheduleRequest
    {
        public int approverId { get; set; }
        public bool isApproved { get; set; } // true: Duyệt, false: Từ chối
    }

    public class MaintenanceScheduleFilterRequest : PagingRequestBase
    {
        
        public int? equipmentId { get; set; }
        public int? year { get; set; }
        public int? status { get; set; }
        
    }

    public class MaintenanceScheduleResponseDto
    {
        public int id { get; set; }
        public int equipmentId { get; set; }
        public string equipmentCode { get; set; } = string.Empty;
        public string equipmentName { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public int year { get; set; }
        
        public string task { get; set; } = string.Empty;
        public string note { get; set; } = string.Empty;
        
        public string m1 { get; set; } = "";
        public string m2 { get; set; } = "";
        public string m3 { get; set; } = "";
        public string m4 { get; set; } = "";
        public string m5 { get; set; } = "";
        public string m6 { get; set; } = "";
        public string m7 { get; set; } = "";
        public string m8 { get; set; } = "";
        public string m9 { get; set; } = "";
        public string m10 { get; set; } = "";
        public string m11 { get; set; } = "";
        public string m12 { get; set; } = "";

        public string statusName { get; set; } = string.Empty;
        public string preparerName { get; set; } = string.Empty;
        public string approverName { get; set; } = string.Empty;
    }
}