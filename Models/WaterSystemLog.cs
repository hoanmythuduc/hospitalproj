using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public enum WaterLogStatus
    {
        Tracking = 0,           // Đang theo dõi (Bác sĩ đang nhập hàng ngày)
        PendingInspection = 1,  // Chờ kiểm tra (Chốt sổ cuối tháng)
        PendingReview = 2,      // Chờ xem xét (Đã kiểm tra xong)
        Completed = 3           // Đã hoàn thành (Sẵn sàng xuất file Word)
    }

    public class WaterSystemLog : BaseModel
    {
        public int equipmentId { get; set; }
        [ForeignKey("equipmentId")]
        public Equipment? equipment { get; set; }
        public string allowedRange { get; set; } = string.Empty; 
        public string trackingTime { get; set; } = string.Empty;
        public int month { get; set; }
        public int year { get; set; }

        public WaterLogStatus status { get; set; } = WaterLogStatus.Tracking;

       
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

        // Móc nối 1 - n với bảng chi tiết ngày
        public ICollection<WaterSystemDailyLog> dailyLogs { get; set; } = new List<WaterSystemDailyLog>();
    }
}