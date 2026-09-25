using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;
using THUCTAP.Data; 
using Microsoft.EntityFrameworkCore; 
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging; 

namespace THUCTAP.Services
{
    public class MaintenanceLogService : IMaintenanceLogService
    {
        private readonly IMaintenanceLogRepository _repository;
        private readonly AppDbContext _context; 
        private readonly ILogger<MaintenanceLogService> _logger;

        public MaintenanceLogService(IMaintenanceLogRepository repository, AppDbContext context, ILogger<MaintenanceLogService> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<MaintenanceLogResponseDto> CreateLogAsync(MaintenanceLogRequest request)
        {
            try
            {
                var equipment = await _context.Equipment
                    .Include(x => x.productCategory)
                    .FirstOrDefaultAsync(x => x.productCategory.equipmentCode == request.equipmentCode);

                if (equipment == null)
                {
                    throw new Exception($"Lỗi: Không tìm thấy thiết bị nào có mã '{request.equipmentCode}' trong hệ thống!");
                }

                var entity = request.ToEntity();

                entity.equipmentId = equipment.id;
                entity.status = MaintenanceLogStatus.PendingInspection;

                await _repository.CreateAsync(entity);

                var createdEntity = await _repository.GetByIdAsync(entity.id);
                return createdEntity!.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo Nhật ký bảo trì mới cho thiết bị có mã: {EquipmentCode}", request.equipmentCode);
                throw;
            }
        }

        public async Task<bool> InspectLogAsync(int id, InspectLogRequest request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return false;

                if (request.isApproved)
                {
                    if (entity.status != MaintenanceLogStatus.PendingInspection)
                        throw new Exception("Nhật ký chưa sẵn sàng hoặc đã được kiểm tra, không thể duyệt!");

                    entity.status = MaintenanceLogStatus.PendingReview;
                }
                else
                {
                    if (entity.status != MaintenanceLogStatus.PendingInspection && entity.status != MaintenanceLogStatus.PendingReview)
                        throw new Exception("Không thể từ chối phiếu ở trạng thái này.");

                    entity.status = MaintenanceLogStatus.PendingInspection;
                }
                if (request.detail != null)
                {
                    entity.inspectorDetail = request.detail;
                }

                entity.inspectorId = request.inspectorId;
                entity.inspectionDate = DateTime.Now;

                await _repository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi Trưởng khoa kiểm tra (Inspect) Nhật ký bảo trì ID: {LogId}", id);
                throw;
            }
        }

        public async Task<bool> ReviewLogAsync(int id, ReviewLogRequest request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return false;

                if (request.isApproved)
                {
                    if (entity.status != MaintenanceLogStatus.PendingReview)
                        throw new Exception("Nhật ký chưa được kiểm tra cấp 1, không thể phê duyệt!");

                    entity.status = MaintenanceLogStatus.Completed;
                }
                else
                {
                    if (entity.status != MaintenanceLogStatus.PendingReview && entity.status != MaintenanceLogStatus.Completed)
                        throw new Exception("Chỉ có thể từ chối khi nhật ký đang chờ duyệt hoặc đã hoàn tất.");

                    entity.status = MaintenanceLogStatus.PendingInspection;
                }
                if (request.detail != null)
                {
                    entity.reviewerDetail = request.detail;
                }

                entity.reviewerId = request.reviewerId;
                entity.reviewDate = DateTime.Now;

                await _repository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi Giám đốc phê duyệt (Review) Nhật ký bảo trì ID: {LogId}", id);
                throw;
            }
        }

        public async Task<MonthlyMaintenanceReportDto> GetMonthlyReportAsync(int equipmentId, int month, int year)
        {
            try
            {
                var logs = await _repository.GetLogsByMonthAsync(equipmentId, month, year);

                var firstLog = logs.FirstOrDefault();

                var inspectors = logs.Where(x => x.inspector != null)
                                     .Select(x => x.inspector!.userName)
                                     .Distinct().ToList();

                var reviewers = logs.Where(x => x.reviewer != null)
                                    .Select(x => x.reviewer!.userName)
                                    .Distinct().ToList();

                return new MonthlyMaintenanceReportDto
                {
                    equipmentId = equipmentId,
                    equipmentCode = firstLog?.equipment?.productCategory?.equipmentCode ?? string.Empty,
                    equipmentName = firstLog?.equipment?.productCategory?.equipmentName ?? string.Empty,
                    month = month,
                    year = year,

                    dailyTask = firstLog?.equipment?.productCategory?.dailyTask ?? string.Empty,
                    weeklyTask = firstLog?.equipment?.productCategory?.weeklyTask ?? string.Empty,
                    monthlyTask = firstLog?.equipment?.productCategory?.monthlyTask ?? string.Empty,
                    quarterlyTask = firstLog?.equipment?.productCategory?.quarterlyTask ?? string.Empty,
                    asNeededTask = firstLog?.equipment?.productCategory?.asNeededTask ?? string.Empty,

                    dailyLogs = logs.Select(x => x.ToResponse()).ToList(),
                    allInspectors = string.Join(", ", inspectors),
                    allReviewers = string.Join(", ", reviewers)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xuất Báo cáo bảo trì tháng {Month}/{Year} cho Thiết bị ID: {EquipmentId}", month, year, equipmentId);
                throw;
            }
        }

        public async Task<PagedResult<MaintenanceLogResponseDto>> GetAllAsync(MaintenanceLogFilterRequest filter)
        {
            try
            {
                return await _repository.GetAllAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Nhật ký bảo trì");
                throw;
            }
        }

        public async Task<MaintenanceLogResponseDto?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                return entity?.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy chi tiết Nhật ký bảo trì ID: {LogId}", id);
                throw;
            }
        }

        public async Task<MaintenanceLogResponseDto?> UpdateLogAsync(int id, MaintenanceLogRequest request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                if (entity.status != MaintenanceLogStatus.PendingInspection)
                    throw new Exception("Phiếu đã được kiểm tra hoặc phê duyệt! Yêu cầu cấp trên từ chối duyệt để mở khóa trước khi sửa.");

                var equipment = await _context.Equipment
                    .Include(x => x.productCategory)
                    .FirstOrDefaultAsync(x => x.productCategory.equipmentCode == request.equipmentCode);

                if (equipment == null)
                {
                    throw new Exception($"Lỗi: Không tìm thấy thiết bị nào có mã '{request.equipmentCode}' trong hệ thống!");
                }

                entity.UpdateEntity(request);
                entity.equipmentId = equipment.id;

                await _repository.UpdateAsync(entity);

                var updatedEntity = await _repository.GetByIdAsync(id);
                return updatedEntity!.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật Nhật ký bảo trì ID: {LogId}", id);
                throw;
            }
        }

        public async Task<bool> DeleteLogAsync(int id)
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
                _logger.LogError(ex, "Lỗi khi xóa Nhật ký bảo trì ID: {LogId}", id);
                throw;
            }
        }
    }
}