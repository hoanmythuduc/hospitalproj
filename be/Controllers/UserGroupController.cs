using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserGroupController : ControllerBase
    {
        
        private readonly IGroupService _groupService;

        public UserGroupController(IGroupService groupService)
        {
            
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult>CreateGroup([FromBody] CreateGroupRequest request)
        {
            try
            {
                var createdGroup = await _groupService.CreateGroupAsync(request);

                return Ok(new
                {
                    Message = "Tạo nhóm và phân quyền thành công!",
                    Data = createdGroup
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Lỗi khi tạo nhóm: " + ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateGroup(int id, [FromBody] CreateGroupRequest request)
        {
            var updatedGroup = await _groupService.UpdateGroupAsync(id, request);

            if (updatedGroup == null) return NotFound(new { Message = "Không tìm thấy nhóm này!" });

            return Ok(new { Message = "Cập nhật nhóm thành công!", Data = updatedGroup });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteGroup(int id)
        {
            var isDeleted = await _groupService.DeleteGroupAsync(id);

            if (!isDeleted) return NotFound(new { Message = "Không tìm thấy nhóm để xóa!" });

            return Ok(new { Message = "Xóa nhóm thành công!" });
        }

        [HttpGet]
        public async Task<IActionResult>GetAllGroups([FromQuery] GroupFilterRequest filter)
        {
            var groups = await _groupService.GetAllGroupsAsync(filter);

            return Ok(new
            {
                message = "Lấy danh sách nhóm thành công!",
                data = groups
            });
        }
       
        [HttpGet("permissions-matrix")]
        public async Task<IActionResult>GetGroupPermissionMatrix([FromQuery] int groupId = 0)
        {
            try
            {
                var matrix = await _groupService.GetGroupPermissionMatrixAsync(groupId);
                return Ok(new
                {
                    message = groupId == 0 ? "Lấy danh sách Menu để tạo quyền thành công!" : "Lấy ma trận phân quyền thành công!",
                    data = matrix
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}