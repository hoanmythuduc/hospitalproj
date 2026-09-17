using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class updateappaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "VIEW", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3138), "View", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3139) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "DETAIL", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3143), "Detail", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3143) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "CREATE", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3145), "Create", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "EDIT", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3147), "Update", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3147) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "DELETE", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3148), "Delete", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "VIEW", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3150), "View", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "CREATE", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3151), "Create", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "EDIT", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3153), "Update", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3153) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "DELETE", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3154), "Delete", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3154) });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "id", "code", "createdAt", "endpoint", "label", "menuId", "method", "updatedAt" },
                values: new object[] { 10, "DETAIL", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3155), "/api/groups/{id}", "Detail", 7, "GET", new DateTime(2026, 8, 7, 7, 32, 35, 88, DateTimeKind.Utc).AddTicks(3156) });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "USER_VIEW_LIST", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7378), "Danh sách ", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7378) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "USER_VIEW_DETAIL", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7381), "Chi tiết ", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7381) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "USER_ADD", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7383), "Thêm mới ", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7383) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "USER_EDIT", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7384), "Cập nhật ", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "USER_DEL", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7386), "Xóa ", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7386) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "GROUP_VIEW_LIST", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7387), "Danh sách nhóm", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "GROUP_ADD", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7388), "Thêm nhóm", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "GROUP_EDIT", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7390), "Sửa nhóm", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "code", "createdAt", "label", "updatedAt" },
                values: new object[] { "GROUP_DEL", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7391), "Xóa nhóm", new DateTime(2026, 8, 7, 1, 51, 28, 787, DateTimeKind.Utc).AddTicks(7391) });

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
    }
}
