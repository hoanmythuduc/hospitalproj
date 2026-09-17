using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CustomFieldController : ControllerBase
    {
        private readonly IFormFieldService _formFieldService;

        public CustomFieldController(IFormFieldService formFieldService)
        {
            _formFieldService = formFieldService;
        }

        [HttpPost]
        public async Task<IActionResult>CreateCustomField([FromBody] FormFieldRequest request)
        {
           
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try { 
            var createdField = await _formFieldService.CreateFormFieldAsync(request);

            return Ok(new { Message = "Thêm Custom Field thành công", Data = createdField });
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateFormField(int id, [FromBody] FormFieldRequest request)
        {
            var updatedField = await _formFieldService.UpdateFormFieldAsync(id, request);

            if (updatedField == null)
            {
                return NotFound(new { Message = "Không tìm thấy FormField này!" });
            }

            return Ok(new { Message = "Cập nhật FormField thành công!", Data = updatedField });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteFormField(int id)
        {
            var isDeleted = await _formFieldService.DeleteFormFieldAsync(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = "Không tìm thấy FormField để xóa!" });
            }

            return Ok(new { Message = "Xóa FormField thành công!" });
        }
        [HttpGet]
        public async Task<IActionResult>GetAllFields([FromQuery] FormFieldFilterRequest filter)
        {
            var fields = await _formFieldService.GetAllFieldsAsync(filter);
            return Ok(new { message = "Thành công!", data = fields });
        }
        [HttpPost("import-excel")]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            try
            {
                int count = await _formFieldService.ImportExcelAsync(file);
                return Ok(new
                {
                    Message = $"Import thành công {count} cấu hình trường (Form Field) từ file Excel!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}