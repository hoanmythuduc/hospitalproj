using System.Threading.Tasks;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface ICustomerMasterService
    {
        Task<PagedResult<CustomerMasterResponseDto>>GetAllAsync(CustomerMasterFilterRequest filter);
        Task<CustomerMasterResponseDto>CreateAsync(CustomerMasterRequest request);
        Task<CustomerMasterResponseDto?>UpdateAsync(int id, CustomerMasterRequest request);
        Task<bool>DeleteAsync(int id);
        Task<int> ImportExcelAsync(IFormFile file);
    }
}