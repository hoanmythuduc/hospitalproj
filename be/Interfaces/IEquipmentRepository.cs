using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<PagedResult<EquipmentResponseDto>> GetAllAsync(EquipmentFilterRequest filter);
        Task<Equipment?> GetByIdAsync(int id);
        Task CreateAsync(Equipment entity);
        Task UpdateAsync(Equipment entity);
        Task DeleteAsync(Equipment entity);
    }
}