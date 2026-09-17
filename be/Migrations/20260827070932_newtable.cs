using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class newtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentMaintenanceLogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    logDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDaily = table.Column<bool>(type: "bit", nullable: false),
                    isWeekly = table.Column<bool>(type: "bit", nullable: false),
                    isMonthly = table.Column<bool>(type: "bit", nullable: false),
                    isQuarterly = table.Column<bool>(type: "bit", nullable: false),
                    isAsNeeded = table.Column<bool>(type: "bit", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    executorId = table.Column<int>(type: "int", nullable: false),
                    inspectorId = table.Column<int>(type: "int", nullable: true),
                    inspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reviewerId = table.Column<int>(type: "int", nullable: true),
                    reviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    relatedMaintenanceId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMaintenanceLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLogs_EquipmentMaintenances_relatedMaintenanceId",
                        column: x => x.relatedMaintenanceId,
                        principalTable: "EquipmentMaintenances",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLogs_Equipments_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLogs_Users_executorId",
                        column: x => x.executorId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLogs_Users_inspectorId",
                        column: x => x.inspectorId,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLogs_Users_reviewerId",
                        column: x => x.reviewerId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "EquipmentMaintenanceLogs",
                columns: new[] { "id", "createdAt", "createdBy", "equipmentId", "executorId", "inspectionDate", "inspectorId", "isActive", "isAsNeeded", "isDaily", "isMonthly", "isQuarterly", "isWeekly", "logDate", "note", "relatedMaintenanceId", "reviewDate", "reviewerId", "status", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Máy hoạt động bình thường", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vệ sinh buồng mẫu", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chạy mẫu test OK", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, true, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bảo dưỡng cuối tuần, xả sương", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, true, true, false, false, false, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lỗi bo mạch, đã gọi kỹ sư", 2, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Máy đã sửa xong, chạy ổn", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, new DateTime(2026, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, true, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bảo dưỡng cuối tuần", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, null, null, true, false, true, false, false, false, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khởi động đầu ca tốt", null, null, null, 1, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLogs_equipmentId",
                table: "EquipmentMaintenanceLogs",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLogs_executorId",
                table: "EquipmentMaintenanceLogs",
                column: "executorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLogs_inspectorId",
                table: "EquipmentMaintenanceLogs",
                column: "inspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLogs_relatedMaintenanceId",
                table: "EquipmentMaintenanceLogs",
                column: "relatedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLogs_reviewerId",
                table: "EquipmentMaintenanceLogs",
                column: "reviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentMaintenanceLogs");
        }
    }
}
