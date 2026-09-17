//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Net.Http.Json;
//using System.Text.Json;

//namespace THUCTAP.Services
//{
    
//    public class ThirdPartyApiService : IThirdPartyApiService
//    {
//        private readonly HttpClient _httpClient;
        
//        private readonly string _baseUrl = "https://jsonplaceholder.typicode.com"; 
//        private readonly string _apiKey = "YOUR_API_KEY";

//        public ThirdPartyApiService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//            // Cấu hình URL gốc
//            _httpClient.BaseAddress = new Uri(_baseUrl);
            
          
//             _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
//             _httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
//        }

//        // Hàm dùng để gọi GET Lấy dữ liệu tỷ giá, thông tin thời tiết
//        public async Task<object?> GetDataAsync(string endpoint)
//        {
//            try
//            {
//                var response = await _httpClient.GetAsync(endpoint);
                
//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonString = await response.Content.ReadAsStringAsync();
//                    return JsonSerializer.Deserialize<object>(jsonString);
//                }
//                return null; 
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }

//        // Hàm dùng để gọi POST  Đẩy dữ liệu đơn hàng sang VNPay
//        public async Task<object?> PostDataAsync(string endpoint, object payload)
//        {
//            try
//            {
//                var response = await _httpClient.PostAsJsonAsync(endpoint, payload);
                
//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonString = await response.Content.ReadAsStringAsync();
//                    return JsonSerializer.Deserialize<object>(jsonString);
//                }
//                return null;
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }
//    }
//}