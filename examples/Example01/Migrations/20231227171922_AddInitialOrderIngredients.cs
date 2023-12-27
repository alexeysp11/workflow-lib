using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class AddInitialOrderIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderIngredient_BusinessTasks_DeliveryWh2KitchenId",
                table: "InitialOrderIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderIngredient_Ingredients_IngredientId",
                table: "InitialOrderIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderIngredient_InitialOrders_InitialOrderId",
                table: "InitialOrderIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InitialOrderIngredient",
                table: "InitialOrderIngredient");

            migrationBuilder.RenameTable(
                name: "InitialOrderIngredient",
                newName: "InitialOrderIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_InitialOrderIngredient_InitialOrderId",
                table: "InitialOrderIngredients",
                newName: "IX_InitialOrderIngredients_InitialOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_InitialOrderIngredient_IngredientId",
                table: "InitialOrderIngredients",
                newName: "IX_InitialOrderIngredients_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_InitialOrderIngredient_DeliveryWh2KitchenId",
                table: "InitialOrderIngredients",
                newName: "IX_InitialOrderIngredients_DeliveryWh2KitchenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InitialOrderIngredients",
                table: "InitialOrderIngredients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderIngredients_BusinessTasks_DeliveryWh2KitchenId",
                table: "InitialOrderIngredients",
                column: "DeliveryWh2KitchenId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderIngredients_Ingredients_IngredientId",
                table: "InitialOrderIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderIngredients_InitialOrders_InitialOrderId",
                table: "InitialOrderIngredients",
                column: "InitialOrderId",
                principalTable: "InitialOrders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderIngredients_BusinessTasks_DeliveryWh2KitchenId",
                table: "InitialOrderIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderIngredients_Ingredients_IngredientId",
                table: "InitialOrderIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderIngredients_InitialOrders_InitialOrderId",
                table: "InitialOrderIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InitialOrderIngredients",
                table: "InitialOrderIngredients");

            migrationBuilder.RenameTable(
                name: "InitialOrderIngredients",
                newName: "InitialOrderIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_InitialOrderIngredients_InitialOrderId",
                table: "InitialOrderIngredient",
                newName: "IX_InitialOrderIngredient_InitialOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_InitialOrderIngredients_IngredientId",
                table: "InitialOrderIngredient",
                newName: "IX_InitialOrderIngredient_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_InitialOrderIngredients_DeliveryWh2KitchenId",
                table: "InitialOrderIngredient",
                newName: "IX_InitialOrderIngredient_DeliveryWh2KitchenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InitialOrderIngredient",
                table: "InitialOrderIngredient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderIngredient_BusinessTasks_DeliveryWh2KitchenId",
                table: "InitialOrderIngredient",
                column: "DeliveryWh2KitchenId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderIngredient_Ingredients_IngredientId",
                table: "InitialOrderIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderIngredient_InitialOrders_InitialOrderId",
                table: "InitialOrderIngredient",
                column: "InitialOrderId",
                principalTable: "InitialOrders",
                principalColumn: "Id");
        }
    }
}
