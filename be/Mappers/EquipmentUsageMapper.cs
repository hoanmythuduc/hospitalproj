using System.Linq;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class EquipmentUsageMapper
    {
        public static EquipmentUsageLogResponse ToResponse(this EquipmentUsageLog entity)
        {
            var productCat = entity.equipment?.productCategory;

            return new EquipmentUsageLogResponse
            {
                id = entity.id,
                equipmentId = entity.equipmentId,
                equipmentCode = productCat?.equipmentCode ?? string.Empty,
                equipmentName = productCat?.equipmentName ?? string.Empty,
                location = productCat?.location ?? string.Empty,
                month = entity.month,
                year = entity.year,
                weekOfMonth = entity.weekOfMonth,
                statusName = entity.status.ToString(),

                preparerName = entity.preparer?.userName ?? string.Empty,
                inspectorName = entity.inspector?.userName ?? string.Empty,
                reviewerName = entity.reviewer?.userName ?? string.Empty,

                dailyLogs = entity.dailyLogs.Select(d => new EquipmentUsageDailyLogResponse
                {
                    id = d.id,
                    logDate = d.logDate,
                    dayOfWeek = d.dayOfWeek,
                    shift1 = d.shift1,
                    shift2 = d.shift2,
                    shift3 = d.shift3,
                    shift4 = d.shift4,
                    shift5 = d.shift5,
                    usageCount = d.usageCount,
                    maintenanceCallTime = d.maintenanceCallTime,
                    dailyDecon = d.dailyDecon,
                    preMaintenanceDecon = d.preMaintenanceDecon,
                    isNormal = d.isNormal,
                    qcResult = d.qcResult
                }).OrderBy(d => d.dayOfWeek).ToList()
            };
        }

        public static EquipmentUsageLog ToEntity(this SaveUsageDailyLogRequest request)
        {
            return new EquipmentUsageLog
            {
                equipmentId = request.equipmentId,
                year = request.year,
                month = request.month,
                weekOfMonth = request.weekOfMonth,
                preparerId = request.preparerId,
                status = UsageLogStatus.Tracking,
                dailyLogs = new System.Collections.Generic.List<EquipmentUsageDailyLog>()
            };
        }

        public static void UpdateDailyLog(this EquipmentUsageDailyLog entity, SaveUsageDailyLogRequest request)
        {
            entity.logDate = request.logDate;
            entity.shift1 = request.shift1;
            entity.shift2 = request.shift2;
            entity.shift3 = request.shift3;
            entity.shift4 = request.shift4;
            entity.shift5 = request.shift5;
            entity.usageCount = request.usageCount;
            entity.maintenanceCallTime = request.maintenanceCallTime;
            entity.dailyDecon = request.dailyDecon;
            entity.preMaintenanceDecon = request.preMaintenanceDecon;
            entity.isNormal = request.isNormal;
            entity.qcResult = request.qcResult;
        }
    }
}