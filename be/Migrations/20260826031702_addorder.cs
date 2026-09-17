using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class addorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_CustomerMasters_customerId",
                        column: x => x.customerId,
                        principalTable: "CustomerMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
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
                table: "Orders",
                columns: new[] { "id", "createdAt", "createdBy", "customerId", "isActive", "orderDate", "orderNumber", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-001", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-002", new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, true, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-003", new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-004", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, true, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-005", new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerId",
                table: "Orders",
                column: "customerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
