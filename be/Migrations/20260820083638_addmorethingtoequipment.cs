using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class addmorethingtoequipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentMaintenances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    maintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isIncident = table.Column<bool>(type: "bit", nullable: false),
                    isEngineerArrived = table.Column<bool>(type: "bit", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    labSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    engineerSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMaintenances", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenances_Equipments_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentManagers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    fromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentManagers", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentManagers_Equipments_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentManagers_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EquipmentMaintenances",
                columns: new[] { "id", "actionType", "content", "createdAt", "createdBy", "engineerSignature", "equipmentId", "isActive", "isCompleted", "isEngineerArrived", "isIncident", "labSignature", "maintenanceDate", "purpose", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, "Bảo trì", "Vệ sinh buồng ly tâm, kiểm tra rotor", new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nguyễn Văn A", 1, true, true, true, false, "Đã ký", new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bảo trì định kỳ 6 tháng", new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "Sửa chữa", "Thay thế bo mạch nguồn", new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trần Văn B", 1, true, true, true, true, "Đã ký", new DateTime(2026, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khắc phục lỗi không lên nguồn", new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "EquipmentManagers",
                columns: new[] { "id", "createdAt", "createdBy", "equipmentId", "fromDate", "isActive", "updatedAt", "updatedBy", "userId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenances_equipmentId",
                table: "EquipmentMaintenances",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentManagers_equipmentId",
                table: "EquipmentManagers",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentManagers_userId",
                table: "EquipmentManagers",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentMaintenances");

            migrationBuilder.DropTable(
                name: "EquipmentManagers");
        }
    }
}
