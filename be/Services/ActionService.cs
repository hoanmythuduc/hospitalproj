using MiniExcelLibs;
using System.ComponentModel.DataAnnotations;
using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using Microsoft.Extensions.Logging; // 👉 Bổ sung thư viện Logging

namespace THUCTAP.Services
{
    public class ActionService : IActionService
    {
        private readonly IActionRepository _actionRepository;
        private readonly ILogger<ActionService> _logger; // 👉 Khai báo Logger

        // 👉 Tiêm ILogger vào Constructor
        public ActionService(IActionRepository actionRepository, ILogger<ActionService> logger)
        {
            _actionRepository = actionRepository;
            _logger = logger;
        }

        public async Task<AppAction> CreateActionAsync(ActionCreateRequest request)
        {
            try
            {
                var exists = await _actionRepository.ActionCodeExistsAsync(request.code, request.menuId);
                if (exists)
                {
                    throw new Exception($"Mã Action '{request.code}' đã tồn tại trong Menu này.");
                }

                var newAction = request.ToAppAction();
                await _actionRepository.CreateAsync(newAction);

                return newAction;
            }
            catch (Exception ex)
            {
                // 👉 Ghi log kèm theo mã Action và Menu ID để dễ dò lỗi
                _logger.LogError(ex, "Lỗi khi tạo Action mới. Mã: {ActionCode}, MenuId: {MenuId}", request.code, request.menuId);
                throw; // Tiếp tục ném lỗi ra ngoài để Controller trả về cho Frontend
            }
        }

        public async Task<AppAction> UpdateActionAsync(int id, UpdateActionRequest request)
        {
            try
            {
                var action = await _actionRepository.GetByIdAsync(id);
                if (action == null) return null;

                action.UpdateAppAction(request);

                await _actionRepository.UpdateAsync(action);

                return action;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật Action có ID: {ActionId}", id);
                throw;
            }
        }

        public async Task<bool> DeleteActionAsync(int id)
        {
            try
            {
                var action = await _actionRepository.GetByIdAsync(id);
                if (action == null) return false;

                await _actionRepository.DeleteAsync(action);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa Action có ID: {ActionId}", id);
                throw;
            }
        }

        public async Task<PagedResult<ActionResponse>> GetAllActionsAsync(ActionFilterRequest filter)
        {
            try
            {
                return await _actionRepository.GetAllActionsAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Action từ cơ sở dữ liệu");
                throw;
            }
        }

        public async Task<int> ImportExcelAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    throw new Exception("Vui lòng chọn file Excel!");

                if (Path.GetExtension(file.FileName).ToLower() != ".xlsx")
                    throw new Exception("Chỉ hỗ trợ file định dạng Excel (.xlsx)!");

                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                stream.Position = 0;

                // Mapping vào đúng khuôn của ActionCreateRequest
                var importedData = stream.Query<ActionCreateRequest>().ToList();

                if (!importedData.Any())
                    throw new Exception("File Excel không có dữ liệu!");

                var errorList = new List<string>();

                // Quét lỗi (Validation)
                for (int i = 0; i < importedData.Count; i++)
                {
                    var item = importedData[i];
                    var validationContext = new ValidationContext(item);
                    var validationResults = new List<ValidationResult>();

                    // Bỏ qua dòng trống hoàn toàn dựa vào trường label và code
                    if (string.IsNullOrWhiteSpace(item.label) && string.IsNullOrWhiteSpace(item.code))
                    {
                        continue;
                    }

                    bool isValid = Validator.TryValidateObject(item, validationContext, validationResults, true);

                    if (!isValid)
                    {
                        var errors = string.Join(" | ", validationResults.Select(r => r.ErrorMessage));
                        errorList.Add($"Dòng {i + 2}: {errors}");
                    }
                }

                if (errorList.Any())
                {
                    throw new Exception("Lỗi dữ liệu Excel:\n" + string.Join("\n", errorList));
                }

                int count = 0;
                // Lưu vào DB nếu file không có lỗi định dạng
                foreach (var item in importedData)
                {
                    // Gọi lại hàm CreateActionAsync để tận dụng logic check trùng mã code
                    await CreateActionAsync(item);
                    count++;
                }

                return count;
            }
            catch (Exception ex)
            {
                // 👉 Ghi log tên file Excel gây ra lỗi
                _logger.LogError(ex, "Lỗi nghiêm trọng khi Import file Excel dữ liệu Action. Tên file: {FileName}", file?.FileName ?? "Không xác định");
                throw;
            }
        }
    }
}