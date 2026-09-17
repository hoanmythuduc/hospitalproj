using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class MaintenanceScheduleMapper
    {
        public static EquipmentMaintenanceSchedule ToEntity(this MaintenanceScheduleRequest request)
        {
            return new EquipmentMaintenanceSchedule
            {
                equipmentId = request.equipmentId,
                year = request.year,
                task = request.task,
                note = request.note,
                m1 = request.m1,
                m2 = request.m2,
                m3 = request.m3,
                m4 = request.m4,
                m5 = request.m5,
                m6 = request.m6,
                m7 = request.m7,
                m8 = request.m8,
                m9 = request.m9,
                m10 = request.m10,
                m11 = request.m11,
                m12 = request.m12,
                preparerId = request.preparerId,
                status = MaintenanceScheduleStatus.PendingApproval // Vừa tạo là chờ duyệt
            };
        }

        public static MaintenanceScheduleResponseDto ToResponse(this EquipmentMaintenanceSchedule entity)
        {
            var productCat = entity.equipment?.productCategory;

            return new MaintenanceScheduleResponseDto
            {
                id = entity.id,
                equipmentId = entity.equipmentId,
                equipmentCode = productCat?.equipmentCode ?? string.Empty,
                equipmentName = productCat?.equipmentName ?? string.Empty,

                year = entity.year,
                task = entity.task,
                note = entity.note,
                location = productCat?.location ?? string.Empty,
                m1 = entity.m1 ? "X" : "",
                m2 = entity.m2 ? "X" : "",
                m3 = entity.m3 ? "X" : "",
                m4 = entity.m4 ? "X" : "",
                m5 = entity.m5 ? "X" : "",
                m6 = entity.m6 ? "X" : "",
                m7 = entity.m7 ? "X" : "",
                m8 = entity.m8 ? "X" : "",
                m9 = entity.m9 ? "X" : "",
                m10 = entity.m10 ? "X" : "",
                m11 = entity.m11 ? "X" : "",
                m12 = entity.m12 ? "X" : "",

                statusName = entity.status.ToString(),
                preparerName = entity.preparer?.userName ?? string.Empty,
                approverName = entity.approver?.userName ?? string.Empty
            };
        }

        public static void UpdateEntity(this EquipmentMaintenanceSchedule entity, MaintenanceScheduleRequest request)
        {
            entity.equipmentId = request.equipmentId;
            entity.year = request.year;
            entity.task = request.task;
            entity.note = request.note;
            entity.m1 = request.m1; entity.m2 = request.m2; entity.m3 = request.m3; entity.m4 = request.m4;
            entity.m5 = request.m5; entity.m6 = request.m6; entity.m7 = request.m7; entity.m8 = request.m8;
            entity.m9 = request.m9; entity.m10 = request.m10; entity.m11 = request.m11; entity.m12 = request.m12;
            entity.preparerId = request.preparerId;
        }
    }
}