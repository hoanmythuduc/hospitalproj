using System.ComponentModel.DataAnnotations.Schema;
namespace THUCTAP.Models
{
    public class CustomerCategory : BaseModel
    {
        public string groupName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal discount { get; set; }
        
    }
}