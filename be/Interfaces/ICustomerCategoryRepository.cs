using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface ICustomerCategoryRepository
    {
        Task<PagedResult<CustomerCategoryResponseDto>>GetAllAsync(CustomerCategoryFilterRequest filter);
        Task<CustomerCategory?>GetByIdAsync(int id);

        Task CreateAsync(CustomerCategory entity);
        Task UpdateAsync(CustomerCategory entity);
        Task DeleteAsync(CustomerCategory entity);
    }
}