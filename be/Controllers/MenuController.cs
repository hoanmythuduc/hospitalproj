using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDynamicMenu([FromBody] MenuCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _menuService.CreateDynamicMenuAsync(request);

                return Ok(new
                {
                    Message = "Tạo Menu và các thành phần thành công!",
                    Data = result
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Đã xảy ra lỗi khi tạo Menu",
                    Error = ex.Message
                });
            }
        }
        // Thêm vào bên dưới hàm CreateDynamicMenu trong MenusController
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody] MenuUpdateRequest request)
        {
            try
            {
                var result = await _menuService.UpdateMenuAsync(id, request);
                return Ok(new
                {
                    Message = "Cập nhật Menu thành công!",
                    Data = result
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Đã xảy ra lỗi khi cập nhật Menu",
                    Error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            try
            {
                var isDeleted = await _menuService.DeleteMenuAsync(id);
                if (!isDeleted)
                {
                    return NotFound(new { Message = "Không tìm thấy Menu để xóa!" });
                }

                return Ok(new { Message = "Xóa Menu thành công!" });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Đã xảy ra lỗi khi xóa Menu",
                    Error = ex.Message
                });
            }
        }
    }
}