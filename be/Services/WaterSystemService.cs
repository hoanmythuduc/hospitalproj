using System;
using System.Collections.Generic;
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
    public class WaterSystemService : IWaterSystemService
    {
        private readonly IWaterSystemRepository _repository;
        private readonly AppDbContext _context; 
        private readonly ILogger<WaterSystemService> _logger; 

        public WaterSystemService(IWaterSystemRepository repository, AppDbContext context, ILogger<WaterSystemService> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<PagedResult<WaterSystemLogResponse>> GetAllAsync(WaterSystemFilterRequest filter)
        {
            try
            {
                return await _repository.GetAllAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Nhật ký hệ thống nước");
                throw;
            }
        }

        public async Task<WaterSystemLogResponse?> GetByIdAsync(int id)
        {
            try
            {
                var log = await _repository.GetByIdAsync(id);
                return log?.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy chi tiết Nhật ký hệ thống nước ID: {LogId}", id);
                throw;
            }
        }

        public async Task<WaterSystemLogResponse?> GetMonthlyLogAsync(int equipmentId, int month, int year)
        {
            try
            {
                var log = await _repository.GetMonthlyLogAsync(equipmentId, month, year);
                return log?.ToResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy Nhật ký tháng. EquipmentId: {EquipmentId}, Tháng: {Month}, Năm: {Year}", equipmentId, month, year);
                throw;
            }
        }

        public async Task<string> SaveDailyLogAsync(SaveDailyLogRequest request)
        {
            try
            {
                // 1. TÌM ID THIẾT BỊ BẰNG MÃ CODE
                var equipment = await _context.Equipment
                    .Include(x => x.productCategory)
                    .FirstOrDefaultAsync(x => x.productCategory.equipmentCode == request.equipmentCode);

                if (equipment == null)
                    throw new Exception($"Lỗi: Không tìm thấy thiết bị nào có mã '{request.equipmentCode}' trong hệ thống!");

                var log = await _repository.GetMonthlyLogAsync(equipment.id, request.month, request.year);

                if (log == null)
                {
                    log = new WaterSystemLog
                    {
                        equipmentId = equipment.id,
                        month = request.month,
                        year = request.year,
                        status = WaterLogStatus.Tracking,
                        preparerId = request.trackerId,

                        allowedRange = request.allowedRange ?? "",
                        trackingTime = request.trackingTime ?? "",

                        dailyLogs = new List<WaterSystemDailyLog>()
                    };

                    int daysInMonth = DateTime.DaysInMonth(request.year, request.month);
                    for (int i = 1; i <= daysInMonth; i++)
                    {
                        log.dailyLogs.Add(new WaterSystemDailyLog { day = i, usValue = "", trackerId = null });
                    }

                    await _repository.CreateAsync(log);
                    
                    _logger.LogInformation("Đã tự động khởi tạo phiếu theo dõi tháng mới cho hệ thống nước {EquipmentCode} (Tháng {Month}/{Year})", request.equipmentCode, request.month, request.year);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(request.allowedRange)) log.allowedRange = request.allowedRange;
                    if (!string.IsNullOrWhiteSpace(request.trackingTime)) log.trackingTime = request.trackingTime;
                }

                if (log.status != WaterLogStatus.Tracking && log.status != WaterLogStatus.PendingInspection)
                    throw new Exception("Phiếu đã được kiểm tra hoặc phê duyệt! Vui lòng yêu cầu cấp trên Từ chối/Mở khóa trước khi sửa số liệu.");

                var targetDay = log.dailyLogs.FirstOrDefault(d => d.day == request.day);
                if (targetDay != null)
                {
                    targetDay.usValue = request.usValue;
                    targetDay.trackerId = request.trackerId;
                    await _repository.UpdateAsync(log);
                    return "Đã lưu chỉ số thành công.";
                }

                throw new Exception("Ngày không hợp lệ.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lưu chỉ số ngày {Day}/{Month}/{Year} cho hệ thống nước {EquipmentCode}", request.day, request.month, request.year, request.equipmentCode);
                throw;
            }
        }

        public async Task<bool> InspectLogAsync(int id, InspectWaterLogRequest request)
        {
            try
            {
                var log = await _repository.GetByIdAsync(id);
                if (log == null) return false;

                if (request.isApproved)
                {
                    // TIẾN LÊN: Kiểm tra (Cấp 1)
                    if (log.status != WaterLogStatus.Tracking && log.status != WaterLogStatus.PendingInspection)
                        throw new Exception("Phiếu không ở trạng thái Đang theo dõi, không thể nộp kiểm tra!");

                    log.status = WaterLogStatus.PendingReview;
                }
                else
                {
                    // TỪ CHỐI / MỞ KHÓA (Cấp 1)
                    if (log.status != WaterLogStatus.Tracking && log.status != WaterLogStatus.PendingInspection && log.status != WaterLogStatus.PendingReview)
                        throw new Exception("Không thể từ chối phiếu ở trạng thái này.");

                    log.status = WaterLogStatus.Tracking; // Đạp về Tracking cho nhân viên sửa
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
                _logger.LogError(ex, "Lỗi khi Trưởng khoa kiểm tra (Inspect) Nhật ký hệ thống nước ID: {LogId}", id);
                throw;
            }
        }

        public async Task<bool> ReviewLogAsync(int id, ReviewWaterLogRequest request)
        {
            try
            {
                var log = await _repository.GetByIdAsync(id);
                if (log == null) return false;

                if (request.isApproved)
                {
                    // TIẾN LÊN: Phê duyệt (Cấp 2)
                    if (log.status != WaterLogStatus.PendingReview)
                        throw new Exception("Phiếu chưa được kiểm tra, Giám đốc không thể phê duyệt!");

                    log.status = WaterLogStatus.Completed;
                }
                else
                {
                    // TỪ CHỐI / MỞ KHÓA (Cấp 2 - Giám đốc "quay xe")
                    if (log.status != WaterLogStatus.PendingReview && log.status != WaterLogStatus.Completed)
                        throw new Exception("Chỉ có thể từ chối khi phiếu đang chờ duyệt hoặc đã hoàn tất.");

                    log.status = WaterLogStatus.PendingInspection; // Đạp về cho Quản lý / KTV sửa
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
                _logger.LogError(ex, "Lỗi khi Giám đốc phê duyệt (Review) Nhật ký hệ thống nước ID: {LogId}", id);
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
                _logger.LogError(ex, "Lỗi khi xóa Nhật ký hệ thống nước ID: {LogId}", id);
                throw;
            }
        }
    }
}