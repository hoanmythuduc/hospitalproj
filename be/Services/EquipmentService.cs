using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.ViewModels;
using Microsoft.Extensions.Logging; 

namespace THUCTAP.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _repository;
        private readonly ILogger<EquipmentService> _logger; 

        public EquipmentService(IEquipmentRepository repository, ILogger<EquipmentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PagedResult<EquipmentResponseDto>> GetAllAsync(EquipmentFilterRequest filter)
        {
            try
            {
                return await _repository.GetAllAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Equipment (Thiết bị) từ cơ sở dữ liệu");
                throw;
            }
        }

        public async Task<EquipmentResponseDto> CreateAsync(EquipmentRequest request)
        {
            try
            {
                var entity = request.ToEquipment();
                await _repository.CreateAsync(entity);
                return entity.ToEquipmentResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo mới Equipment (Thiết bị)");
                throw;
            }
        }

        public async Task<EquipmentResponseDto?> UpdateAsync(int id, EquipmentRequest request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                entity.UpdateEquipment(request);
                await _repository.UpdateAsync(entity);

                return entity.ToEquipmentResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật Equipment (Thiết bị) có ID: {Id}", id);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return false;

                await _repository.DeleteAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa Equipment (Thiết bị) có ID: {Id}", id);
                throw;
            }
        }
        
        public async Task<EquipmentResponseDto?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                return entity.ToEquipmentResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin chi tiết Equipment (Thiết bị) có ID: {Id}", id);
                throw;
            }
        }
    }
}