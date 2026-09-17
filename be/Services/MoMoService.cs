//using System.Security.Cryptography;
//using System.Text;
//using System.Text.Json;

//namespace THUCTAP.Services
//{
    
//    public class MoMoService : IMoMoService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly IConfiguration _configuration;

//        public MoMoService(HttpClient httpClient, IConfiguration configuration)
//        {
//            _httpClient = httpClient;
//            _configuration = configuration;
//        }

//        public async Task<string?> CreatePaymentUrlAsync(string orderId, decimal amount, string orderInfo)
//        {
//            var endpoint = _configuration["MoMoAPI:Endpoint"];
//            var partnerCode = _configuration["MoMoAPI:PartnerCode"];
//            var accessKey = _configuration["MoMoAPI:AccessKey"];
//            var secretKey = _configuration["MoMoAPI:SecretKey"];
//            var returnUrl = _configuration["MoMoAPI:ReturnUrl"];
//            var notifyUrl = _configuration["MoMoAPI:NotifyUrl"];

//            var amountString = amount.ToString("0"); // Đảm bảo số tiền là số nguyên (VD: 500000)
//            var requestId = Guid.NewGuid().ToString();
//            var extraData = "";
//            var requestType = "captureWallet"; // Phương thức thanh toán bằng ví MoMo

//            // 1. Tạo chuỗi dữ liệu thô (Raw Hash) theo ĐÚNG THỨ TỰ chữ cái ABC mà MoMo yêu cầu
//            var rawHash = $"accessKey={accessKey}&amount={amountString}&extraData={extraData}&ipnUrl={notifyUrl}&orderId={orderId}&orderInfo={orderInfo}&partnerCode={partnerCode}&redirectUrl={returnUrl}&requestId={requestId}&requestType={requestType}";

//            // 2. Ký bảo mật (Signature) bằng thuật toán HMAC SHA256
//            var signature = ComputeHmacSha256(rawHash, secretKey);

//            // 3. Đóng gói dữ liệu dạng JSON
//            var requestData = new
//            {
//                partnerCode = partnerCode,
//                partnerName = "Test Hospital",
//                storeId = "MomoTestStore",
//                requestId = requestId,
//                amount = amountString,
//                orderId = orderId,
//                orderInfo = orderInfo,
//                redirectUrl = returnUrl,
//                ipnUrl = notifyUrl,
//                lang = "vi",
//                extraData = extraData,
//                requestType = requestType,
//                signature = signature
//            };

//            // 4. Gửi Request sang MoMo
//            var response = await _httpClient.PostAsJsonAsync(endpoint, requestData);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseContent = await response.Content.ReadAsStringAsync();
//                using JsonDocument doc = JsonDocument.Parse(responseContent);
//                var root = doc.RootElement;

//                // Nếu MoMo trả về link thành công
//                if (root.TryGetProperty("payUrl", out var payUrlElement))
//                {
//                    return payUrlElement.GetString();
//                }
//            }

//            return null;
//        }

//        // Hàm hỗ trợ mã hóa HMAC SHA256
//        private string ComputeHmacSha256(string message, string secretKey)
//        {
//            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
//            var messageBytes = Encoding.UTF8.GetBytes(message);

//            using (var hmac = new HMACSHA256(keyBytes))
//            {
//                var hashBytes = hmac.ComputeHash(messageBytes);
//                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
//            }
//        }
//    }
//}