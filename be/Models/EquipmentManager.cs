using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public class EquipmentManager : BaseModel
    {
        public int equipmentId { get; set; }
        [ForeignKey("equipmentId")]
        public Equipment? equipment { get; set; }

        public int userId { get; set; }
        [ForeignKey("userId")]
        public User? user { get; set; }
        public string userName { get; set; } = string.Empty;
        public DateTime? fromDate { get; set; }
    }
}