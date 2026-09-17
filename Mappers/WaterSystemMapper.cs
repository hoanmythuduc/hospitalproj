using System.Linq;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class WaterSystemMapper
    {
        public static WaterSystemLogResponse ToResponse(this WaterSystemLog entity)
        {
            return new WaterSystemLogResponse
            {
                id = entity.id,
                equipmentId = entity.equipmentId,
                equipmentCode = entity.equipment?.productCategory?.equipmentCode ?? string.Empty,
                month = entity.month,
                year = entity.year,
                statusName = entity.status.ToString(),
                location = entity.equipment?.productCategory?.location ?? string.Empty,
                allowedRange = entity.allowedRange,
                trackingTime = entity.trackingTime,
                preparerName = entity.preparer?.userName ?? string.Empty,
                inspectorName = entity.inspector?.userName ?? string.Empty,
                reviewerName = entity.reviewer?.userName ?? string.Empty,
                dailyLogs = entity.dailyLogs.Select(d => new WaterSystemDailyLogResponse
                {
                    day = d.day,
                    usValue = d.usValue,
                    trackerName = d.tracker?.userName ?? string.Empty
                }).OrderBy(d => d.day).ToList()
            };
        }
    }
}