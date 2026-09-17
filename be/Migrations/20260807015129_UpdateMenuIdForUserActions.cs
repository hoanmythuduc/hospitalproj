using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuIdForUserActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7378), 6, new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7378) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7381), 6, new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7381) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7383), 6, new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7383) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7384), 6, new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7386), 6, new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7386) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7387), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7388), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7390), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7391), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7391) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7457), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7457) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7461), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7461) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7317), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7318) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7319), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7319) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7357), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7411), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7414), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7414) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7415), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7417), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7417) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7418), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7419), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7421), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7422), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7423) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7424), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7424) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7425), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7427), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7428), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7431), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7431) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7228), new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7228) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5776), 2, new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5776) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5779), 2, new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5780) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5781), 2, new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5781) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5783), 2, new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5783) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "menuId", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5784), 2, new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5785), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5787), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5787) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5788), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5789), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5855), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5855) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5860), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5860) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5754), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5755) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5756), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5756) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5758), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5758) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5809), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5813), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5813) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5815), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5815) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5816), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5817) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5818), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5818) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5819), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5821), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5821) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5822), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5822) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5824), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5824) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5825), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5825) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5827), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5827) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5828), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5828) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5829), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5830) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5831), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5831) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5665), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5669) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5674), new DateTime(2026, 8, 6, 6, 36, 48, 199, DateTimeKind.Utc).AddTicks(5675) });
        }
    }
}
