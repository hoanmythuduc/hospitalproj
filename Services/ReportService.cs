using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniSoftware;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using THUCTAP.Models;

namespace THUCTAP.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReportService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<Dictionary<string, object>>> GetDynamicReportAsync(DynamicReportRequest request)
        {
            var resultList = new List<Dictionary<string, object>>();
            string columns = string.IsNullOrWhiteSpace(request.selectColumns) ? "*" : request.selectColumns;
            string sql = $"SELECT {columns} FROM {request.tableName}";

            if (!string.IsNullOrWhiteSpace(request.whereCondition))
            {
                sql += $" WHERE {request.whereCondition}";
            }

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row.Add(reader.GetName(i), reader.IsDBNull(i) ? "" : reader.GetValue(i));
                            }
                            resultList.Add(row);
                        }
                    }
                }
            }
            return resultList;
        }

        public async Task<byte[]> GetTemplateBytesAsync(string? base64Template, string templateName)
        {
            if (!string.IsNullOrWhiteSpace(base64Template))
            {
                var cleanBase64 = base64Template.Contains(",") ? base64Template.Split(',')[1] : base64Template;
                return Convert.FromBase64String(cleanBase64);
            }

            if (string.IsNullOrWhiteSpace(templateName))
            {
                throw new Exception("Vui lòng cung cấp chuỗi Base64 hoặc tên file mẫu (templateName)!");
            }

            string serverTemplatePath = Path.Combine(_env.ContentRootPath, "Templates", templateName);

            if (!File.Exists(serverTemplatePath))
            {
                throw new Exception($"Không tìm thấy file mẫu '{templateName}' trên máy chủ. Vui lòng kiểm tra lại thư mục Templates!");
            }

            return await File.ReadAllBytesAsync(serverTemplatePath);
        }

        public async Task<string> GenerateReportBase64Async(DynamicReportRequest request)
        {
            var reportData = await GetDynamicReportAsync(request);

            if (reportData == null || reportData.Count == 0)
            {
                throw new Exception("Không tìm thấy dữ liệu để xuất báo cáo!");
            }
            var dataToFill = reportData.FirstOrDefault();

            byte[] templateBytes = await GetTemplateBytesAsync(request.base64Template, request.templateName);

            using (var outputStream = new MemoryStream())
            {
                MiniWord.SaveAsByTemplate(outputStream, templateBytes, dataToFill);

                return Convert.ToBase64String(outputStream.ToArray());
            }
        }
        public async Task<MaintenanceScheduleExportWord> GetYearlyPlanDataAsync(int year)
        {
            var schedules = await _context.EquipmentMaintenanceSchedule
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.preparer)
                .Include(x => x.approver)
               
                .Where(x => x.isActive == true && x.year == year && x.status == MaintenanceScheduleStatus.Approved)
                .OrderBy(x => x.equipment.productCategory.equipmentName)
                .ToListAsync();

            // Nếu không có kế hoạch nào được duyệt trong năm đó
            if (!schedules.Any())
            {
                throw new Exception($"Không có kế hoạch bảo trì nào được phê duyệt trong năm {year}.");
            }

            var firstRow = schedules.FirstOrDefault();

            var reportData = new MaintenanceScheduleExportWord
            {
                year = year,
                day = DateTime.Now.Day.ToString("D2"),
                month = DateTime.Now.Month.ToString("D2"),
                yearNow = DateTime.Now.Year.ToString(),

                preparerName = firstRow?.preparer?.userName ?? "",
                approverName = firstRow?.approver?.userName ?? "",

                item = new List<Dictionary<string, object>>()
            };

            int index = 1;
            foreach (var sch in schedules)
            {
                var category = sch.equipment?.productCategory;

                var dictItem = new Dictionary<string, object>
                {
                    { "stt", index++ },
                    { "equipmentName", category?.equipmentName ?? "" },
                    { "equipmentCode", category?.equipmentCode ?? "" },
                    { "location", category?.location ?? "" },
                    { "Task", sch.task }, 
                    { "note", sch.note }
                };

                dictItem.Add("m1", sch.m1 ? "X" : "");
                dictItem.Add("m2", sch.m2 ? "X" : "");
                dictItem.Add("m3", sch.m3 ? "X" : "");
                dictItem.Add("m4", sch.m4 ? "X" : "");
                dictItem.Add("m5", sch.m5 ? "X" : "");
                dictItem.Add("m6", sch.m6 ? "X" : "");
                dictItem.Add("m7", sch.m7 ? "X" : "");
                dictItem.Add("m8", sch.m8 ? "X" : "");
                dictItem.Add("m9", sch.m9 ? "X" : "");
                dictItem.Add("m10", sch.m10 ? "X" : "");
                dictItem.Add("m11", sch.m11 ? "X" : "");
                dictItem.Add("m12", sch.m12 ? "X" : "");

                reportData.item.Add(dictItem);
            }

            return reportData;
        }
        public async Task<WaterSystemLogExportWord> GetWaterSystemLogDataAsync(int logId)
        {
            var log = await _context.WaterSystemLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.dailyLogs).ThenInclude(d => d.tracker)
                .FirstOrDefaultAsync(x => x.id == logId && x.status == WaterLogStatus.Completed);

            if (log == null)
            {
                throw new Exception("Không tìm thấy phiếu theo dõi hoặc phiếu chưa được duyệt hoàn tất.");
            }

            var category = log.equipment?.productCategory;

            // DÙNG TÊN MỚI Ở ĐÂY
            var reportData = new WaterSystemLogExportWord
            {
                equipmentCode = category?.equipmentCode ?? "",
                allowedRange = log.allowedRange ?? "",
                trackingTime = log.trackingTime ?? "",
                location = category?.location ?? "",
                month = log.month.ToString("D2"),
                year = log.year.ToString(),
                inspectionDate = log.inspectionDate?.ToString("dd/MM/yyyy") ?? "..../..../........",
                inspectorName = log.inspector?.userName ?? "",
                reviewDate = log.reviewDate?.ToString("dd/MM/yyyy") ?? "..../..../........",
                reviewerName = log.reviewer?.userName ?? "",
                item = new List<Dictionary<string, object>>()
            };

            for (int i = 1; i <= 16; i++)
            {
                int leftDay = i;
                int rightDay = i + 16;

                var leftData = log.dailyLogs.FirstOrDefault(d => d.day == leftDay);
                var rightData = log.dailyLogs.FirstOrDefault(d => d.day == rightDay);

                var dictItem = new Dictionary<string, object>
                {
                    { "dayL", leftDay },
                    { "valL", leftData?.usValue ?? "" },
                    { "userL", leftData?.tracker?.userName ?? "" },

                    { "dayR", rightDay <= DateTime.DaysInMonth(log.year, log.month) ? rightDay.ToString() : "" },
                    { "valR", rightData?.usValue ?? "" },
                    { "userR", rightData?.tracker?.userName ?? "" }
                };

                reportData.item.Add(dictItem);
            }

            return reportData;
        }
        public async Task<Dictionary<string, object>> GetEquipmentUsageLogDataAsync(int logId)
        {
            var log = await _context.EquipmentUsageLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.preparer)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.dailyLogs)
                .FirstOrDefaultAsync(x => x.id == logId && x.status == UsageLogStatus.Completed);

            if (log == null)
            {
                throw new Exception("Không tìm thấy phiếu theo dõi hoặc phiếu chưa được duyệt hoàn tất.");
            }

            var category = log.equipment?.productCategory;

            var reportData = new Dictionary<string, object>
            {
                { "equipmentName", category?.equipmentName ?? "" },
                { "modelManufacturer", $"{category?.model} / {category?.manufacturer}" },
                { "equipmentCode", category?.equipmentCode ?? "" },
                { "location", category?.location ?? "" },
                { "month", log.month.ToString("D2") },
                { "year", log.year.ToString() },
                { "weekOfMonth", log.weekOfMonth },

                { "preparerName", log.preparer?.userName ?? "" },
                { "inspectionDate", log.inspectionDate?.ToString("dd/MM/yyyy") ?? "……/……/……" },
                { "inspectorName", log.inspector?.userName ?? "" },
                { "reviewDate", log.reviewDate?.ToString("dd/MM/yyyy") ?? "……/……/……" },
                { "reviewerName", log.reviewer?.userName ?? "" }
            };

            for (int i = 2; i <= 8; i++)
            {
                string prefix = $"d{i}"; 
                var dailyLog = log.dailyLogs.FirstOrDefault(d => d.dayOfWeek == i);

                reportData.Add($"{prefix}_date", dailyLog != null ? $"Ngày {dailyLog.logDate:dd/MM}" : "Ngày ………");

                reportData.Add($"{prefix}_s1", dailyLog?.shift1 ?? "");
                reportData.Add($"{prefix}_s2", dailyLog?.shift2 ?? "");
                reportData.Add($"{prefix}_s3", dailyLog?.shift3 ?? "");
                reportData.Add($"{prefix}_s4", dailyLog?.shift4 ?? "");
                reportData.Add($"{prefix}_s5", dailyLog?.shift5 ?? "");

                reportData.Add($"{prefix}_usage", dailyLog?.usageCount ?? "");
                reportData.Add($"{prefix}_call", dailyLog?.maintenanceCallTime ?? "");

                reportData.Add($"{prefix}_deconD", dailyLog?.dailyDecon ?? "");
                reportData.Add($"{prefix}_deconP", dailyLog?.preMaintenanceDecon ?? "");

                reportData.Add($"{prefix}_normalY", dailyLog?.isNormal == true ? "☑" : "☐");
                reportData.Add($"{prefix}_normalN", dailyLog?.isNormal == false ? "☑" : "☐");

                reportData.Add($"{prefix}_qcY", dailyLog?.qcResult == true ? "☑" : "☐");
                reportData.Add($"{prefix}_qcN", dailyLog?.qcResult == false ? "☑" : "☐");
            }

            return reportData;
        }

    }
}