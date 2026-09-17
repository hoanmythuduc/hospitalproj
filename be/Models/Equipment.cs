using System.ComponentModel.DataAnnotations.Schema;

namespace THUCTAP.Models
{
    public class Equipment : BaseModel
    {
        public int productCategoryId { get; set; }
        [ForeignKey("productCategoryId")]
        public ProductCategory? productCategory { get; set; }

        public ICollection<EquipmentManager> managers { get; set; } = new List<EquipmentManager>();
        public ICollection<EquipmentMaintenance> maintenances { get; set; } = new List<EquipmentMaintenance>();
    }
}