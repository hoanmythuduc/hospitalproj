using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace THUCTAP.Services
{
    public class MaintenanceLogService : IMaintenanceLogService
    {
        private readonly IMaintenanceLogRepository _repository;
        public MaintenanceLogService(IMaintenanceLogRepository repository) { _repository = repository; }

        public async Task<MaintenanceLogResponseDto> CreateLogAsync(MaintenanceLogRequest request)
        {
            var entity = request.ToEntity();
            await _repository.CreateAsync(entity);

            // Lấy lại entity để nạp đầy đủ Tên User và Tên Thiết bị
            var createdEntity = await _repository.GetByIdAsync(entity.id);
            return createdEntity!.ToResponse();
        }

        public async Task<bool> InspectLogAsync(int id, InspectLogRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null || entity.status != MaintenanceLogStatus.PendingInspection) return false;

            entity.inspectorId = request.inspectorId;
            entity.inspectionDate = DateTime.Now;
            entity.status = MaintenanceLogStatus.PendingReview;

            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> ReviewLogAsync(int id, ReviewLogRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null || entity.status != MaintenanceLogStatus.PendingReview) return false;

            entity.reviewerId = request.reviewerId;
            entity.reviewDate = DateTime.Now;
            entity.status = MaintenanceLogStatus.Completed;

            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<MonthlyMaintenanceReportDto> GetMonthlyReportAsync(int equipmentId, int month, int year)
        {
            var logs = await _repository.GetLogsByMonthAsync(equipmentId, month, year);

            var firstLog = logs.FirstOrDefault();

            // Xử lý danh sách chữ ký
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

                // --- BỔ SUNG: Móc dữ liệu 5 Task từ DANH MỤC THIẾT BỊ ---
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
        public async Task<PagedResult<MaintenanceLogResponseDto>> GetAllAsync(MaintenanceLogFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<MaintenanceLogResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity?.ToResponse();
        }

        public async Task<MaintenanceLogResponseDto?> UpdateLogAsync(int id, MaintenanceLogRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            //Chặn không cho sửa nếu đã được duyệt
             if (entity.status != MaintenanceLogStatus.PendingInspection) 
                 throw new Exception("Chỉ được sửa nhật ký khi chưa có ai kiểm tra!");

            entity.UpdateEntity(request);
            await _repository.UpdateAsync(entity);

            var updatedEntity = await _repository.GetByIdAsync(id);
            return updatedEntity!.ToResponse();
        }

        public async Task<bool> DeleteLogAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }
    }
}