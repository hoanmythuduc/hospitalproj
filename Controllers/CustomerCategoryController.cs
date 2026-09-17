using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    
    public class CustomerCategoryController : ControllerBase
    {
        private readonly ICustomerCategoryService _service;

        public CustomerCategoryController(ICustomerCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll([FromQuery] CustomerCategoryFilterRequest filter)
        {
            var result = await _service.GetAllAsync(filter);
            return Ok(new { message = "Thành công", data = result });
        }

        [HttpPost]
        public async Task<IActionResult>Create([FromBody] CustomerCategoryRequest request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(new { message = "Thêm thành công", data = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id, [FromBody] CustomerCategoryRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            if (result == null) return NotFound(new { message = "Không tìm thấy" });
            return Ok(new { message = "Sửa thành công", data = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var isDeleted = await _service.DeleteAsync(id);
            if (!isDeleted) return NotFound(new { message = "Không tìm thấy" });
            return Ok(new { message = "Xóa thành công" });
        }
        [HttpPost("import-excel")]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            try
            {
                int count = await _service.ImportExcelAsync(file);
                return Ok(new
                {
                    message = $"Import thành công {count} nhóm khách hàng từ file Excel!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}