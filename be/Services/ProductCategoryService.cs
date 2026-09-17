using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;
using System.ComponentModel.DataAnnotations;
using MiniExcelLibs;

namespace THUCTAP.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ProductCategoryResponseDto>> GetAllAsync(ProductCategoryFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<ProductCategoryResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return entity.ToProductCategoryResponse();
        }

        public async Task<ProductCategoryResponseDto> CreateAsync(ProductCategoryRequest request)
        {
            var entity = request.ToProductCategory();

            await _repository.CreateAsync(entity);

            return entity.ToProductCategoryResponse();
        }

        public async Task<ProductCategoryResponseDto?> UpdateAsync(int id, ProductCategoryRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.UpdateProductCategory(request);

            await _repository.UpdateAsync(entity);

            return entity.ToProductCategoryResponse();
        }

        public async Task<bool> DeleteAsync(int id)
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

            var importedData = stream.Query<ProductCategoryRequest>().ToList();

            if (!importedData.Any())
                throw new Exception("File Excel không có dữ liệu!");

            var errorList = new List<string>();

            for (int i = 0; i < importedData.Count; i++)
            {
                var item = importedData[i];
                var validationContext = new ValidationContext(item);
                var validationResults = new List<ValidationResult>();

                if (string.IsNullOrWhiteSpace(item.equipmentCode) && string.IsNullOrWhiteSpace(item.equipmentName))
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