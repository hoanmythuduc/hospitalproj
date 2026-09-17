using System;

namespace THUCTAP.ViewModels
{
    public class OrderFilterRequest : PagingRequestBase
    {
        public int id { get; set; }
        public string? orderNumber { get; set; }
        public int? customerId { get; set; }
    }

    public class OrderRequest
    {
        public string orderNumber { get; set; } = string.Empty;
        public DateTime orderDate { get; set; }
        public int customerId { get; set; }
        public decimal estimatedTotal { get; set; }
    }

    public class OrderResponseDto
    {
        public int id { get; set; }
        public string orderNumber { get; set; } = string.Empty;
        public DateTime orderDate { get; set; }
        public int customerId { get; set; }

        public string customerName { get; set; } = string.Empty;
        public decimal estimatedTotal { get; set; }
    }
}