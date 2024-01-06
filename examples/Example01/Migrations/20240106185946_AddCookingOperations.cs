using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class AddCookingOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CookingOperationId",
                table: "InitialOrders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CookingOperationId",
                table: "InitialOrderProducts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CookingOperationId",
                table: "InitialOrderIngredients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_CookingOperationId",
                table: "InitialOrders",
                column: "CookingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_CookingOperationId",
                table: "InitialOrderProducts",
                column: "CookingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_CookingOperationId",
                table: "InitialOrderIngredients",
                column: "CookingOperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderIngredients_BusinessTasks_CookingOperationId",
                table: "InitialOrderIngredients",
                column: "CookingOperationId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderProducts_BusinessTasks_CookingOperationId",
                table: "InitialOrderProducts",
                column: "CookingOperationId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrders_BusinessTasks_CookingOperationId",
                table: "InitialOrders",
                column: "CookingOperationId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderIngredients_BusinessTasks_CookingOperationId",
                table: "InitialOrderIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderProducts_BusinessTasks_CookingOperationId",
                table: "InitialOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrders_BusinessTasks_CookingOperationId",
                table: "InitialOrders");

            migrationBuilder.DropIndex(
                name: "IX_InitialOrders_CookingOperationId",
                table: "InitialOrders");

            migrationBuilder.DropIndex(
                name: "IX_InitialOrderProducts_CookingOperationId",
                table: "InitialOrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_InitialOrderIngredients_CookingOperationId",
                table: "InitialOrderIngredients");

            migrationBuilder.DropColumn(
                name: "CookingOperationId",
                table: "InitialOrders");

            migrationBuilder.DropColumn(
                name: "CookingOperationId",
                table: "InitialOrderProducts");

            migrationBuilder.DropColumn(
                name: "CookingOperationId",
                table: "InitialOrderIngredients");
        }
    }
}
