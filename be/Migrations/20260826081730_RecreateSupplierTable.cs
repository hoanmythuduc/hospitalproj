using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class RecreateSupplierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "customerName",
                table: "CustomerMasters",
                newName: "supplierPhone");

            migrationBuilder.AddColumn<string>(
                name: "engineerInCharge",
                table: "CustomerMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "supplierAddress",
                table: "CustomerMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "supplierEmail",
                table: "CustomerMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "supplierName",
                table: "CustomerMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "engineerInCharge", "supplierAddress", "supplierEmail", "supplierName", "supplierPhone" },
                values: new object[] { "Lê Văn C", "Quận 3, TP.HCM", "support@medjin.com", "Công ty TBYT MedJin", "0988777666" });

            migrationBuilder.UpdateData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "engineerInCharge", "supplierAddress", "supplierEmail", "supplierName", "supplierPhone" },
                values: new object[] { "Nguyễn Văn A", "Quận 1, TP.HCM", "contact@abc.com", "Công ty TBYT ABC", "0909123456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "engineerInCharge",
                table: "CustomerMasters");

            migrationBuilder.DropColumn(
                name: "supplierAddress",
                table: "CustomerMasters");

            migrationBuilder.DropColumn(
                name: "supplierEmail",
                table: "CustomerMasters");

            migrationBuilder.DropColumn(
                name: "supplierName",
                table: "CustomerMasters");

            migrationBuilder.RenameColumn(
                name: "supplierPhone",
                table: "CustomerMasters",
                newName: "customerName");

            migrationBuilder.UpdateData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 1,
                column: "customerName",
                value: "Công ty Cổ phần Alpha");

            migrationBuilder.UpdateData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 2,
                column: "customerName",
                value: "Tập đoàn Beta");

            migrationBuilder.InsertData(
                table: "CustomerMasters",
                columns: new[] { "id", "categoryId", "createdAt", "createdBy", "customerName", "isActive", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cửa hàng Tiện lợi 24/7", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nhà phân phối Miền Nam", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khách hàng Vãng lai", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }
    }
}
