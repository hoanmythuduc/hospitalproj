using Microsoft.AspNetCore.Mvc;
using MiniSoftware;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IMaintenanceLogService _maintenanceLogService;
        private readonly IReportService _reportService;

        public ReportController(IEquipmentService equipmentService, IMaintenanceLogService maintenanceLogService, IReportService reportService)
        {
            _equipmentService = equipmentService;
            _maintenanceLogService = maintenanceLogService;
            _reportService = reportService;
        }

        [HttpPost("equipment/{id}/export-word")]
        public async Task<IActionResult> ExportEquipmentProfile(int id, [FromBody] ExportReportRequest request)
        {
            var equipmentData = await _equipmentService.GetByIdAsync(id);
            if (equipmentData == null)
            {
                return NotFound(new { message = "Không tìm thấy thông tin thiết bị!" });
            }

            try
            {
                string tplName = string.IsNullOrWhiteSpace(request.templateName) ? "lylichthietbi.docx" : request.templateName;

                byte[] templateBytes = await _reportService.GetTemplateBytesAsync(request.base64Template, tplName);

                using (var outputStream = new MemoryStream())
                {
                    MiniWord.SaveAsByTemplate(outputStream, templateBytes, equipmentData);
                    string resultBase64 = Convert.ToBase64String(outputStream.ToArray());
                    string fileName = $"LyLich_{equipmentData.equipmentCode}_{DateTime.Now:yyyyMMddHHmmss}.docx";

                    return Ok(new
                    {
                        message = "Xuất file thành công",
                        fileName = fileName,
                        fileBase64 = resultBase64
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi trong quá trình tạo file Word: " + ex.Message });
            }
        }

        [HttpPost("maintenance-log/export-word")]
        public async Task<IActionResult> ExportMonthlyMaintenanceLog([FromQuery] int equipmentId, [FromQuery] int month, [FromQuery] int year, [FromBody] ExportReportRequest request)
        {
            var report = await _maintenanceLogService.GetMonthlyReportAsync(equipmentId, month, year);
            if (report == null)
            {
                return NotFound(new { message = "Không tìm thấy dữ liệu báo cáo!" });
            }

            try
            {
                var wordData = new Dictionary<string, object>
                {
                    { "equipmentName", report.equipmentName },
                    { "equipmentCode", report.equipmentCode },
                    { "month", month.ToString("D2") },
                    { "year", year.ToString() },
                    { "dailyTask", "Kiểm tra hoạt động" },
                    { "weeklyTask", "Vệ sinh bên ngoài" },
                    { "monthlyTask", "Vệ sinh bộ lọc" },
                    { "quarterlyTask", "Bảo dưỡng tổng thể" },
                    { "asNeededTask", "Sửa chữa/thay thế" },
                    { "allInspectors", report.allInspectors },
                    { "allReviewers", report.allReviewers },
                    { "inspectionDate", DateTime.Now.ToString("dd/MM/yyyy") },
                    { "reviewDate", DateTime.Now.ToString("dd/MM/yyyy") }
                };

                for (int i = 1; i <= 31; i++)
                {
                    wordData.Add($"d{i}_daily", ""); wordData.Add($"d{i}_weekly", ""); wordData.Add($"d{i}_monthly", "");
                    wordData.Add($"d{i}_quarterly", ""); wordData.Add($"d{i}_asNeeded", ""); wordData.Add($"d{i}_note", ""); wordData.Add($"d{i}_exe", "");
                }

                foreach (var log in report.dailyLogs)
                {
                    int day = log.logDate.Day;
                    wordData[$"d{day}_daily"] = log.isDaily;
                    wordData[$"d{day}_weekly"] = log.isWeekly;
                    wordData[$"d{day}_monthly"] = log.isMonthly;
                    wordData[$"d{day}_quarterly"] = log.isQuarterly;
                    wordData[$"d{day}_asNeeded"] = log.isAsNeeded;
                    wordData[$"d{day}_note"] = log.note;
                    wordData[$"d{day}_exe"] = log.executorName;
                }

                string tplName = string.IsNullOrWhiteSpace(request.templateName) ? "NhatKiBaoDuong.docx" : request.templateName;
                byte[] templateBytes = await _reportService.GetTemplateBytesAsync(request.base64Template, tplName);

                using (var outputStream = new MemoryStream())
                {
                    MiniWord.SaveAsByTemplate(outputStream, templateBytes, wordData);
                    string resultBase64 = Convert.ToBase64String(outputStream.ToArray());
                    string fileName = $"NhatKyBaoDuong_{report.equipmentCode}_Thang{month:D2}_{year}.docx";

                    return Ok(new
                    {
                        message = "Xuất file thành công",
                        fileName = fileName,
                        fileBase64 = resultBase64
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi trong quá trình tạo file Word: " + ex.Message });
            }
        }
        [HttpPost("maintenance-schedule/export-word")]
        public async Task<IActionResult> ExportYearlyPlan([FromQuery] int year, [FromBody] ExportReportRequest request)
        {
            try
            {
                var data = await _reportService.GetYearlyPlanDataAsync(year);

                string tplName = string.IsNullOrWhiteSpace(request.templateName)
                    ? "kehoachbaoduong.docx"
                    : request.templateName;

                byte[] templateBytes = await _reportService.GetTemplateBytesAsync(request.base64Template, tplName);

                using (var outputStream = new MemoryStream())
                {
                    MiniWord.SaveAsByTemplate(outputStream, templateBytes, data);
                    string resultBase64 = Convert.ToBase64String(outputStream.ToArray());
                    string fileName = $"KeHoachBaoTri_{year}.docx";

                    return Ok(new
                    {
                        message = "Xuất file Kế hoạch năm thành công",
                        fileName = fileName,
                        fileBase64 = resultBase64
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi trong quá trình tạo file Word: " + ex.Message });
            }
        }
        [HttpPost("water-system-log/export-word/{logId}")]
        public async Task<IActionResult> ExportWaterSystemLog(int logId, [FromBody] ExportReportRequest request)
        {
            try
            {
                var data = await _reportService.GetWaterSystemLogDataAsync(logId);

                string tplName = string.IsNullOrWhiteSpace(request.templateName)
                    ? "theodoilocnuoc.docx"
                    : request.templateName;

                byte[] templateBytes = await _reportService.GetTemplateBytesAsync(request.base64Template, tplName);

                using (var outputStream = new MemoryStream())
                {
                    MiniWord.SaveAsByTemplate(outputStream, templateBytes, data);
                    string resultBase64 = Convert.ToBase64String(outputStream.ToArray());
                    string fileName = $"TheoDoiLocNuoc_Thang{data.month}_{data.year}.docx";

                    return Ok(new
                    {
                        message = "Xuất file Theo dõi hệ thống lọc nước thành công",
                        fileName = fileName,
                        fileBase64 = resultBase64
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi trong quá trình tạo file Word: " + ex.Message });
            }
        }
        [HttpPost("equipment-usage-log/export-word/{logId}")]
        public async Task<IActionResult> ExportEquipmentUsageLog(int logId, [FromBody] ExportReportRequest request)
        {
            try
            {
                var data = await _reportService.GetEquipmentUsageLogDataAsync(logId);

                string tplName = string.IsNullOrWhiteSpace(request.templateName)
                    ? "theodoithietbi.docx"
                    : request.templateName;

                byte[] templateBytes = await _reportService.GetTemplateBytesAsync(request.base64Template, tplName);

                using (var outputStream = new MemoryStream())
                {
                    MiniWord.SaveAsByTemplate(outputStream, templateBytes, data);
                    string resultBase64 = Convert.ToBase64String(outputStream.ToArray());

                    string fileName = $"TheoDoiThietBi_{data["equipmentCode"]}_Thang{data["month"]}_{data["year"]}_Tuan{data["weekOfMonth"]}.docx";

                    return Ok(new
                    {
                        message = "Xuất file Nhật ký sử dụng thiết bị thành công",
                        fileName = fileName,
                        fileBase64 = resultBase64
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi trong quá trình tạo file Word: " + ex.Message });
            }
        }
    }
}