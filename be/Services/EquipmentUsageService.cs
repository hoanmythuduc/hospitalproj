using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using THUCTAP.Data; 
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;
using Microsoft.Extensions.Logging;

namespace THUCTAP.Services
{
    public class EquipmentUsageService : IEquipmentUsageService
    {
        private readonly IEquipmentUsageRepository _repository;
        private readonly AppDbContext _context; 
        private readonly ILogger<EquipmentUsageService> _logger;

        public EquipmentUsageService(IEquipmentUsageRepository repository, AppDbContext context, ILogger<EquipmentUsageService> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<PagedResult<EquipmentUsageLogResponse>> GetAllAsync(EquipmentUsageFilterRequest filter)
        {
            try
            {
                return await _repository.GetAllAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Nhật ký sử dụng thiết bị");
                throw;
            }
        }

        public async Task<EquipmentUsageLogResponse?> GetByIdAsync(int id)
        {
            try
            {
                var log = await _repository.GetByIdAsync(id);
                return log?.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy chi tiết Nhật ký sử dụng ID: {LogId}", id);
                throw;
            }
        }

        public async Task<EquipmentUsageLogResponse?> GetWeeklyLogAsync(int equipmentId, int year, int month, int weekOfMonth)
        {
            try
            {
                var log = await _repository.GetWeeklyLogAsync(equipmentId, year, month, weekOfMonth);
                return log?.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy Nhật ký tuần. EquipmentId: {EquipmentId}, Tuần: {Week}, Tháng: {Month}, Năm: {Year}", equipmentId, weekOfMonth, month, year);
                throw;
            }
        }

        public async Task<string> SaveDailyLogAsync(SaveUsageDailyLogRequest request)
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

                var log = await _repository.GetWeeklyLogAsync(equipment.id, request.year, request.month, request.weekOfMonth);

                if (log == null)
                {
                    log = request.ToEntity();
                    log.equipmentId = equipment.id;

                    for (int i = 2; i <= 8; i++)
                    {
                        log.dailyLogs.Add(new EquipmentUsageDailyLog
                        {
                            dayOfWeek = i,
                            logDate = request.logDate 
                        });
                    }
                    await _repository.CreateAsync(log);
                    _logger.LogInformation("Đã tự động khởi tạo phiếu theo dõi tuần mới cho thiết bị {EquipmentCode} (Tuần {Week}/{Month}/{Year})", request.equipmentCode, request.weekOfMonth, request.month, request.year);
                }

                if (log.status != UsageLogStatus.Tracking && log.status != UsageLogStatus.PendingInspection)
                    throw new Exception("Phiếu tuần này đã được nộp kiểm tra hoặc phê duyệt, không thể tự ý sửa dữ liệu.");

                var targetDay = log.dailyLogs.FirstOrDefault(d => d.dayOfWeek == request.dayOfWeek);
                if (targetDay != null)
                {
                    targetDay.UpdateDailyLog(request);
                    await _repository.UpdateAsync(log);
                    return "Lưu nhật ký sử dụng thiết bị thành công.";
                }

                throw new Exception("Thứ trong tuần không hợp lệ (Chỉ nhận từ 2 đến 8).");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lưu Nhật ký ngày (Thứ {DayOfWeek}) cho thiết bị {EquipmentCode}", request.dayOfWeek, request.equipmentCode);
                throw;
            }
        }

        public async Task<bool> InspectLogAsync(int id, InspectUsageLogRequest request)
        {
            try
            {
                var log = await _repository.GetByIdAsync(id);
                if (log == null) return false;

                if (request.isApproved)
                {
                    if (log.status != UsageLogStatus.Tracking)
                        throw new Exception("Phiếu không ở trạng thái Đang theo dõi, không thể nộp kiểm tra!");

                    log.status = UsageLogStatus.PendingReview;
                }
                else
                {
                    if (log.status != UsageLogStatus.Tracking && log.status != UsageLogStatus.PendingReview)
                        throw new Exception("Không thể từ chối phiếu ở trạng thái này.");

                    log.status = UsageLogStatus.Tracking;
                }
                if (request.detail != null)
                {
                    log.inspectorDetail = request.detail;
                }

                log.inspectorId = request.inspectorId;
                log.inspectionDate = DateTime.Now;

                await _repository.UpdateAsync(log);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xử lý Nộp/Kiểm tra (Inspect) phiếu theo dõi sử dụng ID: {LogId}", id);
                throw;
            }
        }

        public async Task<bool> ReviewLogAsync(int id, ReviewUsageLogRequest request)
        {
            try
            {
                var log = await _repository.GetByIdAsync(id);
                if (log == null) return false;

                if (request.isApproved)
                {
                    if (log.status != UsageLogStatus.PendingReview)
                        throw new Exception("Phiếu chưa được kiểm tra, Giám đốc không thể phê duyệt!");

                    log.status = UsageLogStatus.Completed;
                }
                else
                {
                    if (log.status != UsageLogStatus.PendingReview && log.status != UsageLogStatus.Completed)
                        throw new Exception("Chỉ có thể từ chối khi phiếu đang chờ duyệt hoặc đã hoàn tất.");
                    
                    log.status = UsageLogStatus.PendingInspection;
                }
                if (request.detail != null)
                {
                    log.reviewerDetail = request.detail;
                }

                log.reviewerId = request.reviewerId;
                log.reviewDate = DateTime.Now;

                await _repository.UpdateAsync(log);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi Giám đốc Phê duyệt/Từ chối (Review) phiếu theo dõi sử dụng ID: {LogId}", id);
                throw;
            }
        }

        public async Task<bool> DeleteLogAsync(int id)
        {
            try
            {
                var log = await _repository.GetByIdAsync(id);
                if (log == null) return false;

                await _repository.DeleteAsync(log);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa Phiếu theo dõi sử dụng ID: {LogId}", id);
                throw;
            }
        }
    }
}