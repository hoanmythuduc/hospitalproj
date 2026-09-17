using MiniExcelLibs;
using System.ComponentModel.DataAnnotations;
using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.Models;
using THUCTAP.ViewModels;


namespace THUCTAP.Services
{
    public class FormFieldService : IFormFieldService
    {
        private readonly IFormFieldRepository _formFieldRepository;

        public FormFieldService(IFormFieldRepository formFieldRepository)
        {
            _formFieldRepository = formFieldRepository;
        }
        
        public async Task<FormField>CreateFormFieldAsync(FormFieldRequest request)
        {
            var newField = new FormField
            {
                label = request.label,
                field = request.field,
                entityName = request.entityName,
                type = request.type,
                colSpan = request.colSpan,
                option = request.option,
                subField = request.subField,
                tagField = request.tagField,
                isSearchAble = request.isSearchAble,
                isShowInForm = request.isShowInForm,
                isShowInList = request.isShowInList,
                tabName = request.tabName,
                endPoint = request.endPoint,
                sortOrder = request.sortOrder,
                menuId = request.menuId
            };


            await _formFieldRepository.CreateFormFieldAsync(newField);
            return newField;
        }

        public async Task<FormField>UpdateFormFieldAsync(int id, FormFieldRequest request)
        {
            var field = await _formFieldRepository.GetFormFieldByIdAsync(id);
            if (field == null) return null;

            field.UpdateFormField(request);

            await _formFieldRepository.UpdateFormFieldAsync(field);
            return field;
        }

        public async Task<bool>DeleteFormFieldAsync(int id)
        {
            var field = await _formFieldRepository.GetFormFieldByIdAsync(id);
            if (field == null) return false;

            await _formFieldRepository.DeleteFormFieldAsync(field);
            return true;
        }

        public async Task<PagedResult<FormFieldResponse>>GetAllFieldsAsync(FormFieldFilterRequest filter)
        {
            return await _formFieldRepository.GetAllFieldsAsync(filter);
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

            // Mapping vào đúng khuôn của FormFieldRequest
            var importedData = stream.Query<FormFieldRequest>().ToList();

            if (!importedData.Any())
                throw new Exception("File Excel không có dữ liệu!");

            var errorList = new List<string>();

            // Quét lỗi (Validation)
            for (int i = 0; i < importedData.Count; i++)
            {
                var item = importedData[i];
                var validationContext = new ValidationContext(item);
                var validationResults = new List<ValidationResult>();

                if (string.IsNullOrWhiteSpace(item.field) && string.IsNullOrWhiteSpace(item.entityName))
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

            foreach (var item in importedData)
            {
                await CreateFormFieldAsync(item);
                count++;
            }

            return count;
        }
    }
}