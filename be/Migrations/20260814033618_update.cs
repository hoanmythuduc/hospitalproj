using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "CustomerMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "CustomerMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "CustomerMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "CustomerMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "CustomerMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "createdBy", "isActive", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "createdBy", "isActive", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "createdBy", "isActive", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "createdBy", "isActive", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CustomerMasters",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdAt", "createdBy", "isActive", "updatedAt", "updatedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "CustomerMasters");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "CustomerMasters");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "CustomerMasters");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "CustomerMasters");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "CustomerMasters");
        }
    }
}
