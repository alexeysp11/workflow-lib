using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class EditedInitialOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_InitialOrders_InitialOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_InitialOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InitialOrderId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "InitialOrderProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: false),
                    InitialOrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_InitialOrders_InitialOrderId",
                        column: x => x.InitialOrderId,
                        principalTable: "InitialOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_InitialOrderId",
                table: "InitialOrderProducts",
                column: "InitialOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_ProductId",
                table: "InitialOrderProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitialOrderProducts");

            migrationBuilder.AddColumn<long>(
                name: "InitialOrderId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_InitialOrderId",
                table: "Products",
                column: "InitialOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_InitialOrders_InitialOrderId",
                table: "Products",
                column: "InitialOrderId",
                principalTable: "InitialOrders",
                principalColumn: "Id");
        }
    }
}
