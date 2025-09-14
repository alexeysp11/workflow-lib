using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Migrations
{
    public partial class RenamedDateTimeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeDate",
                table: "UserGroups");

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
                table: "WorkflowTrackingItems",
                newName: "DateChanged");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
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

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "DbgLogs",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "ChangeDate",
                table: "DbgLogs",
                newName: "DateChanged");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "WorkflowInstances",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "WorkflowInstanceMember",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "WHProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "UserAccounts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Skill",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Risk",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Recipes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "ProjectPlanItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "ProjectPhase",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Project",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "ProductTransfers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "ProductCategories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Payments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Organizations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "OrganizationItems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "OrderProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "InitialOrders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "InitialOrderProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "InitialOrderIngredients",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Ingredients",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "DeliveryOrderProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "DeliveryMethods",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Contract",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessTasks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessTaskDeliveryOrders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessProcessStateTransitions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessProcessStates",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessProcesses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessDiagramElement",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BusinessDiagram",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BPStateEndpointCalls",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "BDEConnector",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "WorkflowInstances");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "WorkflowInstanceMember");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "WHProducts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "ProjectPlanItem");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "ProjectPhase");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "ProductTransfers");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "OrganizationItems");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "InitialOrders");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "InitialOrderProducts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "InitialOrderIngredients");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "DeliveryMethods");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessTaskDeliveryOrders");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessProcessStateTransitions");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessProcessStates");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessProcesses");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessDiagramElement");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BusinessDiagram");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BPStateEndpointCalls");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "BDEConnector");

            migrationBuilder.RenameColumn(
                name: "DateChanged",
                table: "WorkflowTrackingItems",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DateChanged",
                table: "UserGroups",
                newName: "CreationDate");

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

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "DbgLogs",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "DateChanged",
                table: "DbgLogs",
                newName: "ChangeDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeDate",
                table: "UserGroups",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeDate",
                table: "Risk",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Risk",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
