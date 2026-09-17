using System.Threading.Tasks;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface ICustomerMasterRepository
    {
        Task<PagedResult<CustomerMasterResponseDto>>GetAllAsync(CustomerMasterFilterRequest filter);
        Task<CustomerMaster?>GetByIdAsync(int id);

        Task CreateAsync(CustomerMaster entity);
        Task UpdateAsync(CustomerMaster entity);
        Task DeleteAsync(CustomerMaster entity);
    }
}