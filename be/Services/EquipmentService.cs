using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _repository;

        public EquipmentService(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<EquipmentResponseDto>> GetAllAsync(EquipmentFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<EquipmentResponseDto> CreateAsync(EquipmentRequest request)
        {
            var entity = request.ToEquipment();
            await _repository.CreateAsync(entity);
            return entity.ToEquipmentResponse();
        }

        public async Task<EquipmentResponseDto?> UpdateAsync(int id, EquipmentRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.UpdateEquipment(request);
            await _repository.UpdateAsync(entity);

            return entity.ToEquipmentResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }
        public async Task<EquipmentResponseDto?> GetByIdAsync(int id)
        {
            // Gọi Repository để lấy dữ liệu thô (đã include danh sách con)
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            // Biến đổi entity thành DTO (tự động đẻ ra các dấu "X" nhờ Mapper)
            return entity.ToEquipmentResponse();
        }
    }
}