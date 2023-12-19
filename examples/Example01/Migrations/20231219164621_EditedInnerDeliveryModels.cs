using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class EditedInnerDeliveryModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Ingredients_IngredientId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Ingredients");

            migrationBuilder.AddColumn<long>(
                name: "DeliveryKitchen2WhId",
                table: "InitialOrderProducts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeliveryWh2KitchenId",
                table: "InitialOrderProducts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneratedOrderQrCode",
                table: "BusinessTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InitialOrderIngredient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientId = table.Column<long>(type: "INTEGER", nullable: false),
                    InitialOrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryWh2KitchenId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrderIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredient_BusinessTasks_DeliveryWh2KitchenId",
                        column: x => x.DeliveryWh2KitchenId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredient_InitialOrders_InitialOrderId",
                        column: x => x.InitialOrderId,
                        principalTable: "InitialOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_DeliveryKitchen2WhId",
                table: "InitialOrderProducts",
                column: "DeliveryKitchen2WhId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_DeliveryWh2KitchenId",
                table: "InitialOrderProducts",
                column: "DeliveryWh2KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredient_DeliveryWh2KitchenId",
                table: "InitialOrderIngredient",
                column: "DeliveryWh2KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredient_IngredientId",
                table: "InitialOrderIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredient_InitialOrderId",
                table: "InitialOrderIngredient",
                column: "InitialOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderProducts_BusinessTasks_DeliveryKitchen2WhId",
                table: "InitialOrderProducts",
                column: "DeliveryKitchen2WhId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderProducts_BusinessTasks_DeliveryWh2KitchenId",
                table: "InitialOrderProducts",
                column: "DeliveryWh2KitchenId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderProducts_BusinessTasks_DeliveryKitchen2WhId",
                table: "InitialOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderProducts_BusinessTasks_DeliveryWh2KitchenId",
                table: "InitialOrderProducts");

            migrationBuilder.DropTable(
                name: "InitialOrderIngredient");

            migrationBuilder.DropIndex(
                name: "IX_InitialOrderProducts_DeliveryKitchen2WhId",
                table: "InitialOrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_InitialOrderProducts_DeliveryWh2KitchenId",
                table: "InitialOrderProducts");

            migrationBuilder.DropColumn(
                name: "DeliveryKitchen2WhId",
                table: "InitialOrderProducts");

            migrationBuilder.DropColumn(
                name: "DeliveryWh2KitchenId",
                table: "InitialOrderProducts");

            migrationBuilder.DropColumn(
                name: "GeneratedOrderQrCode",
                table: "BusinessTasks");

            migrationBuilder.AddColumn<long>(
                name: "IngredientId",
                table: "Ingredients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientId",
                table: "Ingredients",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Ingredients_IngredientId",
                table: "Ingredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");
        }
    }
}
