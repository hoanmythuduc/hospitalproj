using System.Threading.Tasks;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IEquipmentUsageService
    {
        Task<PagedResult<EquipmentUsageLogResponse>> GetAllAsync(EquipmentUsageFilterRequest filter);
        Task<EquipmentUsageLogResponse?> GetByIdAsync(int id);
        Task<EquipmentUsageLogResponse?> GetWeeklyLogAsync(int equipmentId, int year, int month, int weekOfMonth);
        Task<string> SaveDailyLogAsync(SaveUsageDailyLogRequest request);
        Task<bool> InspectLogAsync(int id, ProcessUsageLogRequest request);
        Task<bool> ReviewLogAsync(int id, ProcessUsageLogRequest request);
        Task<bool> DeleteLogAsync(int id);
    }
}