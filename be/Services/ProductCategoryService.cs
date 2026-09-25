using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;
using System.ComponentModel.DataAnnotations;
using MiniExcelLibs;
using Microsoft.Extensions.Logging; // 👉 Bổ sung thư viện Logging
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace THUCTAP.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;
        private readonly ILogger<ProductCategoryService> _logger; // 👉 Khai báo Logger

        // 👉 Tiêm ILogger vào Constructor
        public ProductCategoryService(IProductCategoryRepository repository, ILogger<ProductCategoryService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PagedResult<ProductCategoryResponseDto>> GetAllAsync(ProductCategoryFilterRequest filter)
        {
            try
            {
                return await _repository.GetAllAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Danh mục sản phẩm (Product Category)");
                throw;
            }
        }

        public async Task<ProductCategoryResponseDto?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                return entity.ToProductCategoryResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy chi tiết Danh mục sản phẩm có ID: {Id}", id);
                throw;
            }
        }

        public async Task<ProductCategoryResponseDto> CreateAsync(ProductCategoryRequest request)
        {
            try
            {
                var entity = request.ToProductCategory();

                await _repository.CreateAsync(entity);

                return entity.ToProductCategoryResponse();
            }
            catch (Exception ex)
            {
                // 👉 Ghi log kèm theo mã thiết bị để dễ truy vết
                _logger.LogError(ex, "Lỗi khi tạo mới Danh mục sản phẩm. Mã thiết bị: {EquipmentCode}", request.equipmentCode);
                throw;
            }
        }

        public async Task<ProductCategoryResponseDto?> UpdateAsync(int id, ProductCategoryRequest request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                entity.UpdateProductCategory(request);

                await _repository.UpdateAsync(entity);

                return entity.ToProductCategoryResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật Danh mục sản phẩm có ID: {Id}", id);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return false;

                await _repository.DeleteAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa Danh mục sản phẩm có ID: {Id}", id);
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
            catch (Exception ex)
            {
                // 👉 Ghi log tên file Excel bị lỗi
                _logger.LogError(ex, "Lỗi nghiêm trọng khi Import file Excel dữ liệu Danh mục sản phẩm. Tên file: {FileName}", file?.FileName ?? "Không xác định");
                throw;
            }
        }
    }
}