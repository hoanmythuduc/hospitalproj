using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class cuscat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Actions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Actions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategories", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4730), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4730), null });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4735), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4735), null });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4736), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4737), null });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4738), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4738), null });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4740), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4740), null });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4741), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4741), null });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4742), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4743), null });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4744), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4744), null });

            migrationBuilder.InsertData(
                table: "CustomerCategories",
                columns: new[] { "id", "createdAt", "createdBy", "discount", "groupName", "isActive", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15.0m, "Khách hàng V.I.P", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10.0m, "Khách mua sỉ", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0m, "Khách vãng lai", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5.0m, "Khách hàng thân thiết", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20.0m, "Đối tác chiến lược", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4820), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4821), null });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4825), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4825), null });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4646), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4646), null });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4708), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4708), null });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4709), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4710), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4769), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4770), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4773), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4774), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4775), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4776), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4777), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4777), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4779), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4779), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4782), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4782), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4783), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4784), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4785), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4785), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4787), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4787), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4789), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4789), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4790), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4790), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4792), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4792), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4793), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4793), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4795), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4795), null });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4844), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4844), null });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4845), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4846), null });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4847), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4847), null });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4848), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4848), null });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4849), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4849), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4534), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4537), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4547), null, new DateTime(2026, 8, 11, 7, 14, 47, 910, DateTimeKind.Utc).AddTicks(4547), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCategories");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "FormFields");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "FormFields");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Actions");

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
    }
}
