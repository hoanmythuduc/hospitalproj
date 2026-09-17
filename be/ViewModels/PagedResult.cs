namespace THUCTAP.ViewModels
{
    public class PagedResult<T>
    {
        public List<T> items { get; set; } = new List<T>();
        public int totalRecords { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

        // Tự động tính toán tổng số trang
        public int totalPages => (int)Math.Ceiling(totalRecords / (double)pageSize);

        // HÀM MAP THẦN THÁNH: Giúp ánh xạ từ Entity thô sang DTO siêu nhanh trên RAM
        public PagedResult<TResult> Map<TResult>(Func<T, TResult> mapFunc)
        {
            return new PagedResult<TResult>
            {
                items = this.items.Select(mapFunc).ToList(),
                totalRecords = this.totalRecords,
                pageIndex = this.pageIndex,
                pageSize = this.pageSize
            };
        }
    }
}