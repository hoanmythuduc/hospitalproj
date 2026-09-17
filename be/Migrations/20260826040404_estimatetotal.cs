using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class estimatetotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.AddColumn<decimal>(
                name: "estimatedTotal",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 1,
                column: "estimatedTotal",
                value: 2500000m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 2,
                column: "estimatedTotal",
                value: 2600000m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 3,
                column: "estimatedTotal",
                value: 2700000m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 4,
                column: "estimatedTotal",
                value: 2800000m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 5,
                column: "estimatedTotal",
                value: 2900000m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estimatedTotal",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "id", "createdAt", "createdBy", "isActive", "orderId", "price", "productName", "quantity", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 1, 1500000m, "Máy đo huyết áp Omron", 10, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 1, 500000m, "Nhiệt kế hồng ngoại", 20, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 2, 120000m, "Bơm tiêm nhựa 5ml (Hộp 100 cái)", 50, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 3, 25000m, "Cồn y tế 90 độ (Chai 500ml)", 100, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 3, 180000m, "Bông y tế 1kg", 10, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 4, 7500000m, "Máy tạo oxy 5 lít", 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 5, 1250000m, "Khẩu trang y tế 4 lớp (Thùng 50 hộp)", 5, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_orderId",
                table: "OrderItems",
                column: "orderId");
        }
    }
}
