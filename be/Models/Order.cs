using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public class Order : BaseModel
    {
        public string orderNumber { get; set; } = string.Empty;
        public DateTime orderDate { get; set; }

        // Khóa ngoại nối với bảng Khách hàng
        public int customerId { get; set; }
        [ForeignKey("customerId")]
        public CustomerMaster? customer { get; set; }

        // Bạn có thể thêm trường này để lưu Nhanh Tổng Tiền nếu cần
        public decimal estimatedTotal { get; set; }
    }
}