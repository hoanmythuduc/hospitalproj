using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class HospitalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    to = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_parentId",
                        column: x => x.parentId,
                        principalTable: "Menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuId = table.Column<int>(type: "int", nullable: false),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Actions_Menus_menuId",
                        column: x => x.menuId,
                        principalTable: "Menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormFields",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    colSpan = table.Column<int>(type: "int", nullable: false),
                    option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tabName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDetail = table.Column<bool>(type: "bit", nullable: false),
                    sortOrder = table.Column<int>(type: "int", nullable: false),
                    optionLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    optionValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tagField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    menuId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFields", x => x.id);
                    table.ForeignKey(
                        name: "FK_FormFields_Menus_menuId",
                        column: x => x.menuId,
                        principalTable: "Menus",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Group_Menu",
                columns: table => new
                {
                    groupid = table.Column<int>(type: "int", nullable: false),
                    menuid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Menu", x => new { x.groupid, x.menuid });
                    table.ForeignKey(
                        name: "FK_Group_Menu_Groups_groupid",
                        column: x => x.groupid,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Menu_Menus_menuid",
                        column: x => x.menuid,
                        principalTable: "Menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Group",
                columns: table => new
                {
                    groupid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Group", x => new { x.groupid, x.userid });
                    table.ForeignKey(
                        name: "FK_User_Group_Groups_groupid",
                        column: x => x.groupid,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Group_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group_Action",
                columns: table => new
                {
                    actionid = table.Column<int>(type: "int", nullable: false),
                    groupid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Action", x => new { x.actionid, x.groupid });
                    table.ForeignKey(
                        name: "FK_Group_Action_Actions_actionid",
                        column: x => x.actionid,
                        principalTable: "Actions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Action_Groups_groupid",
                        column: x => x.groupid,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormFields",
                columns: new[] { "id", "colSpan", "createdAt", "entityName", "field", "isDetail", "label", "menuId", "option", "optionLabel", "optionValue", "sortOrder", "subField", "tabName", "tagField", "type", "updatedAt" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7125), "User", "username", false, "Tên đăng nhập", null, "", null, null, 1, "", "", "", "text", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7126) },
                    { 2, 6, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7130), "User", "department", false, "Phòng ban", null, "", null, null, 2, "", "", "", "select", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7130) }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "id", "code", "createdAt", "name", "updatedAt" },
                values: new object[,]
                {
                    { 1, "ADMIN", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6987), "Quản trị hệ thống", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6987) },
                    { 2, "DOCTOR", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6989), "Bác sĩ", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6989) },
                    { 3, "Employee", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6990), "Nhân viên", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6990) }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "id", "createdAt", "icon", "label", "parentId", "to", "updatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7074), "shield", "SECURITY & SYSTEM", null, "", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7074) },
                    { 2, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7077), "users", "EMPLOYEE MANAGEMENT", null, "", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7077) },
                    { 3, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7079), "settings", "ADMINISTRATION", null, "", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7079) },
                    { 4, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7081), "shopping-cart", "TRANSACTIONS", null, "", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7081) },
                    { 5, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7083), "database", "MASTER DATA", null, "", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7083) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "createdAt", "department", "email", "password", "updatedAt", "userCode", "userName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6886), "Ban Giám Đốc", "admin@test.com", "123", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6889), "NV001", "admin" },
                    { 2, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6896), "Khoa Nội", "bs@test.com", "123", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(6896), "BS001", "bacsi01" }
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "id", "code", "createdAt", "endpoint", "label", "menuId", "method", "updatedAt" },
                values: new object[,]
                {
                    { 1, "USER_VIEW_LIST", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7013), "/api/users", "Danh sách ", 2, "GET", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7013) },
                    { 2, "USER_VIEW_DETAIL", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7016), "/api/users/{id}", "Chi tiết ", 2, "GET", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7016) },
                    { 3, "USER_ADD", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7018), "/api/users", "Thêm mới ", 2, "POST", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7018) },
                    { 4, "USER_EDIT", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7019), "/api/users/{id}", "Cập nhật ", 2, "PUT", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7020) },
                    { 5, "USER_DEL", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7021), "/api/users/{id}", "Xóa ", 2, "DELETE", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7021) }
                });

            migrationBuilder.InsertData(
                table: "Group_Menu",
                columns: new[] { "groupid", "menuid" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "id", "createdAt", "icon", "label", "parentId", "to", "updatedAt" },
                values: new object[,]
                {
                    { 6, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7085), "user", "User Accounts", 1, "/system/users", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7085) },
                    { 7, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7086), "users", "User Groups", 1, "/system/groups", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7087) },
                    { 8, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7088), "user-check", "Employee Management", 2, "/employee/manage", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7088) },
                    { 9, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7090), "sliders", "Administration", 3, "/admin/settings", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7090) },
                    { 10, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7091), "file-text", "Orders", 4, "/transactions/orders", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7091) },
                    { 11, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7093), "file-invoice", "Invoice Management", 4, "/transactions/invoices", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7093) },
                    { 12, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7094), "tag", "Product Categories", 5, "/master/product-categories", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7094) },
                    { 13, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7096), "users", "Customer Categories", 5, "/master/customer-categories", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7096) },
                    { 14, new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7097), "user", "Customer Master", 5, "/master/customers", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7097) }
                });

            migrationBuilder.InsertData(
                table: "User_Group",
                columns: new[] { "groupid", "userid" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "id", "code", "createdAt", "endpoint", "label", "menuId", "method", "updatedAt" },
                values: new object[,]
                {
                    { 6, "GROUP_VIEW_LIST", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7023), "/api/groups", "Danh sách nhóm", 7, "GET", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7023) },
                    { 7, "GROUP_ADD", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7024), "/api/groups", "Thêm nhóm", 7, "POST", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7024) },
                    { 8, "GROUP_EDIT", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7025), "/api/groups/{id}", "Sửa nhóm", 7, "PUT", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7026) },
                    { 9, "GROUP_DEL", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7027), "/api/groups/{id}", "Xóa nhóm", 7, "DELETE", new DateTime(2026, 8, 6, 6, 35, 19, 321, DateTimeKind.Utc).AddTicks(7027) }
                });

            migrationBuilder.InsertData(
                table: "Group_Action",
                columns: new[] { "actionid", "groupid" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 1 },
                    { 4, 2 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Group_Menu",
                columns: new[] { "groupid", "menuid" },
                values: new object[,]
                {
                    { 2, 8 },
                    { 3, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_menuId",
                table: "Actions",
                column: "menuId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_menuId",
                table: "FormFields",
                column: "menuId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Action_groupid",
                table: "Group_Action",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Menu_menuid",
                table: "Group_Menu",
                column: "menuid");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_code",
                table: "Groups",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_name",
                table: "Groups",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_parentId",
                table: "Menus",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Group_userid",
                table: "User_Group",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userCode",
                table: "Users",
                column: "userCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormFields");

            migrationBuilder.DropTable(
                name: "Group_Action");

            migrationBuilder.DropTable(
                name: "Group_Menu");

            migrationBuilder.DropTable(
                name: "User_Group");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
