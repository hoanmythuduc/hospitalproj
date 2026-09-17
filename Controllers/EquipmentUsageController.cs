using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentUsageController : ControllerBase
    {
        private readonly IEquipmentUsageService _service;
        public EquipmentUsageController(IEquipmentUsageService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EquipmentUsageFilterRequest filter)
        {
            try
            {
                var result = await _service.GetAllAsync(filter);
                return Ok(new { message = "Lấy danh sách thành công!", data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

       

        

        [HttpPost("save-daily")]
        public async Task<IActionResult> SaveDaily([FromBody] SaveUsageDailyLogRequest request)
        {
            try
            {
                var msg = await _service.SaveDailyLogAsync(request);
                return Ok(new { message = msg, data = (object)null });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/inspect")]
        public async Task<IActionResult> Inspect(int id, [FromBody] ProcessUsageLogRequest request)
        {
            try
            {
                var success = await _service.InspectLogAsync(id, request);
                if (!success) return BadRequest(new { message = "Không tìm thấy phiếu hoặc sai trạng thái duyệt" });
                return Ok(new { message = request.isApproved ? "Đã kiểm tra thành công" : "Đã từ chối kiểm tra" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/review")]
        public async Task<IActionResult> Review(int id, [FromBody] ProcessUsageLogRequest request)
        {
            try
            {
                var success = await _service.ReviewLogAsync(id, request);
                if (!success) return BadRequest(new { message = "Không tìm thấy phiếu hoặc sai trạng thái" });
                return Ok(new { message = request.isApproved ? "Đã xem xét và hoàn tất phiếu" : "Đã từ chối xem xét" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _service.DeleteLogAsync(id);
                if (!success) return NotFound(new { message = "Không tìm thấy phiếu theo dõi thiết bị" });
                return Ok(new { message = "Xóa phiếu thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}