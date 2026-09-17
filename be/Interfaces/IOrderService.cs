using System.Threading.Tasks;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IOrderService
    {
        Task<PagedResult<OrderResponseDto>> GetAllAsync(OrderFilterRequest filter);
        Task<OrderResponseDto> CreateAsync(OrderRequest request);
        Task<OrderResponseDto?> UpdateAsync(int id, OrderRequest request);
        Task<bool> DeleteAsync(int id);
    }
}