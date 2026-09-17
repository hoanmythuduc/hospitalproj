using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using System.Threading.Tasks;
using System;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceScheduleController : ControllerBase
    {
        private readonly IMaintenanceScheduleService _service;
        public MaintenanceScheduleController(IMaintenanceScheduleService service) { _service = service; }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaintenanceScheduleRequest request)
        {
            var result = await _service.CreateScheduleAsync(request);
            return Ok(new { message = "Lập kế hoạch thành công, đang chờ phê duyệt", data = result });
        }

        [HttpPut("{id}/approve")]
        public async Task<IActionResult> Approve(int id, [FromBody] ApproveScheduleRequest request)
        {
            var success = await _service.ApproveScheduleAsync(id, request);
            if (!success) return BadRequest(new { message = "Không tìm thấy kế hoạch hoặc sai trạng thái" });

            string msg = request.isApproved ? "Đã phê duyệt kế hoạch" : "Đã từ chối kế hoạch";
            return Ok(new { message = msg });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MaintenanceScheduleFilterRequest filter)
        {
            var result = await _service.GetAllAsync(filter);
            return Ok(new { message = "Thành công", data = result });
        }

        

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaintenanceScheduleRequest request)
        {
            try
            {
                var result = await _service.UpdateScheduleAsync(id, request);
                if (result == null) return NotFound(new { message = "Không tìm thấy kế hoạch" });
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
            var success = await _service.DeleteScheduleAsync(id);
            if (!success) return NotFound(new { message = "Không tìm thấy kế hoạch" });
            return Ok(new { message = "Xóa thành công" });
        }
    }
}