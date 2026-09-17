using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IProductCategoryService
    {
        Task<PagedResult<ProductCategoryResponseDto>>GetAllAsync(ProductCategoryFilterRequest filter);
        Task<ProductCategoryResponseDto?>GetByIdAsync(int id);
        Task<ProductCategoryResponseDto>CreateAsync(ProductCategoryRequest request);
        Task<ProductCategoryResponseDto?>UpdateAsync(int id, ProductCategoryRequest request);
        Task<bool> DeleteAsync(int id);
        Task<int> ImportExcelAsync(IFormFile file);
    }
}