using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Examples.Delivering.Example01.Migrations
{
    public partial class RenamedDateTimeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeDate",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "UserGroups",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "ChangeDate",
                table: "UserGroups",
                newName: "DateChanged");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Project",
                newName: "DateStarted");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Project",
                newName: "DateEnded");

            migrationBuilder.RenameColumn(
                name: "ActualEndDate",
                table: "Project",
                newName: "DateEndedActual");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "WHProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "WHProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "UserAccounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserAccounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Skill",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Skill",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Risk",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Risk",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Recipes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Recipes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "ProjectPlanItem",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProjectPlanItem",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "ProjectPhase",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProjectPhase",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Project",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Project",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "ProductTransfers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductTransfers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "ProductCategories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductCategories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Payments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Organizations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "OrganizationItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrganizationItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "OrderProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrderProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Notifications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Notifications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "InitialOrders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "InitialOrders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "InitialOrderProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "InitialOrderProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "InitialOrderIngredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "InitialOrderIngredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Employees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Employees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "DeliveryOrderProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "DeliveryOrderProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "DeliveryMethods",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "DeliveryMethods",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Contract",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Contract",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Contacts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Companies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Companies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Comments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BusinessTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessTaskDeliveryOrders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BusinessTaskDeliveryOrders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessProcessState",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessProcess",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessDiagramElement",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BusinessDiagramElement",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessDiagram",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BusinessDiagram",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "WHProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "WHProducts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "ProjectPlanItem");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProjectPlanItem");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "ProjectPhase");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProjectPhase");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "ProductTransfers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductTransfers");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "OrganizationItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OrganizationItems");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "InitialOrders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "InitialOrders");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "InitialOrderProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "InitialOrderProducts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "InitialOrderIngredients");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "InitialOrderIngredients");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "DeliveryMethods");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "DeliveryMethods");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessTaskDeliveryOrders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BusinessTaskDeliveryOrders");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessProcessState");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessProcess");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessDiagramElement");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BusinessDiagramElement");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessDiagram");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BusinessDiagram");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserGroups",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DateChanged",
                table: "UserGroups",
                newName: "ChangeDate");

            migrationBuilder.RenameColumn(
                name: "DateStarted",
                table: "Project",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DateEndedActual",
                table: "Project",
                newName: "ActualEndDate");

            migrationBuilder.RenameColumn(
                name: "DateEnded",
                table: "Project",
                newName: "EndDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeDate",
                table: "Risk",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Risk",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
