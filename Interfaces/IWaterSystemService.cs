using System.Threading.Tasks;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IWaterSystemService
    {
        Task<PagedResult<WaterSystemLogResponse>> GetAllAsync(WaterSystemFilterRequest filter);
        Task<WaterSystemLogResponse?> GetByIdAsync(int id);
        Task<WaterSystemLogResponse?> GetMonthlyLogAsync(int equipmentId, int month, int year);
        Task<string> SaveDailyLogAsync(SaveDailyLogRequest request);
        Task<bool> InspectLogAsync(int id, ProcessWaterLogRequest request);
        Task<bool> ReviewLogAsync(int id, ProcessWaterLogRequest request);
        Task<bool> DeleteLogAsync(int id);
    }
}