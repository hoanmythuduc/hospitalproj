using THUCTAP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IMaintenanceLogRepository
    {
        Task<EquipmentMaintenanceLog?> GetByIdAsync(int id);
        Task<List<EquipmentMaintenanceLog>> GetLogsByMonthAsync(int equipmentId, int month, int year);
        Task CreateAsync(EquipmentMaintenanceLog entity);
        Task UpdateAsync(EquipmentMaintenanceLog entity);
        Task<PagedResult<MaintenanceLogResponseDto>> GetAllAsync(MaintenanceLogFilterRequest filter);
        Task DeleteAsync(EquipmentMaintenanceLog entity);
    }
}