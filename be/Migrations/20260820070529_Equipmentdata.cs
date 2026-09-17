using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class Equipmentdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "optionLabel",
            //    table: "FormFields");

            //migrationBuilder.RenameColumn(
            //    name: "optionValue",
            //    table: "FormFields",
            //    newName: "endPoint");

            //migrationBuilder.RenameColumn(
            //    name: "isDetail",
            //    table: "FormFields",
            //    newName: "isShowInList");

            migrationBuilder.AlterColumn<string>(
                name: "tagField",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "tabName",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "subField",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "option",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //migrationBuilder.AddColumn<bool>(
            //    name: "isSearchAble",
            //    table: "FormFields",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "isShowInForm",
            //    table: "FormFields",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    equipmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    conditionWhenReceived = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDateOfUse = table.Column<DateTime>(type: "datetime2", nullable: true),
                    conditionWhenStarted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    engineerInCharge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "id", "conditionWhenReceived", "conditionWhenStarted", "countryOfOrigin", "createdAt", "createdBy", "engineerInCharge", "equipmentCode", "equipmentName", "isActive", "location", "manufacturer", "model", "receivedDate", "serialNumber", "startDateOfUse", "supplierAddress", "supplierEmail", "supplierName", "supplierPhone", "updatedAt", "updatedBy" },
                values: new object[] { 1, "Mới 100%", "Hoạt động tốt", "Đức", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nguyễn Văn A", "TB-XN-01", "Máy ly tâm Huyết học", true, "Phòng Xét nghiệm Hóa sinh", "BioTech Lab", "CENT-200", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SN-2026001", new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quận 1, TP.HCM", "contact@abc.com", "Công ty TBYT ABC", "0909123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "isSearchAble", "isShowInForm", "subField", "tabName", "tagField" },
                values: new object[] { false, false, null, null, null });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "isSearchAble", "isShowInForm", "subField", "tabName", "tagField" },
                values: new object[] { false, false, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            //migrationBuilder.DropColumn(
            //    name: "isSearchAble",
            //    table: "FormFields");

            //migrationBuilder.DropColumn(
            //    name: "isShowInForm",
            //    table: "FormFields");

            //migrationBuilder.RenameColumn(
            //    name: "isShowInList",
            //    table: "FormFields",
            //    newName: "isDetail");

            migrationBuilder.RenameColumn(
                name: "endPoint",
                table: "FormFields",
                newName: "optionValue");

            migrationBuilder.AlterColumn<string>(
                name: "tagField",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tabName",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "subField",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "option",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "optionLabel",
            //    table: "FormFields",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "optionLabel", "subField", "tabName", "tagField" },
                values: new object[] { null, "", "", "" });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "optionLabel", "subField", "tabName", "tagField" },
                values: new object[] { null, "", "", "" });
        }
    }
}
