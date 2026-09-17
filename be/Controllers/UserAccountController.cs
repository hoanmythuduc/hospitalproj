using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using THUCTAP.Repos;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserAccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult>CreateUser([FromBody] UserCreateRequest request)
        {
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdUser = await _userService.CreateUserAsync(request);
                var token = _tokenService.GenerateToken(createdUser);


                return Ok(new
                {
                    Message = "Thêm người dùng thành công",
                    Data = createdUser,
                    Token = token
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateUser(int id, [FromBody] UserCreateRequest request)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, request);

            if (updatedUser == null)
            {
                return NotFound(new { Message = "Không tìm thấy người dùng này!" });
            }

            return Ok(new { Message = "Cập nhật tài khoản thành công!", Data = updatedUser });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteUser(int id)
        {
            var isDeleted = await _userService.DeleteUserAsync(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = "Không tìm thấy người dùng để xóa!" });
            }

            return Ok(new { Message = "Xóa tài khoản thành công!" });
        }


        [HttpGet]
        public async Task<IActionResult>GetAllUsers([FromQuery] UserFilterRequest filter)
        {
            var users = await _userService.GetAllUsersAsync(filter);

            return Ok(new
            {
                message = "Lấy danh sách người dùng thành công!",
                data = users
            });
        }
        [HttpGet("departments")]
        public async Task<IActionResult>GetAllDepartments()
        {
            try
            {
                var departments = await _userService.GetAllDepartmentsAsync();
                return Ok(new
                {
                    message = "Lấy danh sách phòng ban thành công!",
                    data = departments
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}