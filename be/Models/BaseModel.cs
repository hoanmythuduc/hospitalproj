using System.ComponentModel.DataAnnotations;
using THUCTAP.Interfaces;

namespace THUCTAP.Models
{
    public abstract class BaseModel : IAuditableEntity
    {
        [Key]
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? createdBy { get; set; }
        public string? updatedBy { get; set; }
        public bool isActive { get; set; } = true;
    }
}