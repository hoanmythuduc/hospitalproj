using THUCTAP.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace THUCTAP.Interfaces
{
    public interface IReportService
    {
        Task<List<Dictionary<string, object>>> GetDynamicReportAsync(DynamicReportRequest request);

        Task<string> GenerateReportBase64Async(DynamicReportRequest request);

        Task<byte[]> GetTemplateBytesAsync(string? base64Template, string templateName);
        Task<MaintenanceScheduleExportWord> GetYearlyPlanDataAsync(int year);
        Task<WaterSystemLogExportWord> GetWaterSystemLogDataAsync(int logId);
        Task<Dictionary<string, object>> GetEquipmentUsageLogDataAsync(int logId);
    }
}