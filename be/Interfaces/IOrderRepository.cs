using System.Threading.Tasks;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IOrderRepository
    {
        Task<PagedResult<OrderResponseDto>> GetAllAsync(OrderFilterRequest filter);
        Task<Order?> GetByIdAsync(int id);
        Task CreateAsync(Order entity);
        Task UpdateAsync(Order entity);
        Task DeleteAsync(Order entity);
    }
}