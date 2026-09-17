using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _service;

        public ProductCategoryController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll([FromQuery] ProductCategoryFilterRequest filter)
        {
            try
            {
                var result = await _service.GetAllAsync(filter);
                return Ok(new
                {
                    message = "Lấy danh sách danh mục sản phẩm thành công!",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Create([FromBody] ProductCategoryRequest request)
        {
            try
            {
                var result = await _service.CreateAsync(request);
                return Ok(new
                {
                    message = "Thêm danh mục sản phẩm thành công!",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id, [FromBody] ProductCategoryRequest request)
        {
            try
            {
                var result = await _service.UpdateAsync(id, request);
                if (result == null) return NotFound(new { message = "Không tìm thấy danh mục cần sửa!" });

                return Ok(new
                {
                    message = "Cập nhật danh mục thành công!",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                var isDeleted = await _service.DeleteAsync(id);
                if (!isDeleted) return NotFound(new { message = "Không tìm thấy danh mục cần xóa!" });

                return Ok(new
                {
                    message = "Xóa danh mục thành công!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("import-excel")]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            try
            {
                int count = await _service.ImportExcelAsync(file);
                return Ok(new
                {
                    message = $"Import thành công {count} danh mục sản phẩm từ file Excel!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}