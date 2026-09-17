using THUCTAP.Models;
using THUCTAP.ViewModels;   

namespace THUCTAP.Mappers
{
    public static class MaintenanceLogMapper
    {
        public static EquipmentMaintenanceLog ToEntity(this MaintenanceLogRequest request)
        {
            return new EquipmentMaintenanceLog
            {
                equipmentId = request.equipmentId,
                logDate = request.logDate,
                isDaily = request.isDaily,
                isWeekly = request.isWeekly,
                isMonthly = request.isMonthly,
                isQuarterly = request.isQuarterly,
                isAsNeeded = request.isAsNeeded,
                note = request.note,
                executorId = request.executorId,
                relatedMaintenanceId = request.relatedMaintenanceId,
                status = MaintenanceLogStatus.PendingInspection // Mặc định cấp 1
            };
        }

        public static MaintenanceLogResponseDto ToResponse(this EquipmentMaintenanceLog entity)
        {
            // Trích xuất khóa ngoại
            var productCat = entity.equipment?.productCategory;
            var maintenance = entity.relatedMaintenance;

            return new MaintenanceLogResponseDto
            {
                id = entity.id,
                equipmentId = entity.equipmentId,
                equipmentCode = productCat?.equipmentCode ?? string.Empty,
                equipmentName = productCat?.equipmentName ?? string.Empty,
                
                logDate = entity.logDate,
                isDaily = entity.isDaily ? "X" : "",
                isWeekly = entity.isWeekly ? "X" : "",
                isMonthly = entity.isMonthly ? "X" : "",
                isQuarterly = entity.isQuarterly ? "X" : "",
                isAsNeeded = entity.isAsNeeded ? "X" : "",
                note = entity.note,
                statusName = entity.status.ToString(),
                
                executorName = entity.executor?.userName ?? string.Empty,
                inspectorName = entity.inspector?.userName ?? string.Empty,
                inspectionDate = entity.inspectionDate,
                reviewerName = entity.reviewer?.userName ?? string.Empty,
                reviewDate = entity.reviewDate, 
            };
        }
        public static void UpdateEntity(this EquipmentMaintenanceLog entity, MaintenanceLogRequest request)
        {
            entity.equipmentId = request.equipmentId;
            entity.logDate = request.logDate;
            entity.isDaily = request.isDaily;
            entity.isWeekly = request.isWeekly;
            entity.isMonthly = request.isMonthly;
            entity.isQuarterly = request.isQuarterly;
            entity.isAsNeeded = request.isAsNeeded;
            entity.note = request.note;
            entity.executorId = request.executorId;
            entity.relatedMaintenanceId = request.relatedMaintenanceId;
         
        }
    }
}