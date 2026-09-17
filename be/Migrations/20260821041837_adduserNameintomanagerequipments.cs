using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class adduserNameintomanagerequipments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "EquipmentManagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 1,
                column: "userName",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "EquipmentManagers",
                keyColumn: "id",
                keyValue: 2,
                column: "userName",
                value: "bacsi01");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userName",
                table: "EquipmentManagers");
        }
    }
}
