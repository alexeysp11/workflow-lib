using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class AddedInitialOrdersCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeliveryKitchen2WhId",
                table: "InitialOrders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeliveryWh2KitchenId",
                table: "InitialOrders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InitialOrderProductId",
                table: "InitialOrderIngredients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_DeliveryKitchen2WhId",
                table: "InitialOrders",
                column: "DeliveryKitchen2WhId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_DeliveryWh2KitchenId",
                table: "InitialOrders",
                column: "DeliveryWh2KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_InitialOrderProductId",
                table: "InitialOrderIngredients",
                column: "InitialOrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderIngredients_InitialOrderProducts_InitialOrderProductId",
                table: "InitialOrderIngredients",
                column: "InitialOrderProductId",
                principalTable: "InitialOrderProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrders_BusinessTasks_DeliveryKitchen2WhId",
                table: "InitialOrders",
                column: "DeliveryKitchen2WhId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrders_BusinessTasks_DeliveryWh2KitchenId",
                table: "InitialOrders",
                column: "DeliveryWh2KitchenId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderIngredients_InitialOrderProducts_InitialOrderProductId",
                table: "InitialOrderIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrders_BusinessTasks_DeliveryKitchen2WhId",
                table: "InitialOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrders_BusinessTasks_DeliveryWh2KitchenId",
                table: "InitialOrders");

            migrationBuilder.DropIndex(
                name: "IX_InitialOrders_DeliveryKitchen2WhId",
                table: "InitialOrders");

            migrationBuilder.DropIndex(
                name: "IX_InitialOrders_DeliveryWh2KitchenId",
                table: "InitialOrders");

            migrationBuilder.DropIndex(
                name: "IX_InitialOrderIngredients_InitialOrderProductId",
                table: "InitialOrderIngredients");

            migrationBuilder.DropColumn(
                name: "DeliveryKitchen2WhId",
                table: "InitialOrders");

            migrationBuilder.DropColumn(
                name: "DeliveryWh2KitchenId",
                table: "InitialOrders");

            migrationBuilder.DropColumn(
                name: "InitialOrderProductId",
                table: "InitialOrderIngredients");
        }
    }
}
