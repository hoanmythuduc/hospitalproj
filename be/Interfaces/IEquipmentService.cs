using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IEquipmentService
    {
        Task<PagedResult<EquipmentResponseDto>> GetAllAsync(EquipmentFilterRequest filter);
        Task<EquipmentResponseDto> CreateAsync(EquipmentRequest request);
        Task<EquipmentResponseDto?> UpdateAsync(int id, EquipmentRequest request);
        Task<EquipmentResponseDto?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}