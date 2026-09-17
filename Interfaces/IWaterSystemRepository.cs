using System.Threading.Tasks;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IWaterSystemRepository
    {
        Task<PagedResult<WaterSystemLogResponse>> GetAllAsync(WaterSystemFilterRequest filter);
        Task<WaterSystemLog?> GetMonthlyLogAsync(int equipmentId, int month, int year);
        Task<WaterSystemLog?> GetByIdAsync(int id);
        Task CreateAsync(WaterSystemLog entity);
        Task UpdateAsync(WaterSystemLog entity);
        Task DeleteAsync(WaterSystemLog entity);
    }
}