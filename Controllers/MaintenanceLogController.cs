using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using System.Threading.Tasks;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceLogController : ControllerBase
    {
        private readonly IMaintenanceLogService _service;
        public MaintenanceLogController(IMaintenanceLogService service) { _service = service; }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaintenanceLogRequest request)
        {
            var result = await _service.CreateLogAsync(request);
            return Ok(new { message = "Lưu nhật ký thành công, chờ kiểm tra", data = result });
        }

        [HttpPut("{id}/inspect")]
        public async Task<IActionResult> Inspect(int id, [FromBody] InspectLogRequest request)
        {
            var success = await _service.InspectLogAsync(id, request);
            if (!success) return BadRequest(new { message = "Không tìm thấy nhật ký hoặc sai trạng thái" });
            return Ok(new { message = "Đã kiểm tra, chuyển sang chờ xem xét" });
        }

        [HttpPut("{id}/review")]
        public async Task<IActionResult> Review(int id, [FromBody] ReviewLogRequest request)
        {
            var success = await _service.ReviewLogAsync(id, request);
            if (!success) return BadRequest(new { message = "Không tìm thấy nhật ký hoặc sai trạng thái" });
            return Ok(new { message = "Đã xem xét, nhật ký hoàn thành" });
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MaintenanceLogFilterRequest filter)
        {
            var result = await _service.GetAllAsync(filter);
            return Ok(new { message = "Thành công", data = result });
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaintenanceLogRequest request)
        {
            try
            {
                var result = await _service.UpdateLogAsync(id, request);
                if (result == null) return NotFound(new { message = "Không tìm thấy nhật ký" });
                return Ok(new { message = "Cập nhật thành công", data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteLogAsync(id);
            if (!success) return NotFound(new { message = "Không tìm thấy nhật ký" });
            return Ok(new { message = "Xóa thành công" });
        }
    }
}