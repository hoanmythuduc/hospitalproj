using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface ICustomerCategoryService
    {
        Task<PagedResult<CustomerCategoryResponseDto>>GetAllAsync(CustomerCategoryFilterRequest filter);
        Task<CustomerCategoryResponseDto>CreateAsync(CustomerCategoryRequest request);
        Task<CustomerCategoryResponseDto?>UpdateAsync(int id, CustomerCategoryRequest request);
        Task<bool>DeleteAsync(int id);
        Task<int> ImportExcelAsync(IFormFile file);
    }
}