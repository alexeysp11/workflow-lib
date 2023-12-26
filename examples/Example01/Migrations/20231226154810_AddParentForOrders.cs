using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class AddParentForOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentDeliveryOrderId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentOrderId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ParentDeliveryOrderId",
                table: "Orders",
                column: "ParentDeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ParentOrderId",
                table: "Orders",
                column: "ParentOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Orders_ParentDeliveryOrderId",
                table: "Orders",
                column: "ParentDeliveryOrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Orders_ParentOrderId",
                table: "Orders",
                column: "ParentOrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Orders_ParentDeliveryOrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Orders_ParentOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ParentDeliveryOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ParentOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ParentDeliveryOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ParentOrderId",
                table: "Orders");
        }
    }
}
