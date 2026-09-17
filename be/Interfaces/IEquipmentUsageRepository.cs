using System.Threading.Tasks;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IEquipmentUsageRepository
    {
        Task<PagedResult<EquipmentUsageLogResponse>> GetAllAsync(EquipmentUsageFilterRequest filter);
        Task<EquipmentUsageLog?> GetWeeklyLogAsync(int equipmentId, int year, int month, int weekOfMonth);
        Task<EquipmentUsageLog?> GetByIdAsync(int id);
        Task CreateAsync(EquipmentUsageLog entity);
        Task UpdateAsync(EquipmentUsageLog entity);
        Task DeleteAsync(EquipmentUsageLog entity);
    }
}