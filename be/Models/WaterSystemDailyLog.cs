using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public class WaterSystemDailyLog : BaseModel
    {
        public int waterSystemLogId { get; set; }
        [ForeignKey("waterSystemLogId")]
        public WaterSystemLog? waterSystemLog { get; set; }

        public int day { get; set; } // Lưu số ngày (từ 1 đến 31)

        // Lưu kiểu string để bác sĩ có thể nhập các giá trị như "<1,0" hoặc "0.5"
        public string usValue { get; set; } = string.Empty;

        // Người theo dõi thực tế của ngày hôm đó
        public int? trackerId { get; set; }
        [ForeignKey("trackerId")]
        public User? tracker { get; set; }
    }
}