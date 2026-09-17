using System.ComponentModel.DataAnnotations;

namespace THUCTAP.ViewModels
{
    public class CustomerMasterFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public string? supplierName { get; set; }
        public int? categoryId { get; set; }
    }

    public class CustomerMasterRequest
    {
        [Required(ErrorMessage = "Tên Khách hàng/Nhà cung cấp không được để trống!")]
        public string supplierName { get; set; } = string.Empty;
        public string supplierAddress { get; set; } = string.Empty;
        public string engineerInCharge { get; set; } = string.Empty;
        public string supplierPhone { get; set; } = string.Empty;
        public string supplierEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập mã danh mục (categoryId)!")]
        public int categoryId { get; set; }
    }

    public class CustomerMasterResponseDto
    {
        public int id { get; set; }
        public string supplierName { get; set; } = string.Empty;
        public string supplierAddress { get; set; } = string.Empty;
        public string engineerInCharge { get; set; } = string.Empty;
        public string supplierPhone { get; set; } = string.Empty;
        public string supplierEmail { get; set; } = string.Empty;
        public int categoryId { get; set; }
        public string categoryName { get; set; } = string.Empty;
    }
}