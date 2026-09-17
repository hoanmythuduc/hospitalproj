using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;

namespace THUCTAP.Services
{
    public class WaterSystemService : IWaterSystemService
    {
        private readonly IWaterSystemRepository _repository;
        public WaterSystemService(IWaterSystemRepository repository) { _repository = repository; }

        public async Task<PagedResult<WaterSystemLogResponse>> GetAllAsync(WaterSystemFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<WaterSystemLogResponse?> GetByIdAsync(int id)
        {
            var log = await _repository.GetByIdAsync(id);
            return log?.ToResponse();
        }

        public async Task<WaterSystemLogResponse?> GetMonthlyLogAsync(int equipmentId, int month, int year)
        {
            var log = await _repository.GetMonthlyLogAsync(equipmentId, month, year);
            return log?.ToResponse();
        }

        public async Task<string> SaveDailyLogAsync(SaveDailyLogRequest request)
        {
            var log = await _repository.GetMonthlyLogAsync(request.equipmentId, request.month, request.year);

            if (log == null)
            {
                log = new WaterSystemLog
                {
                    equipmentId = request.equipmentId,
                    month = request.month,
                    year = request.year,
                    status = WaterLogStatus.Tracking,
                    preparerId = request.trackerId,
                    allowedRange = "< 1,0",
                    trackingTime = "08:00",
                    dailyLogs = new List<WaterSystemDailyLog>()
                };

                int daysInMonth = DateTime.DaysInMonth(request.year, request.month);
                for (int i = 1; i <= daysInMonth; i++)
                {
                    log.dailyLogs.Add(new WaterSystemDailyLog { day = i, usValue = "", trackerId = null });
                }

                await _repository.CreateAsync(log);
            }

            if (log.status != WaterLogStatus.Tracking && log.status != WaterLogStatus.PendingInspection)
                throw new Exception("Phiếu đã được kiểm tra hoặc phê duyệt, không thể sửa chỉ số ngày.");

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

        public async Task<bool> InspectLogAsync(int id, ProcessWaterLogRequest request)
        {
            var log = await _repository.GetByIdAsync(id);
            if (log == null || log.status == WaterLogStatus.Completed) return false;

            log.status = request.isApproved ? WaterLogStatus.PendingReview : WaterLogStatus.Tracking;
            log.inspectorId = request.userId;
            log.inspectionDate = DateTime.Now;

            await _repository.UpdateAsync(log);
            return true;
        }

        public async Task<bool> ReviewLogAsync(int id, ProcessWaterLogRequest request)
        {
            var log = await _repository.GetByIdAsync(id);
            if (log == null || log.status != WaterLogStatus.PendingReview) return false;

            log.status = request.isApproved ? WaterLogStatus.Completed : WaterLogStatus.PendingInspection;
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