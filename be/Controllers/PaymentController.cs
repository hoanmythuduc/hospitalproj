//using Microsoft.AspNetCore.Mvc;
//using THUCTAP.Services;

//namespace THUCTAP.Controllers
//{
    
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PaymentController : ControllerBase
//    {
//        // Tiêm (Inject) tất cả các Service thanh toán vào đây
//        private readonly IMoMoService _momoService;
//        // private readonly IVietQRService _vietqrService; // Lát nữa tạo xong thì mở comment ra

//        public PaymentController(IMoMoService momoService /*, IVietQRService vietqrService*/)
//        {
//            _momoService = momoService;
//            // _vietqrService = vietqrService;
//        }

//        [HttpPost("checkout")]
//        public async Task<IActionResult> Checkout([FromBody] CheckoutRequest request)
//        {
//            // Kiểm tra Frontend chọn cổng thanh toán nào
//            if (request.PaymentMethod.ToUpper() == "MOMO")
//            {
//                // Gọi MoMo Service
//                var payUrl = await _momoService.CreatePaymentUrlAsync(request.OrderId, request.Amount, request.OrderInfo);

//                if (string.IsNullOrEmpty(payUrl)) return BadRequest(new { message = "Lỗi tạo giao dịch MoMo!" });

//                return Ok(new { method = "MOMO", type = "REDIRECT", url = payUrl });
//            }
//            else if (request.PaymentMethod.ToUpper() == "VIETQR")
//            {
//                // Gọi VietQR Service (Tương lai)
//                // var qrImageUrl = await _vietqrService.GenerateQrCodeAsync(request.Amount, request.OrderInfo);
//                // return Ok(new { method = "VIETQR", type = "IMAGE", url = qrImageUrl });

//                return Ok(new { message = "Chức năng VietQR đang được xây dựng!" });
//            }
//            else
//            {
//                return BadRequest(new { message = "Phương thức thanh toán không hợp lệ!" });
//            }
//        }
//    }
//}