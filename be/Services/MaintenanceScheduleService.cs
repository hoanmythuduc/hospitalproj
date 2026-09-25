using System;
using System.Linq;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;
using Serilog;
using THUCTAP.Data;
using Microsoft.Extensions.Logging; 

namespace THUCTAP.Services
{
    public class MaintenanceScheduleService : IMaintenanceScheduleService
    {
        private readonly IMaintenanceScheduleRepository _repository;
        private readonly AppDbContext _context;
        private readonly ILogger<MaintenanceScheduleService> _logger;

        public MaintenanceScheduleService(IMaintenanceScheduleRepository repository, AppDbContext context, ILogger<MaintenanceScheduleService> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<MaintenanceScheduleResponseDto> CreateScheduleAsync(MaintenanceScheduleRequest request)
        {
            try
            {
                var equipment = _context.Equipment
                    .FirstOrDefault(e => e.productCategory.equipmentCode == request.equipmentCode);

                if (equipment == null)
                    throw new Exception($"Không tìm thấy thiết bị có mã {request.equipmentCode}");

                var entity = request.ToEntity();

                entity.equipmentId = equipment.id;

                await _repository.CreateAsync(entity);

                return entity.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo Kế hoạch bảo trì mới cho thiết bị mã: {EquipmentCode}", request.equipmentCode);
                throw;
            }
        }

        public async Task<bool> ApproveScheduleAsync(int id, ApproveScheduleRequest request) 
        {
            try
            {
                var schedule = await _repository.GetByIdAsync(id);
                if (schedule == null) return false;

                if (request.isApproved)
                {
                    if (schedule.status != MaintenanceScheduleStatus.PendingApproval)
                        throw new Exception("Kế hoạch này chưa được trình lên hoặc đã duyệt, không thể phê duyệt!");

                    schedule.status = MaintenanceScheduleStatus.Approved;
                }
                else
                {
                    if (schedule.status != MaintenanceScheduleStatus.PendingApproval && schedule.status != MaintenanceScheduleStatus.Approved)
                        throw new Exception("Chỉ có thể từ chối/hủy duyệt khi kế hoạch đang chờ duyệt hoặc đã phê duyệt.");

                    schedule.status = MaintenanceScheduleStatus.Rejected;
                }
                if (request.detail != null)
                {
                    schedule.detail = request.detail;
                }

                schedule.approverId = request.approverId; 
                schedule.updatedAt = DateTime.Now; 

                await _repository.UpdateAsync(schedule);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi Giám đốc Phê duyệt/Từ chối Kế hoạch bảo trì ID: {ScheduleId}", id);
                throw;
            }
        }

        public async Task<PagedResult<MaintenanceScheduleResponseDto>> GetAllAsync(MaintenanceScheduleFilterRequest filter)
        {
            try
            {
                return await _repository.GetAllAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Kế hoạch bảo trì");
                throw;
            }
        }

        public async Task<MaintenanceScheduleResponseDto?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                return entity.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy chi tiết Kế hoạch bảo trì ID: {ScheduleId}", id);
                throw;
            }
        }

        public async Task<MaintenanceScheduleResponseDto?> UpdateScheduleAsync(int id, MaintenanceScheduleRequest request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                if (entity.status == MaintenanceScheduleStatus.Approved)
                {
                    throw new Exception("Kế hoạch này đã được Giám đốc phê duyệt. Bạn không thể tự ý chỉnh sửa!");
                }

                var equipment = _context.Equipment
                    .FirstOrDefault(e => e.productCategory.equipmentCode == request.equipmentCode);

                if (equipment == null)
                    throw new Exception($"Không tìm thấy thiết bị có mã {request.equipmentCode}");

                entity.UpdateEntity(request);

                entity.equipmentId = equipment.id;
                entity.status = MaintenanceScheduleStatus.PendingApproval;

                await _repository.UpdateAsync(entity);

                return entity.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật Kế hoạch bảo trì ID: {ScheduleId}", id);
                throw;
            }
        }

        public async Task<bool> DeleteScheduleAsync(int id)
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
                _logger.LogError(ex, "Lỗi khi xóa Kế hoạch bảo trì ID: {ScheduleId}", id);
                throw;
            }
        }
    }
}