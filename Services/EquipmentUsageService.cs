using System;
using System.Linq;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;

namespace THUCTAP.Services
{
    public class EquipmentUsageService : IEquipmentUsageService
    {
        private readonly IEquipmentUsageRepository _repository;
        public EquipmentUsageService(IEquipmentUsageRepository repository) { _repository = repository; }

        public async Task<PagedResult<EquipmentUsageLogResponse>> GetAllAsync(EquipmentUsageFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<EquipmentUsageLogResponse?> GetByIdAsync(int id)
        {
            var log = await _repository.GetByIdAsync(id);
            return log?.ToResponse();
        }

        public async Task<EquipmentUsageLogResponse?> GetWeeklyLogAsync(int equipmentId, int year, int month, int weekOfMonth)
        {
            var log = await _repository.GetWeeklyLogAsync(equipmentId, year, month, weekOfMonth);
            return log?.ToResponse();
        }

        public async Task<string> SaveDailyLogAsync(SaveUsageDailyLogRequest request)
        {
            var log = await _repository.GetWeeklyLogAsync(request.equipmentId, request.year, request.month, request.weekOfMonth);

            if (log == null)
            {
                log = request.ToEntity();

                // Tự động sinh ra 7 ngày (Thứ 2 = 2, ..., Chủ nhật = 8)
                for (int i = 2; i <= 8; i++)
                {
                    log.dailyLogs.Add(new EquipmentUsageDailyLog
                    {
                        dayOfWeek = i,
                        logDate = request.logDate
                    });
                }
                await _repository.CreateAsync(log);
            }

            if (log.status != UsageLogStatus.Tracking && log.status != UsageLogStatus.PendingInspection)
                throw new Exception("Phiếu tuần này đã được kiểm tra hoặc phê duyệt, không thể sửa dữ liệu.");

            var targetDay = log.dailyLogs.FirstOrDefault(d => d.dayOfWeek == request.dayOfWeek);
            if (targetDay != null)
            {
                targetDay.UpdateDailyLog(request);
                await _repository.UpdateAsync(log);
                return "Lưu nhật ký sử dụng thiết bị thành công.";
            }

            throw new Exception("Thứ trong tuần không hợp lệ (Chỉ nhận từ 2 đến 8).");
        }

        public async Task<bool> InspectLogAsync(int id, ProcessUsageLogRequest request)
        {
            var log = await _repository.GetByIdAsync(id);
            if (log == null || log.status == UsageLogStatus.Completed) return false;

            log.status = request.isApproved ? UsageLogStatus.PendingReview : UsageLogStatus.Tracking;
            log.inspectorId = request.userId;
            log.inspectionDate = DateTime.Now;

            await _repository.UpdateAsync(log);
            return true;
        }

        public async Task<bool> ReviewLogAsync(int id, ProcessUsageLogRequest request)
        {
            var log = await _repository.GetByIdAsync(id);
            if (log == null || log.status != UsageLogStatus.PendingReview) return false;

            log.status = request.isApproved ? UsageLogStatus.Completed : UsageLogStatus.PendingInspection;
            log.reviewerId = request.userId;
            log.reviewDate = DateTime.Now;

            await _repository.UpdateAsync(log);
            return true;
        }

        public async Task<bool> DeleteLogAsync(int id)
        {
            var log = await _repository.GetByIdAsync(id);
            if (log == null) return false;

            await _repository.DeleteAsync(log);
            return true;
        }
    }
}