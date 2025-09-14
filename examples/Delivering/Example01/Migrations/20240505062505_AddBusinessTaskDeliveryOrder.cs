using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocipedeUtils.Examples.Delivering.Example01.Migrations
{
    public partial class AddBusinessTaskDeliveryOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_Orders_DeliveryOrderId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrders_Orders_DeliveryOrderId",
                table: "InitialOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BusinessTasks_DeliveryOperationId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryOperationId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_InitialOrders_DeliveryOrderId",
                table: "InitialOrders");

            migrationBuilder.DropColumn(
                name: "DeliveryOperationId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "DeliveryOrderId",
                table: "BusinessTasks",
                newName: "BusinessProcessStateId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_DeliveryOrderId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_BusinessProcessStateId");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "WHProducts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "UserGroups",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "UserAccounts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Skill",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Risk",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Recipes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "ProjectPlanItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "ProjectPhase",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Project",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "ProductTransfers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Products",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "ProductCategories",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Payments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Organizations",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "OrganizationItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "OrderProducts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Notifications",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "InitialOrders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "InitialOrderProducts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "InitialOrderIngredients",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Ingredients",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Employees",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "DeliveryOrderProducts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "DeliveryMethods",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Customers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Contract",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Contacts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Companies",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Comments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "BusinessTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "BusinessTasks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "BusinessTaskDeliveryOrders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "BusinessDiagram",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDiagram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDiagramElement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusinessDiagramId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDiagramElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessDiagramElement_BusinessDiagram_BusinessDiagramId",
                        column: x => x.BusinessDiagramId,
                        principalTable: "BusinessDiagram",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcess",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiagramId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentId = table.Column<long>(type: "INTEGER", nullable: true),
                    VersionNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_BusinessDiagram_DiagramId",
                        column: x => x.DiagramId,
                        principalTable: "BusinessDiagram",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessProcess_BusinessProcess_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcessState",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusinessProcessId = table.Column<long>(type: "INTEGER", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcessState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcessState_BusinessProcess_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDiagramElement_BusinessDiagramId",
                table: "BusinessDiagramElement",
                column: "BusinessDiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_DiagramId",
                table: "BusinessProcess",
                column: "DiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_ParentId",
                table: "BusinessProcess",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessState_BusinessProcessId",
                table: "BusinessProcessState",
                column: "BusinessProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_BusinessProcessState_BusinessProcessStateId",
                table: "BusinessTasks",
                column: "BusinessProcessStateId",
                principalTable: "BusinessProcessState",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_BusinessProcessState_BusinessProcessStateId",
                table: "BusinessTasks");

            migrationBuilder.DropTable(
                name: "BusinessDiagramElement");

            migrationBuilder.DropTable(
                name: "BusinessProcessState");

            migrationBuilder.DropTable(
                name: "BusinessProcess");

            migrationBuilder.DropTable(
                name: "BusinessDiagram");

            migrationBuilder.RenameColumn(
                name: "BusinessProcessStateId",
                table: "BusinessTasks",
                newName: "DeliveryOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_BusinessProcessStateId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_DeliveryOrderId");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "WHProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "UserGroups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "UserAccounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Skill",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Risk",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "ProjectPlanItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "ProjectPhase",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Project",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "ProductTransfers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "ProductCategories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "OrganizationItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeliveryOperationId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "OrderProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Notifications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "InitialOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "InitialOrderProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "InitialOrderIngredients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Ingredients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "DeliveryOrderProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "DeliveryMethods",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Contract",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Companies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "BusinessTasks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "BusinessTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessEntityStatus",
                table: "BusinessTaskDeliveryOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryOperationId",
                table: "Orders",
                column: "DeliveryOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_DeliveryOrderId",
                table: "InitialOrders",
                column: "DeliveryOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_Orders_DeliveryOrderId",
                table: "BusinessTasks",
                column: "DeliveryOrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrders_Orders_DeliveryOrderId",
                table: "InitialOrders",
                column: "DeliveryOrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BusinessTasks_DeliveryOperationId",
                table: "Orders",
                column: "DeliveryOperationId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");
        }
    }
}
