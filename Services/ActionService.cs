using MiniExcelLibs;
using System.ComponentModel.DataAnnotations;
using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class ActionService : IActionService
    {
        private readonly IActionRepository _actionRepository;

        public ActionService(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        public async Task<AppAction>CreateActionAsync(ActionCreateRequest request)
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

        public async Task<AppAction>UpdateActionAsync(int id, UpdateActionRequest request)
        {
            var action = await _actionRepository.GetByIdAsync(id);
            if (action == null) return null;

            action.UpdateAppAction(request);

            await _actionRepository.UpdateAsync(action);

            return action;
        }

        public async Task<bool>DeleteActionAsync(int id)
        {
            var action = await _actionRepository.GetByIdAsync(id);
            if (action == null) return false;

            await _actionRepository.DeleteAsync(action);

            return true;
        }

        public async Task<PagedResult<ActionResponse>>GetAllActionsAsync(ActionFilterRequest filter)
        {
            return await _actionRepository.GetAllActionsAsync(filter);
        }
        public async Task<int> ImportExcelAsync(IFormFile file)
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
                // Gọi lại hàm CreateActionAsync để tận dụng logic check trùng mã code của bạn
                await CreateActionAsync(item);
                count++;
            }

            return count;
        }
    }
}