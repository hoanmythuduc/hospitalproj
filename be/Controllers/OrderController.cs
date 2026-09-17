using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OrderFilterRequest filter)
        {
            var result = await _service.GetAllAsync(filter);
            return Ok(new { message = "Thành công", data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderRequest request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(new { message = "Tạo đơn hàng thành công", data = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            if (result == null) return NotFound(new { message = "Không tìm thấy đơn hàng này" });
            return Ok(new { message = "Cập nhật thành công", data = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _service.DeleteAsync(id);
            if (!isDeleted) return NotFound(new { message = "Không tìm thấy đơn hàng này" });
            return Ok(new { message = "Xóa đơn hàng thành công" });
        }
    }
}