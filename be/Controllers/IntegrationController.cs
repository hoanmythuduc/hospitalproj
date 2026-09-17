//using Microsoft.AspNetCore.Mvc;
//using THUCTAP.Services;

//namespace THUCTAP.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class IntegrationController : ControllerBase
//    {
//        private readonly IThirdPartyApiService _thirdPartyService;

//        public IntegrationController(IThirdPartyApiService thirdPartyService)
//        {
//            _thirdPartyService = thirdPartyService;
//        }

//        [HttpGet("fetch-external-data")]
//        public async Task<IActionResult> FetchExternalData()
//        {
//            var result = await _thirdPartyService.GetDataAsync("/posts/1");

//            if (result == null)
//            {
//                return BadRequest(new { message = "Lỗi khi kết nối với hệ thống bên ngoài!" });
//            }

//            return Ok(new { message = "Thành công", data = result });
//        }
//    }
//}