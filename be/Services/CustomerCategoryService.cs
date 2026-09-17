using MiniExcelLibs;
using System.ComponentModel.DataAnnotations;
using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class CustomerCategoryService : ICustomerCategoryService
    {
        private readonly ICustomerCategoryRepository _repository;

        public CustomerCategoryService(ICustomerCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<CustomerCategoryResponseDto>>GetAllAsync(CustomerCategoryFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<CustomerCategoryResponseDto>CreateAsync(CustomerCategoryRequest request)
        {
            var entity = request.ToCustomerCategory();

            await _repository.CreateAsync(entity);

            return entity.ToCustomerCategoryResponse();
        }

        public async Task<CustomerCategoryResponseDto?>UpdateAsync(int id, CustomerCategoryRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.UpdateCustomerCategory(request);

            await _repository.UpdateAsync(entity);

            return entity.ToCustomerCategoryResponse();
        }

        public async Task<bool>DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);

            return true;
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

            var importedData = stream.Query<CustomerCategoryRequest>().ToList();

            if (!importedData.Any())
                throw new Exception("File Excel không có dữ liệu!");

            var errorList = new List<string>();

            for (int i = 0; i < importedData.Count; i++)
            {
                var item = importedData[i];
                var validationContext = new ValidationContext(item);
                var validationResults = new List<ValidationResult>();

                if (string.IsNullOrWhiteSpace(item.groupName))
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
                await CreateAsync(item);
                count++;
            }

            return count;
        }
    }
}