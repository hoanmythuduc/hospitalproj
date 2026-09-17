using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class dbchangeinEM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "asNeededTask",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dailyTask",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "monthlyTask",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "quarterlyTask",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "weeklyTask",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 3,
                column: "userName",
                value: "admin02");

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 6,
                column: "userName",
                value: "Nguyễn Văn An");

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 8,
                column: "userName",
                value: "admin02");

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 9,
                column: "userName",
                value: "Nguyễn Văn An");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "asNeededTask", "dailyTask", "monthlyTask", "quarterlyTask", "weeklyTask" },
                values: new object[] { "Thay thế linh kiện", "Kiểm tra hoạt động máy", "Tra dầu rotor", "Bảo trì động cơ", "Vệ sinh buồng ly tâm" });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "asNeededTask", "dailyTask", "monthlyTask", "quarterlyTask", "weeklyTask" },
                values: new object[] { "Thay pin/vòng bít", "Kiểm tra pin và nguồn", "Kiểm tra vòng bít", "Đo kiểm định kỳ", "Vệ sinh màn hình" });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "asNeededTask", "dailyTask", "monthlyTask", "quarterlyTask", "weeklyTask" },
                values: new object[] { "Thay hạt zeolite", "Kiểm tra lưu lượng oxy", "Thay bộ lọc thô", "Bảo trì động cơ nén", "Vệ sinh bình làm ẩm" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "asNeededTask",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "dailyTask",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "monthlyTask",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "quarterlyTask",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "weeklyTask",
                table: "ProductCategories");

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 3,
                column: "userName",
                value: "dieuduong01");

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 6,
                column: "userName",
                value: "ktv01");

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 8,
                column: "userName",
                value: "dieuduong01");

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 9,
                column: "userName",
                value: "ktv01");
        }
    }
}
