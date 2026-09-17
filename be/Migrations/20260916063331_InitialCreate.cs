using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Menus_menuId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMasters_CustomerCategories_categoryId",
                table: "CustomerMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_EquipmentMaintenances_relatedMaintenanceId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Equipments_equipmentId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_executorId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_inspectorId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_reviewerId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenances_Equipments_equipmentId",
                table: "EquipmentMaintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceSchedules_Equipments_equipmentId",
                table: "EquipmentMaintenanceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceSchedules_Users_approverId",
                table: "EquipmentMaintenanceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceSchedules_Users_preparerId",
                table: "EquipmentMaintenanceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentManagers_Equipments_equipmentId",
                table: "EquipmentManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentManagers_Users_userId",
                table: "EquipmentManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_ProductCategories_productCategoryId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_FormFields_Menus_menuId",
                table: "FormFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Action_Actions_actionid",
                table: "Group_Action");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Action_Groups_groupid",
                table: "Group_Action");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Menu_Groups_groupid",
                table: "Group_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Menu_Menus_menuid",
                table: "Group_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_parentId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerMasters_customerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_CustomerMasters_supplierId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_Groups_groupid",
                table: "User_Group");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_Users_userid",
                table: "User_Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormFields",
                table: "FormFields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentManagers",
                table: "EquipmentManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentMaintenanceSchedules",
                table: "EquipmentMaintenanceSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentMaintenances",
                table: "EquipmentMaintenances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentMaintenanceLogs",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerMasters",
                table: "CustomerMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCategories",
                table: "CustomerCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actions",
                table: "Actions");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "FormFields",
                newName: "FormField");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "Equipment");

            migrationBuilder.RenameTable(
                name: "EquipmentManagers",
                newName: "EquipmentManager");

            migrationBuilder.RenameTable(
                name: "EquipmentMaintenanceSchedules",
                newName: "EquipmentMaintenanceSchedule");

            migrationBuilder.RenameTable(
                name: "EquipmentMaintenances",
                newName: "EquipmentMaintenance");

            migrationBuilder.RenameTable(
                name: "EquipmentMaintenanceLogs",
                newName: "EquipmentMaintenanceLog");

            migrationBuilder.RenameTable(
                name: "CustomerMasters",
                newName: "CustomerMaster");

            migrationBuilder.RenameTable(
                name: "CustomerCategories",
                newName: "CustomerCategory");

            migrationBuilder.RenameTable(
                name: "Actions",
                newName: "Action");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userCode",
                table: "User",
                newName: "IX_User_userCode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_supplierId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_supplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_customerId",
                table: "Order",
                newName: "IX_Order_customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_parentId",
                table: "Menu",
                newName: "IX_Menu_parentId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_name",
                table: "Group",
                newName: "IX_Group_name");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_code",
                table: "Group",
                newName: "IX_Group_code");

            migrationBuilder.RenameIndex(
                name: "IX_FormFields_menuId",
                table: "FormField",
                newName: "IX_FormField_menuId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_productCategoryId",
                table: "Equipment",
                newName: "IX_Equipment_productCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentManagers_userId",
                table: "EquipmentManager",
                newName: "IX_EquipmentManager_userId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentManagers_equipmentId",
                table: "EquipmentManager",
                newName: "IX_EquipmentManager_equipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceSchedules_preparerId",
                table: "EquipmentMaintenanceSchedule",
                newName: "IX_EquipmentMaintenanceSchedule_preparerId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceSchedules_equipmentId",
                table: "EquipmentMaintenanceSchedule",
                newName: "IX_EquipmentMaintenanceSchedule_equipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceSchedules_approverId",
                table: "EquipmentMaintenanceSchedule",
                newName: "IX_EquipmentMaintenanceSchedule_approverId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenances_equipmentId",
                table: "EquipmentMaintenance",
                newName: "IX_EquipmentMaintenance_equipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLogs_reviewerId",
                table: "EquipmentMaintenanceLog",
                newName: "IX_EquipmentMaintenanceLog_reviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLogs_relatedMaintenanceId",
                table: "EquipmentMaintenanceLog",
                newName: "IX_EquipmentMaintenanceLog_relatedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLogs_inspectorId",
                table: "EquipmentMaintenanceLog",
                newName: "IX_EquipmentMaintenanceLog_inspectorId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLogs_executorId",
                table: "EquipmentMaintenanceLog",
                newName: "IX_EquipmentMaintenanceLog_executorId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLogs_equipmentId",
                table: "EquipmentMaintenanceLog",
                newName: "IX_EquipmentMaintenanceLog_equipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerMasters_categoryId",
                table: "CustomerMaster",
                newName: "IX_CustomerMaster_categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_menuId",
                table: "Action",
                newName: "IX_Action_menuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormField",
                table: "FormField",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentManager",
                table: "EquipmentManager",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentMaintenanceSchedule",
                table: "EquipmentMaintenanceSchedule",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentMaintenance",
                table: "EquipmentMaintenance",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentMaintenanceLog",
                table: "EquipmentMaintenanceLog",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerMaster",
                table: "CustomerMaster",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCategory",
                table: "CustomerCategory",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Action",
                table: "Action",
                column: "id");

            migrationBuilder.CreateTable(
                name: "EquipmentUsageLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    weekOfMonth = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    preparerId = table.Column<int>(type: "int", nullable: true),
                    inspectorId = table.Column<int>(type: "int", nullable: true),
                    inspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reviewerId = table.Column<int>(type: "int", nullable: true),
                    reviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUsageLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageLog_Equipment_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageLog_User_inspectorId",
                        column: x => x.inspectorId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageLog_User_preparerId",
                        column: x => x.preparerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageLog_User_reviewerId",
                        column: x => x.reviewerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WaterSystemLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    allowedRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trackingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    preparerId = table.Column<int>(type: "int", nullable: true),
                    inspectorId = table.Column<int>(type: "int", nullable: true),
                    inspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reviewerId = table.Column<int>(type: "int", nullable: true),
                    reviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterSystemLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_WaterSystemLog_Equipment_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaterSystemLog_User_inspectorId",
                        column: x => x.inspectorId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaterSystemLog_User_preparerId",
                        column: x => x.preparerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaterSystemLog_User_reviewerId",
                        column: x => x.reviewerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentUsageDailyLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usageLogId = table.Column<int>(type: "int", nullable: false),
                    logDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dayOfWeek = table.Column<int>(type: "int", nullable: false),
                    shift1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usageCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maintenanceCallTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dailyDecon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preMaintenanceDecon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isNormal = table.Column<bool>(type: "bit", nullable: true),
                    qcResult = table.Column<bool>(type: "bit", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUsageDailyLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageDailyLog_EquipmentUsageLog_usageLogId",
                        column: x => x.usageLogId,
                        principalTable: "EquipmentUsageLog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterSystemDailyLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    waterSystemLogId = table.Column<int>(type: "int", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    usValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trackerId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterSystemDailyLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_WaterSystemDailyLog_User_trackerId",
                        column: x => x.trackerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaterSystemDailyLog_WaterSystemLog_waterSystemLogId",
                        column: x => x.waterSystemLogId,
                        principalTable: "WaterSystemLog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EquipmentUsageLog",
                columns: new[] { "id", "createdAt", "createdBy", "equipmentId", "inspectionDate", "inspectorId", "isActive", "month", "preparerId", "reviewDate", "reviewerId", "status", "updatedAt", "updatedBy", "weekOfMonth", "year" },
                values: new object[] { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, true, 8, 2, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2026 });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "id", "asNeededTask", "conditionWhenReceived", "conditionWhenStarted", "countryOfOrigin", "createdAt", "createdBy", "dailyTask", "equipmentCode", "equipmentName", "isActive", "location", "manufacturer", "model", "monthlyTask", "quarterlyTask", "receivedDate", "serialNumber", "startDateOfUse", "supplierId", "updatedAt", "updatedBy", "weeklyTask" },
                values: new object[] { 4, "Thay thế lõi lọc/màng RO", "Mới 100%", "Hoạt động tốt", "Việt Nam", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiểm tra độ dẫn điện <1,0 µS/cm", "KXN-RO-01", "Hệ thống lọc nước RO", true, "Sinh hóa - Huyết học - Miễn dịch", "AquaCare", "RO-LAB-500", "Rửa màng lọc", "Bảo trì hệ thống van", new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SN-RO-2026", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vệ sinh buồng lọc" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "createdAt", "createdBy", "isActive", "productCategoryId", "updatedAt", "updatedBy" },
                values: new object[] { 4, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 4, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "EquipmentUsageDailyLog",
                columns: new[] { "id", "createdAt", "createdBy", "dailyDecon", "dayOfWeek", "isActive", "isNormal", "logDate", "maintenanceCallTime", "preMaintenanceDecon", "qcResult", "shift1", "shift2", "shift3", "shift4", "shift5", "updatedAt", "updatedBy", "usageCount", "usageLogId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 2, true, true, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 2, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 3, true, true, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 3, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 4, true, false, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "15:00", "TranThiDieu", false, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 4, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 5, true, true, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 5, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 6, true, true, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 7, true, true, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "Nguyễn Văn An", "", "Lê Trọng Đại", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 7, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 8, true, true, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "Nguyễn Văn An", "", "Lê Trọng Đại", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 }
                });

            migrationBuilder.InsertData(
                table: "WaterSystemLog",
                columns: new[] { "id", "allowedRange", "createdAt", "createdBy", "equipmentId", "inspectionDate", "inspectorId", "isActive", "month", "preparerId", "reviewDate", "reviewerId", "status", "trackingTime", "updatedAt", "updatedBy", "year" },
                values: new object[] { 1, "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 8, 2, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2026 });

            migrationBuilder.InsertData(
                table: "WaterSystemDailyLog",
                columns: new[] { "id", "createdAt", "createdBy", "day", "isActive", "trackerId", "updatedAt", "updatedBy", "usValue", "waterSystemLogId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, 2, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 2, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, 2, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 3, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, true, 2, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 4, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, true, 2, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 5, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, true, 2, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 6, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, true, 2, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 7, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, true, 2, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 8, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, true, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 9, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, true, 2, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 10, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, true, 2, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 11, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, true, 2, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 12, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, true, 2, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 13, new DateTime(2026, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, true, 2, new DateTime(2026, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 14, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, true, 2, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 15, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, true, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 16, new DateTime(2026, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 16, true, 2, new DateTime(2026, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 17, new DateTime(2026, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 17, true, 2, new DateTime(2026, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 18, new DateTime(2026, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 18, true, 2, new DateTime(2026, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 19, new DateTime(2026, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 19, true, 2, new DateTime(2026, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 20, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20, true, 2, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 21, new DateTime(2026, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 21, true, 2, new DateTime(2026, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 22, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 22, true, 2, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 23, new DateTime(2026, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 23, true, 2, new DateTime(2026, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 24, new DateTime(2026, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 24, true, 2, new DateTime(2026, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 25, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 25, true, 2, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 26, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 26, true, 2, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 27, new DateTime(2026, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 27, true, 2, new DateTime(2026, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 28, new DateTime(2026, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 28, true, 2, new DateTime(2026, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 29, new DateTime(2026, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 29, true, 2, new DateTime(2026, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 30, new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, true, 2, new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 31, new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 31, true, 2, new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageDailyLog_usageLogId",
                table: "EquipmentUsageDailyLog",
                column: "usageLogId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageLog_equipmentId",
                table: "EquipmentUsageLog",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageLog_inspectorId",
                table: "EquipmentUsageLog",
                column: "inspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageLog_preparerId",
                table: "EquipmentUsageLog",
                column: "preparerId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageLog_reviewerId",
                table: "EquipmentUsageLog",
                column: "reviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemDailyLog_trackerId",
                table: "WaterSystemDailyLog",
                column: "trackerId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemDailyLog_waterSystemLogId",
                table: "WaterSystemDailyLog",
                column: "waterSystemLogId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemLog_equipmentId",
                table: "WaterSystemLog",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemLog_inspectorId",
                table: "WaterSystemLog",
                column: "inspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemLog_preparerId",
                table: "WaterSystemLog",
                column: "preparerId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemLog_reviewerId",
                table: "WaterSystemLog",
                column: "reviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Menu_menuId",
                table: "Action",
                column: "menuId",
                principalTable: "Menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMaster_CustomerCategory_categoryId",
                table: "CustomerMaster",
                column: "categoryId",
                principalTable: "CustomerCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_ProductCategory_productCategoryId",
                table: "Equipment",
                column: "productCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenance_Equipment_equipmentId",
                table: "EquipmentMaintenance",
                column: "equipmentId",
                principalTable: "Equipment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLog_EquipmentMaintenance_relatedMaintenanceId",
                table: "EquipmentMaintenanceLog",
                column: "relatedMaintenanceId",
                principalTable: "EquipmentMaintenance",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLog_Equipment_equipmentId",
                table: "EquipmentMaintenanceLog",
                column: "equipmentId",
                principalTable: "Equipment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLog_User_executorId",
                table: "EquipmentMaintenanceLog",
                column: "executorId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLog_User_inspectorId",
                table: "EquipmentMaintenanceLog",
                column: "inspectorId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLog_User_reviewerId",
                table: "EquipmentMaintenanceLog",
                column: "reviewerId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceSchedule_Equipment_equipmentId",
                table: "EquipmentMaintenanceSchedule",
                column: "equipmentId",
                principalTable: "Equipment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceSchedule_User_approverId",
                table: "EquipmentMaintenanceSchedule",
                column: "approverId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceSchedule_User_preparerId",
                table: "EquipmentMaintenanceSchedule",
                column: "preparerId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentManager_Equipment_equipmentId",
                table: "EquipmentManager",
                column: "equipmentId",
                principalTable: "Equipment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentManager_User_userId",
                table: "EquipmentManager",
                column: "userId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormField_Menu_menuId",
                table: "FormField",
                column: "menuId",
                principalTable: "Menu",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Action_Action_actionid",
                table: "Group_Action",
                column: "actionid",
                principalTable: "Action",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Action_Group_groupid",
                table: "Group_Action",
                column: "groupid",
                principalTable: "Group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Menu_Group_groupid",
                table: "Group_Menu",
                column: "groupid",
                principalTable: "Group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Menu_Menu_menuid",
                table: "Group_Menu",
                column: "menuid",
                principalTable: "Menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Menu_parentId",
                table: "Menu",
                column: "parentId",
                principalTable: "Menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_CustomerMaster_customerId",
                table: "Order",
                column: "customerId",
                principalTable: "CustomerMaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_CustomerMaster_supplierId",
                table: "ProductCategory",
                column: "supplierId",
                principalTable: "CustomerMaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_Group_groupid",
                table: "User_Group",
                column: "groupid",
                principalTable: "Group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_User_userid",
                table: "User_Group",
                column: "userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Action_Menu_menuId",
                table: "Action");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMaster_CustomerCategory_categoryId",
                table: "CustomerMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_ProductCategory_productCategoryId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenance_Equipment_equipmentId",
                table: "EquipmentMaintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLog_EquipmentMaintenance_relatedMaintenanceId",
                table: "EquipmentMaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLog_Equipment_equipmentId",
                table: "EquipmentMaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLog_User_executorId",
                table: "EquipmentMaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLog_User_inspectorId",
                table: "EquipmentMaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLog_User_reviewerId",
                table: "EquipmentMaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceSchedule_Equipment_equipmentId",
                table: "EquipmentMaintenanceSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceSchedule_User_approverId",
                table: "EquipmentMaintenanceSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceSchedule_User_preparerId",
                table: "EquipmentMaintenanceSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentManager_Equipment_equipmentId",
                table: "EquipmentManager");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentManager_User_userId",
                table: "EquipmentManager");

            migrationBuilder.DropForeignKey(
                name: "FK_FormField_Menu_menuId",
                table: "FormField");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Action_Action_actionid",
                table: "Group_Action");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Action_Group_groupid",
                table: "Group_Action");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Menu_Group_groupid",
                table: "Group_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Menu_Menu_menuid",
                table: "Group_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Menu_parentId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_CustomerMaster_customerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_CustomerMaster_supplierId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_Group_groupid",
                table: "User_Group");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_User_userid",
                table: "User_Group");

            migrationBuilder.DropTable(
                name: "EquipmentUsageDailyLog");

            migrationBuilder.DropTable(
                name: "WaterSystemDailyLog");

            migrationBuilder.DropTable(
                name: "EquipmentUsageLog");

            migrationBuilder.DropTable(
                name: "WaterSystemLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormField",
                table: "FormField");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentManager",
                table: "EquipmentManager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentMaintenanceSchedule",
                table: "EquipmentMaintenanceSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentMaintenanceLog",
                table: "EquipmentMaintenanceLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentMaintenance",
                table: "EquipmentMaintenance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerMaster",
                table: "CustomerMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCategory",
                table: "CustomerCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Action",
                table: "Action");

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "FormField",
                newName: "FormFields");

            migrationBuilder.RenameTable(
                name: "EquipmentManager",
                newName: "EquipmentManagers");

            migrationBuilder.RenameTable(
                name: "EquipmentMaintenanceSchedule",
                newName: "EquipmentMaintenanceSchedules");

            migrationBuilder.RenameTable(
                name: "EquipmentMaintenanceLog",
                newName: "EquipmentMaintenanceLogs");

            migrationBuilder.RenameTable(
                name: "EquipmentMaintenance",
                newName: "EquipmentMaintenances");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipments");

            migrationBuilder.RenameTable(
                name: "CustomerMaster",
                newName: "CustomerMasters");

            migrationBuilder.RenameTable(
                name: "CustomerCategory",
                newName: "CustomerCategories");

            migrationBuilder.RenameTable(
                name: "Action",
                newName: "Actions");

            migrationBuilder.RenameIndex(
                name: "IX_User_userCode",
                table: "Users",
                newName: "IX_Users_userCode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_supplierId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_supplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_customerId",
                table: "Orders",
                newName: "IX_Orders_customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_parentId",
                table: "Menus",
                newName: "IX_Menus_parentId");

            migrationBuilder.RenameIndex(
                name: "IX_Group_name",
                table: "Groups",
                newName: "IX_Groups_name");

            migrationBuilder.RenameIndex(
                name: "IX_Group_code",
                table: "Groups",
                newName: "IX_Groups_code");

            migrationBuilder.RenameIndex(
                name: "IX_FormField_menuId",
                table: "FormFields",
                newName: "IX_FormFields_menuId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentManager_userId",
                table: "EquipmentManagers",
                newName: "IX_EquipmentManagers_userId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentManager_equipmentId",
                table: "EquipmentManagers",
                newName: "IX_EquipmentManagers_equipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceSchedule_preparerId",
                table: "EquipmentMaintenanceSchedules",
                newName: "IX_EquipmentMaintenanceSchedules_preparerId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceSchedule_equipmentId",
                table: "EquipmentMaintenanceSchedules",
                newName: "IX_EquipmentMaintenanceSchedules_equipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceSchedule_approverId",
                table: "EquipmentMaintenanceSchedules",
                newName: "IX_EquipmentMaintenanceSchedules_approverId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLog_reviewerId",
                table: "EquipmentMaintenanceLogs",
                newName: "IX_EquipmentMaintenanceLogs_reviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLog_relatedMaintenanceId",
                table: "EquipmentMaintenanceLogs",
                newName: "IX_EquipmentMaintenanceLogs_relatedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLog_inspectorId",
                table: "EquipmentMaintenanceLogs",
                newName: "IX_EquipmentMaintenanceLogs_inspectorId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLog_executorId",
                table: "EquipmentMaintenanceLogs",
                newName: "IX_EquipmentMaintenanceLogs_executorId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenanceLog_equipmentId",
                table: "EquipmentMaintenanceLogs",
                newName: "IX_EquipmentMaintenanceLogs_equipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentMaintenance_equipmentId",
                table: "EquipmentMaintenances",
                newName: "IX_EquipmentMaintenances_equipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_productCategoryId",
                table: "Equipments",
                newName: "IX_Equipments_productCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerMaster_categoryId",
                table: "CustomerMasters",
                newName: "IX_CustomerMasters_categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Action_menuId",
                table: "Actions",
                newName: "IX_Actions_menuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormFields",
                table: "FormFields",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentManagers",
                table: "EquipmentManagers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentMaintenanceSchedules",
                table: "EquipmentMaintenanceSchedules",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentMaintenanceLogs",
                table: "EquipmentMaintenanceLogs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentMaintenances",
                table: "EquipmentMaintenances",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerMasters",
                table: "CustomerMasters",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCategories",
                table: "CustomerCategories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actions",
                table: "Actions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Menus_menuId",
                table: "Actions",
                column: "menuId",
                principalTable: "Menus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMasters_CustomerCategories_categoryId",
                table: "CustomerMasters",
                column: "categoryId",
                principalTable: "CustomerCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLogs_EquipmentMaintenances_relatedMaintenanceId",
                table: "EquipmentMaintenanceLogs",
                column: "relatedMaintenanceId",
                principalTable: "EquipmentMaintenances",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Equipments_equipmentId",
                table: "EquipmentMaintenanceLogs",
                column: "equipmentId",
                principalTable: "Equipments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_executorId",
                table: "EquipmentMaintenanceLogs",
                column: "executorId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_inspectorId",
                table: "EquipmentMaintenanceLogs",
                column: "inspectorId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_reviewerId",
                table: "EquipmentMaintenanceLogs",
                column: "reviewerId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenances_Equipments_equipmentId",
                table: "EquipmentMaintenances",
                column: "equipmentId",
                principalTable: "Equipments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceSchedules_Equipments_equipmentId",
                table: "EquipmentMaintenanceSchedules",
                column: "equipmentId",
                principalTable: "Equipments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceSchedules_Users_approverId",
                table: "EquipmentMaintenanceSchedules",
                column: "approverId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceSchedules_Users_preparerId",
                table: "EquipmentMaintenanceSchedules",
                column: "preparerId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentManagers_Equipments_equipmentId",
                table: "EquipmentManagers",
                column: "equipmentId",
                principalTable: "Equipments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentManagers_Users_userId",
                table: "EquipmentManagers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_ProductCategories_productCategoryId",
                table: "Equipments",
                column: "productCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormFields_Menus_menuId",
                table: "FormFields",
                column: "menuId",
                principalTable: "Menus",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Action_Actions_actionid",
                table: "Group_Action",
                column: "actionid",
                principalTable: "Actions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Action_Groups_groupid",
                table: "Group_Action",
                column: "groupid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Menu_Groups_groupid",
                table: "Group_Menu",
                column: "groupid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Menu_Menus_menuid",
                table: "Group_Menu",
                column: "menuid",
                principalTable: "Menus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_parentId",
                table: "Menus",
                column: "parentId",
                principalTable: "Menus",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerMasters_customerId",
                table: "Orders",
                column: "customerId",
                principalTable: "CustomerMasters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_CustomerMasters_supplierId",
                table: "ProductCategories",
                column: "supplierId",
                principalTable: "CustomerMasters",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_Groups_groupid",
                table: "User_Group",
                column: "groupid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_Users_userid",
                table: "User_Group",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
