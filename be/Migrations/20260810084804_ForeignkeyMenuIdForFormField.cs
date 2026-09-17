using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class ForeignkeyMenuIdForFormField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormFields_Menus_menuId",
                table: "FormFields");

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
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7135), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7136), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7138), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7139), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7142), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7143), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7145), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7145) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7146), new DateTime(2026, 8, 10, 8, 48, 3, 896, DateTimeKind.Utc).AddTicks(7146) });

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

            migrationBuilder.AddForeignKey(
                name: "FK_FormFields_Menus_menuId",
                table: "FormFields",
                column: "menuId",
                principalTable: "Menus",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormFields_Menus_menuId",
                table: "FormFields");

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3138), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3139) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3143), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3143) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3145), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3147), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3147) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3148), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3151), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3153), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3153) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3154), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3154) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3155), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3232), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3232) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3238), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3238) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3109), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3109) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3112), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3112) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3114), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3114) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3178), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3179) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3184), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3184) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3186), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3186) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3188), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3188) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3189), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3189) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3191), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3191) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3192), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3193) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3194), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3196), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3196) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3197), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3198) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3199), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3199) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3201), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3201) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3202), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3203) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3204), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3204) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(2984), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(2992), new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(2992) });

            migrationBuilder.AddForeignKey(
                name: "FK_FormFields_Menus_menuId",
                table: "FormFields",
                column: "menuId",
                principalTable: "Menus",
                principalColumn: "id");
        }
    }
}
