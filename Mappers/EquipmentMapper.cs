using THUCTAP.Models;
using THUCTAP.ViewModels;
using System.Linq;

namespace THUCTAP.Mappers
{
    public static class EquipmentMapper
    {
        public static Equipment ToEquipment(this EquipmentRequest request)
        {

            return new Equipment
            {
               
                productCategoryId = request.productCategoryId,
                isActive = request.isActive,

                managers = request.managers.Select(m => new EquipmentManager
                {
                    userId = m.userId,
                    userName = m.userName,
                    fromDate = m.fromDate
                }).ToList(),

                maintenances = request.maintenances.Select(m => new EquipmentMaintenance
                {
                    maintenanceDate = m.maintenanceDate,

                    incidentTime = m.incidentTime,
                    engineerArrivedTime = m.engineerArrivedTime,
                    completedTime = m.completedTime,
                    actionType = m.actionType,
                    content = m.content,
                    purpose = m.purpose,
                    labSignature = m.labSignature,
                    engineerSignature = m.engineerSignature
                }).ToList()
            };
        }

        public static void UpdateEquipment(this Equipment entity, EquipmentRequest request)
        {
            entity.productCategoryId = request.productCategoryId;
            entity.isActive = request.isActive;

            entity.managers.Clear();
            foreach (var m in request.managers)
            {
                entity.managers.Add(new EquipmentManager
                {
                    userId = m.userId,
                    userName = m.userName,
                    fromDate = m.fromDate
                });
            }

            entity.maintenances.Clear();
            foreach (var m in request.maintenances)
            {
                entity.maintenances.Add(new EquipmentMaintenance
                {
                    maintenanceDate = m.maintenanceDate,
                    incidentTime = m.incidentTime,
                    engineerArrivedTime = m.engineerArrivedTime,
                    completedTime = m.completedTime,
                    actionType = m.actionType,
                    content = m.content,
                    purpose = m.purpose,
                    labSignature = m.labSignature,
                    engineerSignature = m.engineerSignature
                });
            }
        }

        public static EquipmentResponseDto ToEquipmentResponse(this Equipment entity)
        {
            var p = entity.productCategory;
            var s = p?.supplier;

            return new EquipmentResponseDto
            {
                id = entity.id,
                productCategoryId = entity.productCategoryId,
                isActive = entity.isActive,

                equipmentCode = p?.equipmentCode ?? string.Empty,
                equipmentName = p?.equipmentName ?? string.Empty,
                model = p?.model ?? string.Empty,
                manufacturer = p?.manufacturer ?? string.Empty,
                countryOfOrigin = p?.countryOfOrigin ?? string.Empty,
                serialNumber = p?.serialNumber ?? string.Empty,
                location = p?.location ?? string.Empty,
                receivedDate = p?.receivedDate,
                conditionWhenReceived = p?.conditionWhenReceived ?? string.Empty,
                startDateOfUse = p?.startDateOfUse,
                conditionWhenStarted = p?.conditionWhenStarted ?? string.Empty,

                supplierName = s?.supplierName ?? string.Empty,
                supplierAddress = s?.supplierAddress ?? string.Empty,
                engineerInCharge = s?.engineerInCharge ?? string.Empty,
                supplierPhone = s?.supplierPhone ?? string.Empty,
                supplierEmail = s?.supplierEmail ?? string.Empty,

                managers = entity.managers?.Select(m => new EquipmentManagerResponseDto
                {
                    id = m.id,
                    userId = m.userId,
                    userName = m.userName,
                    fromDate = m.fromDate
                }).ToList() ?? new List<EquipmentManagerResponseDto>(),

                maintenances = entity.maintenances?.Select(m => new EquipmentMaintenanceResponseDto
                {
                    id = m.id,
                    maintenanceDate = m.maintenanceDate,

                    incidentTime = m.incidentTime?.ToString("dd/MM/yyyy HH:mm") ?? "",
                    engineerArrivedTime = m.engineerArrivedTime?.ToString("dd/MM/yyyy HH:mm") ?? "",
                    completedTime = m.completedTime?.ToString("dd/MM/yyyy HH:mm") ?? "",

                    actionType = m.actionType,
                    isMaintenance = (m.actionType == "Bảo trì") ? "X" : "",
                    isRepair = (m.actionType == "Sửa chữa") ? "X" : "",
                    isCalibration = (m.actionType == "Hiệu chuẩn") ? "X" : "",
                    content = m.content,
                    purpose = m.purpose,
                    labSignature = m.labSignature,
                    engineerSignature = m.engineerSignature
                }).ToList() ?? new List<EquipmentMaintenanceResponseDto>()
            };
        }
    }
}