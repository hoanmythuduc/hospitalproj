using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<PagedResult<ProductCategoryResponseDto>>GetAllAsync(ProductCategoryFilterRequest filter);
        Task<ProductCategory?>GetByIdAsync(int id);

        Task CreateAsync(ProductCategory entity);
        Task UpdateAsync(ProductCategory entity);
        Task DeleteAsync(ProductCategory entity);
    }
}