using MiniExcelLibs;
using System.ComponentModel.DataAnnotations;
using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.ViewModels;
using Microsoft.Extensions.Logging; // 👉 Bổ sung thư viện Logging

namespace THUCTAP.Services
{
    public class CustomerMasterService : ICustomerMasterService
    {
        private readonly ICustomerMasterRepository _repository;
        private readonly ILogger<CustomerMasterService> _logger; // 👉 Khai báo Logger

        // 👉 Tiêm ILogger vào Constructor
        public CustomerMasterService(ICustomerMasterRepository repository, ILogger<CustomerMasterService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PagedResult<CustomerMasterResponseDto>> GetAllAsync(CustomerMasterFilterRequest filter)
        {
            try
            {
                return await _repository.GetAllAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách Khách hàng/Nhà cung cấp từ cơ sở dữ liệu");
                throw;
            }
        }

        public async Task<CustomerMasterResponseDto> CreateAsync(CustomerMasterRequest request)
        {
            try
            {
                var entity = request.ToCustomerMaster();

                await _repository.CreateAsync(entity);

                return entity.ToCustomerMasterResponse();
            }
            catch (Exception ex)
            {
                // 👉 Ghi log kèm tên để dễ dò lỗi
                _logger.LogError(ex, "Lỗi khi tạo mới Khách hàng/Nhà cung cấp. Tên: {SupplierName}", request.supplierName);
                throw;
            }
        }

        public async Task<CustomerMasterResponseDto?> UpdateAsync(int id, CustomerMasterRequest request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                entity.UpdateCustomerMaster(request);

                await _repository.UpdateAsync(entity);

                return entity.ToCustomerMasterResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật Khách hàng/Nhà cung cấp có ID: {Id}", id);
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
                _logger.LogError(ex, "Lỗi khi xóa Khách hàng/Nhà cung cấp có ID: {Id}", id);
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

                var importedData = stream.Query<CustomerMasterRequest>().ToList();

                if (!importedData.Any())
                    throw new Exception("File Excel không có dữ liệu!");

                var errorList = new List<string>();

                for (int i = 0; i < importedData.Count; i++)
                {
                    var item = importedData[i];
                    var validationContext = new ValidationContext(item);
                    var validationResults = new List<ValidationResult>();

                    if (string.IsNullOrWhiteSpace(item.supplierName))
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
                _logger.LogError(ex, "Lỗi nghiêm trọng khi Import file Excel dữ liệu Khách hàng/Nhà cung cấp. Tên file: {FileName}", file?.FileName ?? "Không xác định");
                throw;
            }
        }
    }
}