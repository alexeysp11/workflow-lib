using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Migrations
{
    public partial class AddDateCreatedIntoBusinessEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "WorkflowTrackingItems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "WorkflowInstances",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "WorkflowInstanceMember",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "WHProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserGroups",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserAccounts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Skill",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Risk",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Recipes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProjectPlanItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProjectPhase",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Project",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductTransfers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductCategories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrganizationItems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrderProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "InitialOrders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "InitialOrderProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "InitialOrderIngredients",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Ingredients",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "DeliveryOrderProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "DeliveryMethods",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Contract",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BusinessTasks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BusinessTaskDeliveryOrders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BusinessDiagramElement",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BusinessDiagram",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BPStateEndpointCalls",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BDEConnector",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "WorkflowTrackingItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "WorkflowInstances");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "WorkflowInstanceMember");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "WHProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProjectPlanItem");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProjectPhase");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductTransfers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OrganizationItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "InitialOrders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "InitialOrderProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "InitialOrderIngredients");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "DeliveryMethods");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BusinessTaskDeliveryOrders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BusinessDiagramElement");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BusinessDiagram");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BPStateEndpointCalls");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BDEConnector");
        }
    }
}
