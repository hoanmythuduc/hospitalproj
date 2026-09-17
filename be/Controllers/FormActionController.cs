using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FormActionController : ControllerBase
    {
        private readonly IActionService _actionService;
        public FormActionController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpPost]
        public async Task<IActionResult>CreateAction([FromBody] ActionCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdAction = await _actionService.CreateActionAsync(request);

                return Ok(new
                {
                    Message = "Thêm Form Action thành công",
                    Data = createdAction
                });
            }
            catch (Exception ex)
            {
                
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateAction(int id, [FromBody] UpdateActionRequest request)
        {
            var updatedAction = await _actionService.UpdateActionAsync(id, request);

            if (updatedAction == null)
            {
                return NotFound(new { Message = "Không tìm thấy Action này!" });
            }

            return Ok(new { Message = "Cập nhật Action thành công!", Data = updatedAction });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAction(int id)
        {
            var isDeleted = await _actionService.DeleteActionAsync(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = "Không tìm thấy Action để xóa!" });
            }

            return Ok(new { Message = "Xóa Action thành công!" });
        }

        [HttpGet]
        public async Task<IActionResult>GetAllActions([FromQuery] ActionFilterRequest filter)
        {
            var actions = await _actionService.GetAllActionsAsync(filter);
            return Ok(new { message = "Thành công!", data = actions });
        }
        [HttpPost("import-excel")]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            try
            {
                int count = await _actionService.ImportExcelAsync(file);
                return Ok(new
                {
                    Message = $"Import thành công {count} Form Action từ file Excel!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}