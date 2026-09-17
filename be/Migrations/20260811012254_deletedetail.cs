using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class deletedetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 10);

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
                columns: new[] { "code", "createdAt", "endpoint", "label", "method", "updatedAt" },
                values: new object[] { "CREATE", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8265), "/api/users", "Create", "POST", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "code", "createdAt", "endpoint", "label", "method", "updatedAt" },
                values: new object[] { "EDIT", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8266), "/api/users/{id}", "Update", "PUT", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "code", "createdAt", "label", "method", "updatedAt" },
                values: new object[] { "DELETE", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8268), "Delete", "DELETE", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8268) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "code", "createdAt", "endpoint", "label", "menuId", "method", "updatedAt" },
                values: new object[] { "VIEW", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8300), "/api/groups", "View", 7, "GET", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8300) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "code", "createdAt", "label", "method", "updatedAt" },
                values: new object[] { "CREATE", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8303), "Create", "POST", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "code", "createdAt", "endpoint", "label", "method", "updatedAt" },
                values: new object[] { "EDIT", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8304), "/api/groups/{id}", "Update", "PUT", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "code", "createdAt", "label", "method", "updatedAt" },
                values: new object[] { "DELETE", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8306), "Delete", "DELETE", new DateTime(2026, 8, 11, 1, 22, 53, 950, DateTimeKind.Utc).AddTicks(8306) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7131), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "code", "createdAt", "endpoint", "label", "method", "updatedAt" },
                values: new object[] { "DETAIL", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7135), "/api/users/{id}", "Detail", "GET", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "code", "createdAt", "endpoint", "label", "method", "updatedAt" },
                values: new object[] { "CREATE", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7136), "/api/users", "Create", "POST", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "code", "createdAt", "label", "method", "updatedAt" },
                values: new object[] { "EDIT", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7138), "Update", "PUT", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "code", "createdAt", "endpoint", "label", "menuId", "method", "updatedAt" },
                values: new object[] { "DELETE", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7139), "/api/users/{id}", "Delete", 6, "DELETE", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "code", "createdAt", "label", "method", "updatedAt" },
                values: new object[] { "VIEW", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7140), "View", "GET", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "code", "createdAt", "endpoint", "label", "method", "updatedAt" },
                values: new object[] { "CREATE", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7142), "/api/groups", "Create", "POST", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "code", "createdAt", "label", "method", "updatedAt" },
                values: new object[] { "EDIT", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7143), "Update", "PUT", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7144) });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "id", "code", "createdAt", "endpoint", "label", "menuId", "method", "updatedAt" },
                values: new object[,]
                {
                    { 9, "DELETE", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7145), "/api/groups/{id}", "Delete", 7, "DELETE", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7145) },
                    { 10, "DETAIL", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7146), "/api/groups/{id}", "Detail", 7, "GET", new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7146) }
                });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7254), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7108), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7109) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7112), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7112) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7113), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7113) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7171), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7171) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7177), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7178), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7179) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7207), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7209), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7212), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7214), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7215), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7216) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7217), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7217) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7218), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7219) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7222), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7222) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(6978), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(6981) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(6986), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(6986) });
        }
    }
}
