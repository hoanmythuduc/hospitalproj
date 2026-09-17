using THUCTAP.Models;
using System.Threading.Tasks;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IMaintenanceScheduleRepository
    {
        Task<EquipmentMaintenanceSchedule?> GetByIdAsync(int id);
        Task CreateAsync(EquipmentMaintenanceSchedule entity);
        Task UpdateAsync(EquipmentMaintenanceSchedule entity);
        Task<PagedResult<MaintenanceScheduleResponseDto>> GetAllAsync(MaintenanceScheduleFilterRequest filter);
        Task DeleteAsync(EquipmentMaintenanceSchedule entity);
    }
}