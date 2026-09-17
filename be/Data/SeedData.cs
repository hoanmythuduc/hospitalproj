using Microsoft.EntityFrameworkCore;
using System;
using THUCTAP.Models;

namespace THUCTAP.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppAction>().HasData(
                new AppAction { id = 1, menuId = 6, label = "View", code = "VIEW", endpoint = "/api/users", method = "GET" },
                new AppAction { id = 2, menuId = 6, label = "Create", code = "CREATE", endpoint = "/api/users", method = "POST" },
                new AppAction { id = 3, menuId = 6, label = "Update", code = "EDIT", endpoint = "/api/users/{id}", method = "PUT" },
                new AppAction { id = 4, menuId = 6, label = "Delete", code = "DELETE", endpoint = "/api/users/{id}", method = "DELETE" },
                new AppAction { id = 5, menuId = 7, label = "View", code = "VIEW", endpoint = "/api/groups", method = "GET" },
                new AppAction { id = 6, menuId = 7, label = "Create", code = "CREATE", endpoint = "/api/groups", method = "POST" },
                new AppAction { id = 7, menuId = 7, label = "Update", code = "EDIT", endpoint = "/api/groups/{id}", method = "PUT" },
                new AppAction { id = 8, menuId = 7, label = "Delete", code = "DELETE", endpoint = "/api/groups/{id}", method = "DELETE" }
            );

            modelBuilder.Entity<Menu>().HasData(
                 new Menu { id = 1, label = "SECURITY & SYSTEM", to = "", icon = "shield", parentId = null },
                 new Menu { id = 2, label = "EMPLOYEE MANAGEMENT", to = "", icon = "users", parentId = null },
                 new Menu { id = 3, label = "ADMINISTRATION", to = "", icon = "settings", parentId = null },
                 new Menu { id = 4, label = "TRANSACTIONS", to = "", icon = "shopping-cart", parentId = null },
                 new Menu { id = 5, label = "MASTER DATA", to = "", icon = "database", parentId = null },
                 new Menu { id = 6, label = "User Accounts", to = "/system/users", icon = "user", parentId = 1 },
                 new Menu { id = 7, label = "User Groups", to = "/system/groups", icon = "users", parentId = 1 },
                 new Menu { id = 8, label = "Employee Management", to = "/employee/manage", icon = "user-check", parentId = 2 },
                 new Menu { id = 9, label = "Administration", to = "/admin/settings", icon = "sliders", parentId = 3 },
                 new Menu { id = 10, label = "Orders", to = "/transactions/orders", icon = "file-text", parentId = 4 },
                 new Menu { id = 11, label = "Invoice Management", to = "/transactions/invoices", icon = "file-invoice", parentId = 4 },
                 new Menu { id = 12, label = "Product Categories", to = "/master/product-categories", icon = "tag", parentId = 5 },
                 new Menu { id = 13, label = "Customer Categories", to = "/master/customer-categories", icon = "users", parentId = 5 },
                 new Menu { id = 14, label = "Customer Master", to = "/master/customers", icon = "user", parentId = 5 },
                 new Menu { id = 15, label = "Maintenance Plan", to = "/transactions/maintenance-plan", icon = "calendar", parentId = 4 }
             );

            modelBuilder.Entity<ProductCategory>().HasData(
                 new ProductCategory
                 {
                     id = 1,
                     equipmentCode = "TB-XN-01",
                     equipmentName = "Máy ly tâm Huyết học",
                     model = "CENT-200",
                     manufacturer = "BioTech Lab",
                     countryOfOrigin = "Đức",
                     supplierId = 1,
                     serialNumber = "SN-2026001",
                     location = "Phòng Xét nghiệm Hóa sinh",
                     receivedDate = new DateTime(2026, 8, 1),
                     conditionWhenReceived = "Mới 100%",
                     startDateOfUse = new DateTime(2026, 8, 5),
                     conditionWhenStarted = "Hoạt động tốt",

                     dailyTask = "Kiểm tra hoạt động máy",
                     weeklyTask = "Vệ sinh buồng ly tâm",
                     monthlyTask = "Tra dầu rotor",
                     quarterlyTask = "Bảo trì động cơ",
                     asNeededTask = "Thay thế linh kiện",

                     isActive = true,
                     createdAt = new DateTime(2026, 8, 26),
                     updatedAt = new DateTime(2026, 8, 26)
                 },
                 new ProductCategory
                 {
                     id = 2,
                     equipmentCode = "HA-OM-01",
                     equipmentName = "Máy đo huyết áp điện tử",
                     model = "HEM-7120",
                     manufacturer = "Omron",
                     countryOfOrigin = "Nhật Bản",
                     supplierId = 2,
                     serialNumber = "SN-2026002",
                     location = "Phòng Khám Nội",
                     receivedDate = new DateTime(2026, 8, 10),
                     conditionWhenReceived = "Mới 100%",
                     startDateOfUse = new DateTime(2026, 8, 12),
                     conditionWhenStarted = "Hoạt động tốt",

                     dailyTask = "Kiểm tra pin và nguồn",
                     weeklyTask = "Vệ sinh màn hình",
                     monthlyTask = "Kiểm tra vòng bít",
                     quarterlyTask = "Đo kiểm định kỳ",
                     asNeededTask = "Thay pin/vòng bít",

                     isActive = true,
                     createdAt = new DateTime(2026, 8, 26),
                     updatedAt = new DateTime(2026, 8, 26)
                 },
                 new ProductCategory
                 {
                     id = 3,
                     equipmentCode = "OXY-5L-01",
                     equipmentName = "Máy tạo oxy 5 Lít",
                     model = "OXY-5",
                     manufacturer = "Yuwell",
                     countryOfOrigin = "Trung Quốc",
                     supplierId = 1,
                     serialNumber = "SN-2026003",
                     location = "Phòng Cấp Cứu",
                     receivedDate = new DateTime(2026, 8, 15),
                     conditionWhenReceived = "Mới 100%",
                     startDateOfUse = new DateTime(2026, 8, 16),
                     conditionWhenStarted = "Hoạt động tốt",

                     dailyTask = "Kiểm tra lưu lượng oxy",
                     weeklyTask = "Vệ sinh bình làm ẩm",
                     monthlyTask = "Thay bộ lọc thô",
                     quarterlyTask = "Bảo trì động cơ nén",
                     asNeededTask = "Thay hạt zeolite",

                     isActive = true,
                     createdAt = new DateTime(2026, 8, 26),
                     updatedAt = new DateTime(2026, 8, 26)
                 },
                 new ProductCategory
                 {
                     id = 4,
                     equipmentCode = "KXN-RO-01",
                     equipmentName = "Hệ thống lọc nước RO",
                     model = "RO-LAB-500",
                     manufacturer = "AquaCare",
                     countryOfOrigin = "Việt Nam",
                     supplierId = 1,
                     serialNumber = "SN-RO-2026",
                     location = "Sinh hóa - Huyết học - Miễn dịch",
                     receivedDate = new DateTime(2026, 1, 10),
                     conditionWhenReceived = "Mới 100%",
                     startDateOfUse = new DateTime(2026, 1, 15),
                     conditionWhenStarted = "Hoạt động tốt",
                     dailyTask = "Kiểm tra độ dẫn điện <1,0 µS/cm",
                     weeklyTask = "Vệ sinh buồng lọc",
                     monthlyTask = "Rửa màng lọc",
                     quarterlyTask = "Bảo trì hệ thống van",
                     asNeededTask = "Thay thế lõi lọc/màng RO",
                     isActive = true,
                     createdAt = new DateTime(2026, 8, 26),
                     updatedAt = new DateTime(2026, 8, 26)
                 }
             );
            modelBuilder.Entity<CustomerCategory>().HasData(
                new CustomerCategory { id = 1, groupName = "Khách hàng V.I.P", discount = 15.0m, isActive = true, createdAt = new DateTime(2026, 8, 11), updatedAt = new DateTime(2026, 8, 11) },
                new CustomerCategory { id = 2, groupName = "Khách mua sỉ", discount = 10.0m, isActive = true, createdAt = new DateTime(2026, 8, 11), updatedAt = new DateTime(2026, 8, 11) },
                new CustomerCategory { id = 3, groupName = "Khách vãng lai", discount = 0.0m, isActive = true, createdAt = new DateTime(2026, 8, 11), updatedAt = new DateTime(2026, 8, 11) },
                new CustomerCategory { id = 4, groupName = "Khách hàng thân thiết", discount = 5.0m, isActive = true, createdAt = new DateTime(2026, 8, 11), updatedAt = new DateTime(2026, 8, 11) },
                new CustomerCategory { id = 5, groupName = "Đối tác chiến lược", discount = 20.0m, isActive = true, createdAt = new DateTime(2026, 8, 11), updatedAt = new DateTime(2026, 8, 11) }
            );

            modelBuilder.Entity<User>().HasData(
                new User { id = 1, userName = "admin", userCode = "NV001", password = "123", email = "admin@test.com", department = "Ban Giám Đốc" },
                new User { id = 2, userName = "bacsi01", userCode = "BS001", password = "123", email = "bs@test.com", department = "Khoa Nội" }
            );

            modelBuilder.Entity<Group>().HasData(
                new Group { id = 1, name = "Quản trị hệ thống", code = "ADMIN" },
                new Group { id = 2, name = "Bác sĩ", code = "DOCTOR" },
                new Group { id = 3, name = "Nhân viên", code = "Employee" }
            );

            modelBuilder.Entity<FormField>().HasData(
                new FormField { id = 1, entityName = "User", field = "username", label = "Tên đăng nhập", type = "text", colSpan = 6, sortOrder = 1 },
                new FormField { id = 2, entityName = "User", field = "department", label = "Phòng ban", type = "select", colSpan = 6, sortOrder = 2 }
            );

            modelBuilder.Entity<CustomerMaster>().HasData(
                new CustomerMaster { id = 1, supplierName = "Công ty TBYT MedJin", supplierAddress = "Quận 3, TP.HCM", engineerInCharge = "Lê Văn C", supplierPhone = "0988777666", supplierEmail = "support@medjin.com", categoryId = 1 },
                new CustomerMaster { id = 2, supplierName = "Công ty TBYT ABC", supplierAddress = "Quận 1, TP.HCM", engineerInCharge = "Nguyễn Văn A", supplierPhone = "0909123456", supplierEmail = "contact@abc.com", categoryId = 2 }
            );
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { id = 1, productCategoryId = 1, isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },
                new Equipment { id = 2, productCategoryId = 2, isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },
                new Equipment { id = 3, productCategoryId = 3, isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },
                new Equipment { id = 4, productCategoryId = 4, isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) }
            );
            modelBuilder.Entity<EquipmentManager>().HasData(

                new EquipmentManager { id = 1, equipmentId = 1, userId = 1, userName = "admin", fromDate = new DateTime(2026, 8, 20), isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },
                new EquipmentManager { id = 2, equipmentId = 1, userId = 2, userName = "bacsi01", fromDate = new DateTime(2026, 9, 1), isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },

                new EquipmentManager { id = 3, equipmentId = 1, userId = 3, userName = "admin02", fromDate = new DateTime(2026, 9, 5), isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },

                new EquipmentManager { id = 4, equipmentId = 2, userId = 1, userName = "admin", fromDate = new DateTime(2026, 8, 20), isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },
                new EquipmentManager { id = 5, equipmentId = 2, userId = 2, userName = "bacsi01", fromDate = new DateTime(2026, 9, 1), isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },

                new EquipmentManager { id = 6, equipmentId = 2, userId = 4, userName = "Nguyễn Văn An", fromDate = new DateTime(2026, 9, 10), isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },

                new EquipmentManager { id = 7, equipmentId = 3, userId = 2, userName = "bacsi01", fromDate = new DateTime(2026, 8, 25), isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },

                new EquipmentManager { id = 8, equipmentId = 3, userId = 3, userName = "admin02", fromDate = new DateTime(2026, 9, 1), isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) },

                new EquipmentManager { id = 9, equipmentId = 3, userId = 4, userName = "Nguyễn Văn An", fromDate = new DateTime(2026, 9, 15), isActive = true, createdAt = new DateTime(2026, 8, 26), updatedAt = new DateTime(2026, 8, 26) }
            );
            modelBuilder.Entity<EquipmentMaintenance>().HasData(

                new EquipmentMaintenance
                {
                    id = 1,
                    equipmentId = 1,
                    maintenanceDate = new DateTime(2026, 10, 15),
                    incidentTime = null,
                    engineerArrivedTime = new DateTime(2026, 10, 15, 8, 30, 0),
                    completedTime = new DateTime(2026, 10, 15, 11, 0, 0),
                    actionType = "Bảo trì",
                    content = "Vệ sinh buồng ly tâm, kiểm tra rotor",
                    purpose = "Bảo trì định kỳ 6 tháng",
                    labSignature = "Đã ký",
                    engineerSignature = "Nguyễn Văn A",
                    isActive = true,
                    createdAt = new DateTime(2026, 8, 26),
                    updatedAt = new DateTime(2026, 8, 26)
                },

                new EquipmentMaintenance
                {
                    id = 2,
                    equipmentId = 1,
                    maintenanceDate = new DateTime(2026, 12, 05),
                    incidentTime = new DateTime(2026, 12, 5, 8, 0, 0),
                    engineerArrivedTime = new DateTime(2026, 12, 5, 9, 30, 0),
                    completedTime = new DateTime(2026, 12, 5, 14, 0, 0),
                    actionType = "Sửa chữa",
                    content = "Thay thế bo mạch nguồn",
                    purpose = "Khắc phục lỗi không lên nguồn",
                    labSignature = "Đã ký",
                    engineerSignature = "Trần Văn B",
                    isActive = true,
                    createdAt = new DateTime(2026, 8, 26),
                    updatedAt = new DateTime(2026, 8, 26)
                },

                new EquipmentMaintenance
                {
                    id = 3,
                    equipmentId = 2,
                    maintenanceDate = new DateTime(2026, 11, 20),
                    incidentTime = null,
                    engineerArrivedTime = new DateTime(2026, 11, 20, 13, 30, 0),
                    completedTime = new DateTime(2026, 11, 20, 16, 0, 0),
                    actionType = "Hiệu chuẩn",
                    content = "Hiệu chuẩn cảm biến áp suất",
                    purpose = "Đảm bảo độ chính xác",
                    labSignature = "Đã ký",
                    engineerSignature = "Lê Văn C",
                    isActive = true,
                    createdAt = new DateTime(2026, 8, 26),
                    updatedAt = new DateTime(2026, 8, 26)
                },

                new EquipmentMaintenance
                {
                    id = 4,
                    equipmentId = 3,
                    maintenanceDate = new DateTime(2026, 11, 25),
                    incidentTime = new DateTime(2026, 11, 25, 10, 0, 0),
                    engineerArrivedTime = new DateTime(2026, 11, 25, 11, 15, 0),
                    completedTime = new DateTime(2026, 11, 25, 15, 45, 0),
                    actionType = "Sửa chữa",
                    content = "Thay bộ lọc khí",
                    purpose = "Máy kêu to",
                    labSignature = "Đã ký",
                    engineerSignature = "Trần Văn B",
                    isActive = true,
                    createdAt = new DateTime(2026, 8, 26),
                    updatedAt = new DateTime(2026, 8, 26)
                }
            );
            modelBuilder.Entity<EquipmentMaintenanceLog>().HasData(

                new EquipmentMaintenanceLog { id = 1, equipmentId = 1, logDate = new DateTime(2026, 8, 1), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "Máy hoạt động bình thường", status = MaintenanceLogStatus.Completed, executorId = 2, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 8), reviewerId = 1, reviewDate = new DateTime(2026, 8, 9), isActive = true, createdAt = new DateTime(2026, 8, 1), updatedAt = new DateTime(2026, 8, 9) },
                new EquipmentMaintenanceLog { id = 2, equipmentId = 1, logDate = new DateTime(2026, 8, 2), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "Vệ sinh buồng mẫu", status = MaintenanceLogStatus.Completed, executorId = 2, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 8), reviewerId = 1, reviewDate = new DateTime(2026, 8, 9), isActive = true, createdAt = new DateTime(2026, 8, 2), updatedAt = new DateTime(2026, 8, 9) },
                new EquipmentMaintenanceLog { id = 3, equipmentId = 1, logDate = new DateTime(2026, 8, 3), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "", status = MaintenanceLogStatus.Completed, executorId = 2, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 8), reviewerId = 1, reviewDate = new DateTime(2026, 8, 9), isActive = true, createdAt = new DateTime(2026, 8, 3), updatedAt = new DateTime(2026, 8, 9) },
                new EquipmentMaintenanceLog { id = 4, equipmentId = 1, logDate = new DateTime(2026, 8, 4), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "Chạy mẫu test OK", status = MaintenanceLogStatus.Completed, executorId = 3, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 8), reviewerId = 1, reviewDate = new DateTime(2026, 8, 9), isActive = true, createdAt = new DateTime(2026, 8, 4), updatedAt = new DateTime(2026, 8, 9) },
                new EquipmentMaintenanceLog { id = 5, equipmentId = 1, logDate = new DateTime(2026, 8, 5), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "", status = MaintenanceLogStatus.Completed, executorId = 3, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 8), reviewerId = 1, reviewDate = new DateTime(2026, 8, 9), isActive = true, createdAt = new DateTime(2026, 8, 5), updatedAt = new DateTime(2026, 8, 9) },
                new EquipmentMaintenanceLog { id = 6, equipmentId = 1, logDate = new DateTime(2026, 8, 6), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "", status = MaintenanceLogStatus.Completed, executorId = 3, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 8), reviewerId = 1, reviewDate = new DateTime(2026, 8, 9), isActive = true, createdAt = new DateTime(2026, 8, 6), updatedAt = new DateTime(2026, 8, 9) },
                new EquipmentMaintenanceLog { id = 7, equipmentId = 1, logDate = new DateTime(2026, 8, 7), isDaily = true, isWeekly = true, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "Bảo dưỡng cuối tuần, xả sương", status = MaintenanceLogStatus.Completed, executorId = 2, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 8), reviewerId = 1, reviewDate = new DateTime(2026, 8, 9), isActive = true, createdAt = new DateTime(2026, 8, 7), updatedAt = new DateTime(2026, 8, 9) },

                new EquipmentMaintenanceLog { id = 8, equipmentId = 1, logDate = new DateTime(2026, 8, 8), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "", status = MaintenanceLogStatus.PendingReview, executorId = 3, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 15), reviewerId = null, reviewDate = null, isActive = true, createdAt = new DateTime(2026, 8, 8), updatedAt = new DateTime(2026, 8, 15) },
                new EquipmentMaintenanceLog { id = 9, equipmentId = 1, logDate = new DateTime(2026, 8, 9), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "", status = MaintenanceLogStatus.PendingReview, executorId = 3, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 15), reviewerId = null, reviewDate = null, isActive = true, createdAt = new DateTime(2026, 8, 9), updatedAt = new DateTime(2026, 8, 15) },

                new EquipmentMaintenanceLog { id = 10, equipmentId = 1, logDate = new DateTime(2026, 8, 10), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = true, note = "Lỗi bo mạch, đã gọi kỹ sư", status = MaintenanceLogStatus.PendingReview, executorId = 2, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 15), reviewerId = null, reviewDate = null, relatedMaintenanceId = 2, isActive = true, createdAt = new DateTime(2026, 8, 10), updatedAt = new DateTime(2026, 8, 15) },
                new EquipmentMaintenanceLog { id = 11, equipmentId = 1, logDate = new DateTime(2026, 8, 11), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "Máy đã sửa xong, chạy ổn", status = MaintenanceLogStatus.PendingReview, executorId = 2, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 15), reviewerId = null, reviewDate = null, isActive = true, createdAt = new DateTime(2026, 8, 11), updatedAt = new DateTime(2026, 8, 15) },
                new EquipmentMaintenanceLog { id = 12, equipmentId = 1, logDate = new DateTime(2026, 8, 12), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "", status = MaintenanceLogStatus.PendingReview, executorId = 3, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 15), reviewerId = null, reviewDate = null, isActive = true, createdAt = new DateTime(2026, 8, 12), updatedAt = new DateTime(2026, 8, 15) },
                new EquipmentMaintenanceLog { id = 13, equipmentId = 1, logDate = new DateTime(2026, 8, 13), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "", status = MaintenanceLogStatus.PendingReview, executorId = 3, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 15), reviewerId = null, reviewDate = null, isActive = true, createdAt = new DateTime(2026, 8, 13), updatedAt = new DateTime(2026, 8, 15) },
                new EquipmentMaintenanceLog { id = 14, equipmentId = 1, logDate = new DateTime(2026, 8, 14), isDaily = true, isWeekly = true, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "Bảo dưỡng cuối tuần", status = MaintenanceLogStatus.PendingReview, executorId = 2, inspectorId = 1, inspectionDate = new DateTime(2026, 8, 15), reviewerId = null, reviewDate = null, isActive = true, createdAt = new DateTime(2026, 8, 14), updatedAt = new DateTime(2026, 8, 15) },

                new EquipmentMaintenanceLog { id = 15, equipmentId = 1, logDate = new DateTime(2026, 8, 15), isDaily = true, isWeekly = false, isMonthly = false, isQuarterly = false, isAsNeeded = false, note = "Khởi động đầu ca tốt", status = MaintenanceLogStatus.PendingInspection, executorId = 2, inspectorId = null, inspectionDate = null, reviewerId = null, reviewDate = null, isActive = true, createdAt = new DateTime(2026, 8, 15), updatedAt = new DateTime(2026, 8, 15) }
            );
            modelBuilder.Entity<EquipmentMaintenanceSchedule>().HasData(
                new EquipmentMaintenanceSchedule
                {
                    id = 1,
                    equipmentId = 1,
                    year = 2026,
                    task = "Bảo dưỡng hệ thống quay và tra dầu",
                    note = "Yêu cầu kỹ sư hãng",
                    m1 = false,
                    m2 = false,
                    m3 = true,
                    m4 = false,
                    m5 = false,
                    m6 = true,
                    m7 = false,
                    m8 = false,
                    m9 = true,
                    m10 = false,
                    m11 = false,
                    m12 = true,
                    status = MaintenanceScheduleStatus.Approved, // Trạng thái Đã duyệt
                    preparerId = 2,
                    approverId = 1,
                    isActive = true,
                    createdAt = new DateTime(2026, 8, 26),
                    updatedAt = new DateTime(2026, 8, 26)
                },
                new EquipmentMaintenanceSchedule
                {
                    id = 2,
                    equipmentId = 2,
                    year = 2026,
                    task = "Hiệu chuẩn cảm biến áp suất",
                    note = "Đo đối chiếu máy thủy ngân",
                    m1 = false,
                    m2 = false,
                    m3 = false,
                    m4 = false,
                    m5 = false,
                    m6 = true,
                    m7 = false,
                    m8 = false,
                    m9 = false,
                    m10 = false,
                    m11 = false,
                    m12 = true,
                    status = MaintenanceScheduleStatus.Approved,
                    preparerId = 2,
                    approverId = 1,
                    isActive = true,
                    createdAt = new DateTime(2026, 8, 26),
                    updatedAt = new DateTime(2026, 8, 26)
                },
                new EquipmentMaintenanceSchedule
                {
                    id = 3,
                    equipmentId = 3,
                    year = 2026,
                    task = "Thay bộ lọc và kiểm tra lưu lượng",
                    note = "Ưu tiên làm đầu tháng",
                    m1 = true,
                    m2 = true,
                    m3 = true,
                    m4 = true,
                    m5 = true,
                    m6 = true,
                    m7 = true,
                    m8 = true,
                    m9 = true,
                    m10 = true,
                    m11 = true,
                    m12 = true,
                    status = MaintenanceScheduleStatus.Approved,
                    preparerId = 2,
                    approverId = 1,
                    isActive = true,
                    createdAt = new DateTime(2026, 8, 26),
                    updatedAt = new DateTime(2026, 8, 26)
                }
            );
            modelBuilder.Entity<WaterSystemLog>().HasData(
                new WaterSystemLog
                {
                    id = 1,
                    equipmentId = 4,
                    month = 8,
                    year = 2026,
                    status = WaterLogStatus.Completed,
                    preparerId = 2,
                    inspectorId = 1,
                    inspectionDate = new DateTime(2026, 8, 31),
                    reviewerId = 1,
                    reviewDate = new DateTime(2026, 9, 1),
                    isActive = true,
                    createdAt = new DateTime(2026, 8, 1),
                    updatedAt = new DateTime(2026, 9, 1)
                }
            );

            var dailyLogs = new List<WaterSystemDailyLog>();
            for (int i = 1; i <= 31; i++)
            {
                dailyLogs.Add(new WaterSystemDailyLog
                {
                    id = i,
                    waterSystemLogId = 1,
                    day = i,
                    usValue = "<1,0",
                    trackerId = 2,
                    isActive = true,
                    createdAt = new DateTime(2026, 8, i),
                    updatedAt = new DateTime(2026, 8, i)
                });
            }
            modelBuilder.Entity<WaterSystemDailyLog>().HasData(dailyLogs);
            modelBuilder.Entity<Order>().HasData(
                new Order { id = 1, orderNumber = "ORD-2026-001", orderDate = new DateTime(2026, 8, 1), customerId = 1, estimatedTotal = 2500000m, isActive = true, createdAt = new DateTime(2026, 8, 1), updatedAt = new DateTime(2026, 8, 1) },
                new Order { id = 2, orderNumber = "ORD-2026-002", orderDate = new DateTime(2026, 8, 5), customerId = 2, estimatedTotal = 2600000m, isActive = true, createdAt = new DateTime(2026, 8, 5), updatedAt = new DateTime(2026, 8, 5) },
                new Order { id = 3, orderNumber = "ORD-2026-003", orderDate = new DateTime(2026, 8, 10), customerId = 4, estimatedTotal = 2700000m, isActive = true, createdAt = new DateTime(2026, 8, 10), updatedAt = new DateTime(2026, 8, 10) },
                new Order { id = 4, orderNumber = "ORD-2026-004", orderDate = new DateTime(2026, 8, 15), customerId = 1, estimatedTotal = 2800000m, isActive = true, createdAt = new DateTime(2026, 8, 15), updatedAt = new DateTime(2026, 8, 15) },
                new Order { id = 5, orderNumber = "ORD-2026-005", orderDate = new DateTime(2026, 8, 20), customerId = 3, estimatedTotal = 2900000m, isActive = true, createdAt = new DateTime(2026, 8, 20), updatedAt = new DateTime(2026, 8, 20) }
            );
            modelBuilder.Entity<EquipmentUsageLog>().HasData(
                new EquipmentUsageLog
                {
                    id = 1,
                    equipmentId = 1,
                    month = 8,
                    year = 2026,
                    weekOfMonth = 1, 
                    status = UsageLogStatus.Completed, 

                    preparerId = 2,  
                    inspectorId = 11, 
                    inspectionDate = new DateTime(2026, 8, 8),
                    reviewerId = 1, 
                    reviewDate = new DateTime(2026, 8, 9),

                    isActive = true,
                    createdAt = new DateTime(2026, 8, 1),
                    updatedAt = new DateTime(2026, 8, 9)
                }
            );

            var usageDailyLogs = new List<EquipmentUsageDailyLog>();
            DateTime startDate = new DateTime(2026, 8, 3); 

            for (int i = 0; i < 7; i++)
            {
                int dayOfWeek = i + 2; 
                usageDailyLogs.Add(new EquipmentUsageDailyLog
                {
                    id = i + 1,
                    usageLogId = 1,
                    logDate = startDate.AddDays(i),
                    dayOfWeek = dayOfWeek,

                    shift1 = dayOfWeek < 7 ? "bacsi01" : "Nguyễn Văn An",
                    shift2 = dayOfWeek < 7 ? "X" : "", 
                    shift3 = dayOfWeek < 7 ? "Trần Thị Bình" : "Lê Trọng Đại",
                    shift4 = "TranThiDieu",
                    shift5 = "",

                    usageCount = "45",
                    maintenanceCallTime = dayOfWeek == 4 ? "15:00" : "", 
                    dailyDecon = "TranThiDieu",
                    preMaintenanceDecon = dayOfWeek == 4 ? "TranThiDieu" : "",

                    isNormal = dayOfWeek != 4, 
                    qcResult = dayOfWeek != 4, 

                    isActive = true,
                    createdAt = new DateTime(2026, 8, 1),
                    updatedAt = new DateTime(2026, 8, 1)
                });
            }
            modelBuilder.Entity<EquipmentUsageDailyLog>().HasData(usageDailyLogs);

            modelBuilder.Entity("User_Group").HasData(
                new { userid = 1, groupid = 1 },
                new { userid = 2, groupid = 2 }
            );

            modelBuilder.Entity("Group_Menu").HasData(
                new { groupid = 1, menuid = 1 },
                new { groupid = 1, menuid = 2 },
                new { groupid = 2, menuid = 2 },
                new { groupid = 2, menuid = 8 },
                new { groupid = 3, menuid = 2 },
                new { groupid = 3, menuid = 8 }
            );

            modelBuilder.Entity("Group_Action").HasData(
                new { groupid = 1, actionid = 1 },
                new { groupid = 1, actionid = 2 },
                new { groupid = 1, actionid = 3 },
                new { groupid = 1, actionid = 4 },
                new { groupid = 1, actionid = 5 },
                new { groupid = 2, actionid = 1 },
                new { groupid = 2, actionid = 2 },
                new { groupid = 2, actionid = 4 },
                new { groupid = 3, actionid = 1 }
            );
        }
    }
}