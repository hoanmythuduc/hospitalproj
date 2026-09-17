using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class maintenanceschedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_executorId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_inspectorId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_reviewerId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.CreateTable(
                name: "EquipmentMaintenanceSchedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    task = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    m1 = table.Column<bool>(type: "bit", nullable: false),
                    m2 = table.Column<bool>(type: "bit", nullable: false),
                    m3 = table.Column<bool>(type: "bit", nullable: false),
                    m4 = table.Column<bool>(type: "bit", nullable: false),
                    m5 = table.Column<bool>(type: "bit", nullable: false),
                    m6 = table.Column<bool>(type: "bit", nullable: false),
                    m7 = table.Column<bool>(type: "bit", nullable: false),
                    m8 = table.Column<bool>(type: "bit", nullable: false),
                    m9 = table.Column<bool>(type: "bit", nullable: false),
                    m10 = table.Column<bool>(type: "bit", nullable: false),
                    m11 = table.Column<bool>(type: "bit", nullable: false),
                    m12 = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    preparerId = table.Column<int>(type: "int", nullable: true),
                    approverId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMaintenanceSchedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceSchedules_Equipments_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceSchedules_Users_approverId",
                        column: x => x.approverId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceSchedules_Users_preparerId",
                        column: x => x.preparerId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EquipmentMaintenanceSchedules",
                columns: new[] { "id", "approverId", "createdAt", "createdBy", "equipmentId", "isActive", "m1", "m10", "m11", "m12", "m2", "m3", "m4", "m5", "m6", "m7", "m8", "m9", "note", "preparerId", "status", "task", "updatedAt", "updatedBy", "year" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, false, false, false, true, false, true, false, false, true, false, false, true, "Yêu cầu kỹ sư hãng", 2, 2, "Bảo dưỡng hệ thống quay và tra dầu", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2026 },
                    { 2, 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, false, false, true, false, false, false, false, true, false, false, false, "Đo đối chiếu máy thủy ngân", 2, 2, "Hiệu chuẩn cảm biến áp suất", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2026 },
                    { 3, 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, true, true, true, true, true, true, true, true, true, true, true, true, true, "Ưu tiên làm đầu tháng", 2, 2, "Thay bộ lọc và kiểm tra lưu lượng", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2026 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "id", "createdAt", "createdBy", "icon", "isActive", "label", "parentId", "to", "updatedAt", "updatedBy" },
                values: new object[] { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "calendar", true, "Maintenance Plan", 4, "/transactions/maintenance-plan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceSchedules_approverId",
                table: "EquipmentMaintenanceSchedules",
                column: "approverId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceSchedules_equipmentId",
                table: "EquipmentMaintenanceSchedules",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceSchedules_preparerId",
                table: "EquipmentMaintenanceSchedules",
                column: "preparerId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_executorId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_inspectorId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_reviewerId",
                table: "EquipmentMaintenanceLogs");

            migrationBuilder.DropTable(
                name: "EquipmentMaintenanceSchedules");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_executorId",
                table: "EquipmentMaintenanceLogs",
                column: "executorId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_inspectorId",
                table: "EquipmentMaintenanceLogs",
                column: "inspectorId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaintenanceLogs_Users_reviewerId",
                table: "EquipmentMaintenanceLogs",
                column: "reviewerId",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
