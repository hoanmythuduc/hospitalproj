using THUCTAP.ViewModels;
using System.Threading.Tasks;

namespace THUCTAP.Interfaces
{
    public interface IMaintenanceLogService
    {
        Task<MaintenanceLogResponseDto> CreateLogAsync(MaintenanceLogRequest request);
        Task<bool> InspectLogAsync(int id, InspectLogRequest request);
        Task<bool> ReviewLogAsync(int id, ReviewLogRequest request);
        Task<MonthlyMaintenanceReportDto> GetMonthlyReportAsync(int equipmentId, int month, int year);
        Task<PagedResult<MaintenanceLogResponseDto>> GetAllAsync(MaintenanceLogFilterRequest filter);
        Task<MaintenanceLogResponseDto?> GetByIdAsync(int id);
        Task<MaintenanceLogResponseDto?> UpdateLogAsync(int id, MaintenanceLogRequest request);
        Task<bool> DeleteLogAsync(int id);
    }
}