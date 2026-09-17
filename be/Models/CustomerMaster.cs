namespace THUCTAP.Models
{
    public class CustomerMaster : BaseModel
    {
        public string supplierName { get; set; } = string.Empty;
        public string supplierAddress { get; set; } = string.Empty;
        public string engineerInCharge { get; set; } = string.Empty;
        public string supplierPhone { get; set; } = string.Empty;
        public string supplierEmail { get; set; } = string.Empty;

        public int categoryId { get; set; }
        public CustomerCategory? Category { get; set; }
    }
}