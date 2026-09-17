using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class seedprocat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9354), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9354) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9356), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9357), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9357) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9358), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9359) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9361), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9362) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9363), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9425), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9426) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9431) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9309), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9309) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9311), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9312), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9312) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9381), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9384), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9384) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9386), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9388), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9388) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9389), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9389) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9391), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9391) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9392), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9392) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9394), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9394) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9395), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9395) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9397), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9397) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9399), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9399) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9400), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9401) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9402), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9402) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9403), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9404) });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "id", "categoryCode", "categoryName", "description" },
                values: new object[,]
                {
                    { 1, "MED_EQUIP", "Dụng cụ y tế", "Các thiết bị và máy móc dùng trong khám chữa bệnh" },
                    { 2, "PHARMA", "Thuốc tân dược", "Các loại thuốc kháng sinh, thuốc đặc trị và thực phẩm chức năng" },
                    { 3, "SUPPLIES", "Vật tư tiêu hao", "Bơm kim tiêm, bông băng, găng tay y tế, khẩu trang" },
                    { 4, "CHEMICALS", "Hóa chất xét nghiệm", "Hóa chất và dung dịch dùng trong phòng thí nghiệm" },
                    { 5, "UNIFORMS", "Trang phục y tế", "Đồng phục bác sĩ, điều dưỡng, bệnh nhân và đồ bảo hộ" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9188), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9195), new DateTime(2026, 8, 11, 3, 42, 48, 897, DateTimeKind.Utc).AddTicks(9195) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8259), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8265), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8266), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8268), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8268) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8300), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8300) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8303), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8304), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8306), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8372) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8377), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8377) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8235), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8235) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8238), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8240), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8240) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8326), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8327) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8330), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8332), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8332) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8333), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8333) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8335), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8336), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8337) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8338), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8340), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8340) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8341), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8341) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8343), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8345), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8345) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8346), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8348), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8348) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8349), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8096), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8098) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8103), new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8103) });
        }
    }
}
