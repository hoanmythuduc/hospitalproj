using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class addisactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "ProductCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "FormFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Actions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 3,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 2,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 3,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 4,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 5,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "isActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "FormFields");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Actions");
        }
    }
}
