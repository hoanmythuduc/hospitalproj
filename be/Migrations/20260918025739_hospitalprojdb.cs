using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class hospitalprojdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    to = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_parentId",
                        column: x => x.parentId,
                        principalTable: "Menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMaster",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    engineerInCharge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMaster", x => x.id);
                    table.ForeignKey(
                        name: "FK_CustomerMaster_CustomerCategory_categoryId",
                        column: x => x.categoryId,
                        principalTable: "CustomerCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Action",
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
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.id);
                    table.ForeignKey(
                        name: "FK_Action_Menu_menuId",
                        column: x => x.menuId,
                        principalTable: "Menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormField",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    colSpan = table.Column<int>(type: "int", nullable: false),
                    option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sortOrder = table.Column<int>(type: "int", nullable: false),
                    isSearchAble = table.Column<bool>(type: "bit", nullable: false),
                    isShowInForm = table.Column<bool>(type: "bit", nullable: false),
                    isShowInList = table.Column<bool>(type: "bit", nullable: false),
                    subField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tagField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    menuId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormField", x => x.id);
                    table.ForeignKey(
                        name: "FK_FormField_Menu_menuId",
                        column: x => x.menuId,
                        principalTable: "Menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
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
                        name: "FK_Group_Menu_Group_groupid",
                        column: x => x.groupid,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Menu_Menu_menuid",
                        column: x => x.menuid,
                        principalTable: "Menu",
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
                        name: "FK_User_Group_Group_groupid",
                        column: x => x.groupid,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Group_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    estimatedTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_CustomerMaster_customerId",
                        column: x => x.customerId,
                        principalTable: "CustomerMaster",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    equipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    conditionWhenReceived = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDateOfUse = table.Column<DateTime>(type: "datetime2", nullable: true),
                    conditionWhenStarted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierId = table.Column<int>(type: "int", nullable: false),
                    dailyTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weeklyTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    monthlyTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quarterlyTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    asNeededTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_CustomerMaster_supplierId",
                        column: x => x.supplierId,
                        principalTable: "CustomerMaster",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Group_Action_Action_actionid",
                        column: x => x.actionid,
                        principalTable: "Action",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Action_Group_groupid",
                        column: x => x.groupid,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productCategoryId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipment_ProductCategory_productCategoryId",
                        column: x => x.productCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMaintenance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    maintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    incidentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    engineerArrivedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    completedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    labSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    engineerSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMaintenance", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenance_Equipment_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMaintenanceSchedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    task = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    m1 = table.Column<bool>(type: "bit", nullable: false),
                    m2 = table.Column<bool>(type: "bit", nullable: false),
                    m3 = table.Column<bool>(type: "bit", nullable: false),
                    m4 = table.Column<bool>(type: "bit", nullable: false),
                    m5 = table.Column<bool>(type: "bit", nullable: false),
                    m6 = table.Column<bool>(type: "bit", nullable: false),
                    m7 = table.Column<bool>(type: "bit", nullable: false),
                    m8 = table.Column<bool>(type: "bit", nullable: false),
                    m9 = table.Column<bool>(type: "bit", nullable: false),
                    m10 = table.Column<bool>(type: "bit", nullable: false),
                    m11 = table.Column<bool>(type: "bit", nullable: false),
                    m12 = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    preparerId = table.Column<int>(type: "int", nullable: true),
                    approverId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMaintenanceSchedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceSchedule_Equipment_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceSchedule_User_approverId",
                        column: x => x.approverId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceSchedule_User_preparerId",
                        column: x => x.preparerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentManager",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentManager", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentManager_Equipment_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentManager_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentUsageLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    weekOfMonth = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    preparerId = table.Column<int>(type: "int", nullable: true),
                    inspectorId = table.Column<int>(type: "int", nullable: true),
                    inspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reviewerId = table.Column<int>(type: "int", nullable: true),
                    reviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUsageLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageLog_Equipment_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageLog_User_inspectorId",
                        column: x => x.inspectorId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageLog_User_preparerId",
                        column: x => x.preparerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageLog_User_reviewerId",
                        column: x => x.reviewerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WaterSystemLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    allowedRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trackingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    preparerId = table.Column<int>(type: "int", nullable: true),
                    inspectorId = table.Column<int>(type: "int", nullable: true),
                    inspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reviewerId = table.Column<int>(type: "int", nullable: true),
                    reviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterSystemLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_WaterSystemLog_Equipment_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaterSystemLog_User_inspectorId",
                        column: x => x.inspectorId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaterSystemLog_User_preparerId",
                        column: x => x.preparerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaterSystemLog_User_reviewerId",
                        column: x => x.reviewerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMaintenanceLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentId = table.Column<int>(type: "int", nullable: false),
                    logDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDaily = table.Column<bool>(type: "bit", nullable: false),
                    isWeekly = table.Column<bool>(type: "bit", nullable: false),
                    isMonthly = table.Column<bool>(type: "bit", nullable: false),
                    isQuarterly = table.Column<bool>(type: "bit", nullable: false),
                    isAsNeeded = table.Column<bool>(type: "bit", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    executorId = table.Column<int>(type: "int", nullable: false),
                    inspectorId = table.Column<int>(type: "int", nullable: true),
                    inspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reviewerId = table.Column<int>(type: "int", nullable: true),
                    reviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    relatedMaintenanceId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMaintenanceLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLog_EquipmentMaintenance_relatedMaintenanceId",
                        column: x => x.relatedMaintenanceId,
                        principalTable: "EquipmentMaintenance",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLog_Equipment_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLog_User_executorId",
                        column: x => x.executorId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLog_User_inspectorId",
                        column: x => x.inspectorId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLog_User_reviewerId",
                        column: x => x.reviewerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentUsageDailyLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usageLogId = table.Column<int>(type: "int", nullable: false),
                    logDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dayOfWeek = table.Column<int>(type: "int", nullable: false),
                    shift1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usageCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maintenanceCallTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dailyDecon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preMaintenanceDecon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isNormal = table.Column<bool>(type: "bit", nullable: true),
                    qcResult = table.Column<bool>(type: "bit", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUsageDailyLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageDailyLog_EquipmentUsageLog_usageLogId",
                        column: x => x.usageLogId,
                        principalTable: "EquipmentUsageLog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterSystemDailyLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    waterSystemLogId = table.Column<int>(type: "int", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    usValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trackerId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterSystemDailyLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_WaterSystemDailyLog_User_trackerId",
                        column: x => x.trackerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaterSystemDailyLog_WaterSystemLog_waterSystemLogId",
                        column: x => x.waterSystemLogId,
                        principalTable: "WaterSystemLog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerCategory",
                columns: new[] { "id", "createdAt", "createdBy", "discount", "groupName", "isActive", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15.0m, "Khách hàng V.I.P", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10.0m, "Khách mua sỉ", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0m, "Khách vãng lai", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5.0m, "Khách hàng thân thiết", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20.0m, "Đối tác chiến lược", true, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "FormField",
                columns: new[] { "id", "colSpan", "createdAt", "createdBy", "endPoint", "entityName", "field", "isActive", "isSearchAble", "isShowInForm", "isShowInList", "label", "menuId", "option", "sortOrder", "subField", "tabName", "tagField", "type", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "User", "username", true, false, false, false, "Tên đăng nhập", null, "", 1, null, null, null, "text", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "User", "department", true, false, false, false, "Phòng ban", null, "", 2, null, null, null, "select", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "id", "code", "createdAt", "createdBy", "isActive", "name", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, "ADMIN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Quản trị hệ thống", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "DOCTOR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bác sĩ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "Employee", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Nhân viên", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "id", "createdAt", "createdBy", "icon", "isActive", "label", "parentId", "to", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "shield", true, "SECURITY & SYSTEM", null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "users", true, "EMPLOYEE MANAGEMENT", null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "settings", true, "ADMINISTRATION", null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "shopping-cart", true, "TRANSACTIONS", null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "database", true, "MASTER DATA", null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "createdAt", "createdBy", "customerId", "estimatedTotal", "isActive", "orderDate", "orderNumber", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 2700000m, true, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-003", new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2900000m, true, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-005", new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "createdAt", "createdBy", "department", "email", "isActive", "password", "updatedAt", "updatedBy", "userCode", "userName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ban Giám Đốc", "admin@test.com", true, "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "NV001", "admin" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khoa Nội", "bs@test.com", true, "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BS001", "bacsi01" }
                });

            migrationBuilder.InsertData(
                table: "CustomerMaster",
                columns: new[] { "id", "categoryId", "createdAt", "createdBy", "engineerInCharge", "isActive", "supplierAddress", "supplierEmail", "supplierName", "supplierPhone", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lê Văn C", true, "Quận 3, TP.HCM", "support@medjin.com", "Công ty TBYT MedJin", "0988777666", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nguyễn Văn A", true, "Quận 1, TP.HCM", "contact@abc.com", "Công ty TBYT ABC", "0909123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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
                table: "Menu",
                columns: new[] { "id", "createdAt", "createdBy", "icon", "isActive", "label", "parentId", "to", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "user", true, "User Accounts", 1, "/system/users", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "users", true, "User Groups", 1, "/system/groups", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "user-check", true, "Employee Management", 2, "/employee/manage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sliders", true, "Administration", 3, "/admin/settings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "file-text", true, "Orders", 4, "/transactions/orders", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "file-invoice", true, "Invoice Management", 4, "/transactions/invoices", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "tag", true, "Product Categories", 5, "/master/product-categories", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "users", true, "Customer Categories", 5, "/master/customer-categories", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "user", true, "Customer Master", 5, "/master/customers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "calendar", true, "Maintenance Plan", 4, "/transactions/maintenance-plan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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
                table: "Action",
                columns: new[] { "id", "code", "createdAt", "createdBy", "endpoint", "isActive", "label", "menuId", "method", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, "VIEW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "/api/users", true, "View", 6, "GET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "CREATE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "/api/users", true, "Create", 6, "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "EDIT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "/api/users/{id}", true, "Update", 6, "PUT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "DELETE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "/api/users/{id}", true, "Delete", 6, "DELETE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, "VIEW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "/api/groups", true, "View", 7, "GET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, "CREATE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "/api/groups", true, "Create", 7, "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, "EDIT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "/api/groups/{id}", true, "Update", 7, "PUT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, "DELETE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "/api/groups/{id}", true, "Delete", 7, "DELETE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Group_Menu",
                columns: new[] { "groupid", "menuid" },
                values: new object[,]
                {
                    { 2, 8 },
                    { 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "createdAt", "createdBy", "customerId", "estimatedTotal", "isActive", "orderDate", "orderNumber", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2500000m, true, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-001", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2600000m, true, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-002", new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2800000m, true, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-2026-004", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "id", "asNeededTask", "conditionWhenReceived", "conditionWhenStarted", "countryOfOrigin", "createdAt", "createdBy", "dailyTask", "equipmentCode", "equipmentName", "isActive", "location", "manufacturer", "model", "monthlyTask", "quarterlyTask", "receivedDate", "serialNumber", "startDateOfUse", "supplierId", "updatedAt", "updatedBy", "weeklyTask" },
                values: new object[,]
                {
                    { 1, "Thay thế linh kiện", "Mới 100%", "Hoạt động tốt", "Đức", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiểm tra hoạt động máy", "TB-XN-01", "Máy ly tâm Huyết học", true, "Phòng Xét nghiệm Hóa sinh", "BioTech Lab", "CENT-200", "Tra dầu rotor", "Bảo trì động cơ", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SN-2026001", new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vệ sinh buồng ly tâm" },
                    { 2, "Thay pin/vòng bít", "Mới 100%", "Hoạt động tốt", "Nhật Bản", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiểm tra pin và nguồn", "HA-OM-01", "Máy đo huyết áp điện tử", true, "Phòng Khám Nội", "Omron", "HEM-7120", "Kiểm tra vòng bít", "Đo kiểm định kỳ", new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SN-2026002", new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vệ sinh màn hình" },
                    { 3, "Thay hạt zeolite", "Mới 100%", "Hoạt động tốt", "Trung Quốc", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiểm tra lưu lượng oxy", "OXY-5L-01", "Máy tạo oxy 5 Lít", true, "Phòng Cấp Cứu", "Yuwell", "OXY-5", "Thay bộ lọc thô", "Bảo trì động cơ nén", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SN-2026003", new DateTime(2026, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vệ sinh bình làm ẩm" },
                    { 4, "Thay thế lõi lọc/màng RO", "Mới 100%", "Hoạt động tốt", "Việt Nam", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiểm tra độ dẫn điện <1,0 µS/cm", "KXN-RO-01", "Hệ thống lọc nước RO", true, "Sinh hóa - Huyết học - Miễn dịch", "AquaCare", "RO-LAB-500", "Rửa màng lọc", "Bảo trì hệ thống van", new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SN-RO-2026", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vệ sinh buồng lọc" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "createdAt", "createdBy", "isActive", "productCategoryId", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 2, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 3, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 4, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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
                table: "EquipmentMaintenance",
                columns: new[] { "id", "actionType", "completedTime", "content", "createdAt", "createdBy", "engineerArrivedTime", "engineerSignature", "equipmentId", "incidentTime", "isActive", "labSignature", "maintenanceDate", "purpose", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, "Bảo trì", new DateTime(2026, 10, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "Vệ sinh buồng ly tâm, kiểm tra rotor", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 10, 15, 8, 30, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn A", 1, null, true, "Đã ký", new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bảo trì định kỳ 6 tháng", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "Sửa chữa", new DateTime(2026, 12, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "Thay thế bo mạch nguồn", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 12, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "Trần Văn B", 1, new DateTime(2026, 12, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), true, "Đã ký", new DateTime(2026, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khắc phục lỗi không lên nguồn", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "Hiệu chuẩn", new DateTime(2026, 11, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), "Hiệu chuẩn cảm biến áp suất", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 11, 20, 13, 30, 0, 0, DateTimeKind.Unspecified), "Lê Văn C", 2, null, true, "Đã ký", new DateTime(2026, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đảm bảo độ chính xác", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "Sửa chữa", new DateTime(2026, 11, 25, 15, 45, 0, 0, DateTimeKind.Unspecified), "Thay bộ lọc khí", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 11, 25, 11, 15, 0, 0, DateTimeKind.Unspecified), "Trần Văn B", 3, new DateTime(2026, 11, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Đã ký", new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Máy kêu to", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "EquipmentMaintenanceLog",
                columns: new[] { "id", "createdAt", "createdBy", "equipmentId", "executorId", "inspectionDate", "inspectorId", "isActive", "isAsNeeded", "isDaily", "isMonthly", "isQuarterly", "isWeekly", "logDate", "note", "relatedMaintenanceId", "reviewDate", "reviewerId", "status", "updatedAt", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Máy hoạt động bình thường", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vệ sinh buồng mẫu", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chạy mẫu test OK", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, true, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bảo dưỡng cuối tuần, xả sương", null, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Máy đã sửa xong, chạy ổn", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, new DateTime(2026, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, false, new DateTime(2026, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, true, false, false, true, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bảo dưỡng cuối tuần", null, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, null, null, true, false, true, false, false, false, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khởi động đầu ca tốt", null, null, null, 1, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "EquipmentMaintenanceSchedule",
                columns: new[] { "id", "approverId", "createdAt", "createdBy", "equipmentId", "isActive", "m1", "m10", "m11", "m12", "m2", "m3", "m4", "m5", "m6", "m7", "m8", "m9", "note", "preparerId", "status", "task", "updatedAt", "updatedBy", "year" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, false, false, false, true, false, true, false, false, true, false, false, true, "Yêu cầu kỹ sư hãng", 2, 2, "Bảo dưỡng hệ thống quay và tra dầu", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2026 },
                    { 2, 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, false, false, true, false, false, false, false, true, false, false, false, "Đo đối chiếu máy thủy ngân", 2, 2, "Hiệu chuẩn cảm biến áp suất", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2026 },
                    { 3, 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, true, true, true, true, true, true, true, true, true, true, true, true, true, "Ưu tiên làm đầu tháng", 2, 2, "Thay bộ lọc và kiểm tra lưu lượng", new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2026 }
                });

            migrationBuilder.InsertData(
                table: "EquipmentManager",
                columns: new[] { "id", "createdAt", "createdBy", "equipmentId", "fromDate", "isActive", "updatedAt", "updatedBy", "userId", "userName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "admin" },
                    { 2, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "bacsi01" },
                    { 3, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "admin02" },
                    { 4, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "admin" },
                    { 5, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "bacsi01" },
                    { 6, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Nguyễn Văn An" },
                    { 7, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "bacsi01" },
                    { 8, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "admin02" },
                    { 9, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Nguyễn Văn An" }
                });

            migrationBuilder.InsertData(
                table: "EquipmentUsageLog",
                columns: new[] { "id", "createdAt", "createdBy", "equipmentId", "inspectionDate", "inspectorId", "isActive", "month", "preparerId", "reviewDate", "reviewerId", "status", "updatedAt", "updatedBy", "weekOfMonth", "year" },
                values: new object[] { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, true, 8, 2, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2026 });

            migrationBuilder.InsertData(
                table: "WaterSystemLog",
                columns: new[] { "id", "allowedRange", "createdAt", "createdBy", "equipmentId", "inspectionDate", "inspectorId", "isActive", "month", "preparerId", "reviewDate", "reviewerId", "status", "trackingTime", "updatedAt", "updatedBy", "year" },
                values: new object[] { 1, "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 8, 2, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2026 });

            migrationBuilder.InsertData(
                table: "EquipmentMaintenanceLog",
                columns: new[] { "id", "createdAt", "createdBy", "equipmentId", "executorId", "inspectionDate", "inspectorId", "isActive", "isAsNeeded", "isDaily", "isMonthly", "isQuarterly", "isWeekly", "logDate", "note", "relatedMaintenanceId", "reviewDate", "reviewerId", "status", "updatedAt", "updatedBy" },
                values: new object[] { 10, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, true, true, false, false, false, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lỗi bo mạch, đã gọi kỹ sư", 2, null, null, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "EquipmentUsageDailyLog",
                columns: new[] { "id", "createdAt", "createdBy", "dailyDecon", "dayOfWeek", "isActive", "isNormal", "logDate", "maintenanceCallTime", "preMaintenanceDecon", "qcResult", "shift1", "shift2", "shift3", "shift4", "shift5", "updatedAt", "updatedBy", "usageCount", "usageLogId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 2, true, true, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 2, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 3, true, true, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 3, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 4, true, false, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "15:00", "TranThiDieu", false, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 4, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 5, true, true, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 5, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 6, true, true, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "bacsi01", "X", "Trần Thị Bình", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 7, true, true, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "Nguyễn Văn An", "", "Lê Trọng Đại", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 },
                    { 7, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TranThiDieu", 8, true, true, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", true, "Nguyễn Văn An", "", "Lê Trọng Đại", "TranThiDieu", "", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "45", 1 }
                });

            migrationBuilder.InsertData(
                table: "WaterSystemDailyLog",
                columns: new[] { "id", "createdAt", "createdBy", "day", "isActive", "trackerId", "updatedAt", "updatedBy", "usValue", "waterSystemLogId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, 2, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 2, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, 2, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 3, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, true, 2, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 4, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, true, 2, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 5, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, true, 2, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 6, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, true, 2, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 7, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, true, 2, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 8, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, true, 2, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 9, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, true, 2, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 10, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, true, 2, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 11, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, true, 2, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 12, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, true, 2, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 13, new DateTime(2026, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, true, 2, new DateTime(2026, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 14, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, true, 2, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 15, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, true, 2, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 16, new DateTime(2026, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 16, true, 2, new DateTime(2026, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 17, new DateTime(2026, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 17, true, 2, new DateTime(2026, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 18, new DateTime(2026, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 18, true, 2, new DateTime(2026, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 19, new DateTime(2026, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 19, true, 2, new DateTime(2026, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 20, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20, true, 2, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 21, new DateTime(2026, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 21, true, 2, new DateTime(2026, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 22, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 22, true, 2, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 23, new DateTime(2026, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 23, true, 2, new DateTime(2026, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 24, new DateTime(2026, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 24, true, 2, new DateTime(2026, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 25, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 25, true, 2, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 26, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 26, true, 2, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 27, new DateTime(2026, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 27, true, 2, new DateTime(2026, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 28, new DateTime(2026, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 28, true, 2, new DateTime(2026, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 29, new DateTime(2026, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 29, true, 2, new DateTime(2026, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 30, new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, true, 2, new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 },
                    { 31, new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 31, true, 2, new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<1,0", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Action_menuId",
                table: "Action",
                column: "menuId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMaster_categoryId",
                table: "CustomerMaster",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_productCategoryId",
                table: "Equipment",
                column: "productCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenance_equipmentId",
                table: "EquipmentMaintenance",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLog_equipmentId",
                table: "EquipmentMaintenanceLog",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLog_executorId",
                table: "EquipmentMaintenanceLog",
                column: "executorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLog_inspectorId",
                table: "EquipmentMaintenanceLog",
                column: "inspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLog_relatedMaintenanceId",
                table: "EquipmentMaintenanceLog",
                column: "relatedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLog_reviewerId",
                table: "EquipmentMaintenanceLog",
                column: "reviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceSchedule_approverId",
                table: "EquipmentMaintenanceSchedule",
                column: "approverId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceSchedule_equipmentId",
                table: "EquipmentMaintenanceSchedule",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceSchedule_preparerId",
                table: "EquipmentMaintenanceSchedule",
                column: "preparerId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentManager_equipmentId",
                table: "EquipmentManager",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentManager_userId",
                table: "EquipmentManager",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageDailyLog_usageLogId",
                table: "EquipmentUsageDailyLog",
                column: "usageLogId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageLog_equipmentId",
                table: "EquipmentUsageLog",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageLog_inspectorId",
                table: "EquipmentUsageLog",
                column: "inspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageLog_preparerId",
                table: "EquipmentUsageLog",
                column: "preparerId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageLog_reviewerId",
                table: "EquipmentUsageLog",
                column: "reviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_FormField_menuId",
                table: "FormField",
                column: "menuId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_code",
                table: "Group",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_name",
                table: "Group",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_Action_groupid",
                table: "Group_Action",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Menu_menuid",
                table: "Group_Menu",
                column: "menuid");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_parentId",
                table: "Menu",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_customerId",
                table: "Order",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_supplierId",
                table: "ProductCategory",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_User_userCode",
                table: "User",
                column: "userCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Group_userid",
                table: "User_Group",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemDailyLog_trackerId",
                table: "WaterSystemDailyLog",
                column: "trackerId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemDailyLog_waterSystemLogId",
                table: "WaterSystemDailyLog",
                column: "waterSystemLogId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemLog_equipmentId",
                table: "WaterSystemLog",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemLog_inspectorId",
                table: "WaterSystemLog",
                column: "inspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemLog_preparerId",
                table: "WaterSystemLog",
                column: "preparerId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterSystemLog_reviewerId",
                table: "WaterSystemLog",
                column: "reviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentMaintenanceLog");

            migrationBuilder.DropTable(
                name: "EquipmentMaintenanceSchedule");

            migrationBuilder.DropTable(
                name: "EquipmentManager");

            migrationBuilder.DropTable(
                name: "EquipmentUsageDailyLog");

            migrationBuilder.DropTable(
                name: "FormField");

            migrationBuilder.DropTable(
                name: "Group_Action");

            migrationBuilder.DropTable(
                name: "Group_Menu");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "User_Group");

            migrationBuilder.DropTable(
                name: "WaterSystemDailyLog");

            migrationBuilder.DropTable(
                name: "EquipmentMaintenance");

            migrationBuilder.DropTable(
                name: "EquipmentUsageLog");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "WaterSystemLog");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "CustomerMaster");

            migrationBuilder.DropTable(
                name: "CustomerCategory");
        }
    }
}
