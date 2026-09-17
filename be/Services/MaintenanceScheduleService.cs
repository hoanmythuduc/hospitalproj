using System;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;

namespace THUCTAP.Services
{
    public class MaintenanceScheduleService : IMaintenanceScheduleService
    {
        private readonly IMaintenanceScheduleRepository _repository;

        public MaintenanceScheduleService(IMaintenanceScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<MaintenanceScheduleResponseDto> CreateScheduleAsync(MaintenanceScheduleRequest request)
        {
            // Sử dụng Mapper để chuyển từ DTO sang Entity
            var entity = request.ToEntity();

            // Mặc định khi tạo mới, status sẽ là PendingApproval (Đã thiết lập trong Mapper)
            await _repository.CreateAsync(entity);

            return entity.ToResponse();
        }

        public async Task<bool> ApproveScheduleAsync(int id, ApproveScheduleRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);

            // Kiểm tra xem phiếu có tồn tại và có đang ở trạng thái Chờ duyệt hay không
            if (entity == null || entity.status != MaintenanceScheduleStatus.PendingApproval)
            {
                return false;
            }

            // Cập nhật trạng thái dựa trên quyết định duyệt hay từ chối
            entity.status = request.isApproved ? MaintenanceScheduleStatus.Approved : MaintenanceScheduleStatus.Rejected;

            // Lưu ID của người thực hiện phê duyệt
            entity.approverId = request.approverId;

            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<PagedResult<MaintenanceScheduleResponseDto>> GetAllAsync(MaintenanceScheduleFilterRequest filter)
        {
            // Trực tiếp gọi hàm lấy danh sách phân trang từ Repository
            return await _repository.GetAllAsync(filter);
        }

        public async Task<MaintenanceScheduleResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return entity.ToResponse();
        }

        public async Task<MaintenanceScheduleResponseDto?> UpdateScheduleAsync(int id, MaintenanceScheduleRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            // Dùng Mapper để cập nhật các trường thông tin mới vào entity hiện tại
            entity.UpdateEntity(request);

            // Tùy thuộc vào nghiệp vụ, nếu sửa thì có thể tự động chuyển status về lại Draft hoặc PendingApproval
            // Ở đây mình đặt lại thành PendingApproval để phải duyệt lại từ đầu
            entity.status = MaintenanceScheduleStatus.PendingApproval;

            await _repository.UpdateAsync(entity);

            return entity.ToResponse();
        }

        public async Task<bool> DeleteScheduleAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }
    }
}