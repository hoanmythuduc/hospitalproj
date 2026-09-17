using THUCTAP.ViewModels;
using System.Threading.Tasks;

namespace THUCTAP.Interfaces
{
    public interface IMaintenanceScheduleService
    {
        Task<MaintenanceScheduleResponseDto> CreateScheduleAsync(MaintenanceScheduleRequest request);
        Task<bool> ApproveScheduleAsync(int id, ApproveScheduleRequest request);
        Task<PagedResult<MaintenanceScheduleResponseDto>> GetAllAsync(MaintenanceScheduleFilterRequest filter);
        Task<MaintenanceScheduleResponseDto?> GetByIdAsync(int id);
        Task<MaintenanceScheduleResponseDto?> UpdateScheduleAsync(int id, MaintenanceScheduleRequest request);
        Task<bool> DeleteScheduleAsync(int id);
    }
}