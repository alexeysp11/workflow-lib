using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class AddProductTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTransfers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WHProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentId = table.Column<long>(type: "INTEGER", nullable: true),
                    BusinessOperationId = table.Column<long>(type: "INTEGER", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OldQuantity = table.Column<double>(type: "REAL", nullable: true),
                    NewQuantity = table.Column<double>(type: "REAL", nullable: false),
                    OldStatus = table.Column<string>(type: "TEXT", nullable: true),
                    NewStatus = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTransfers_ProductTransfers_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductTransfers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_WHProducts_WHProductId",
                        column: x => x.WHProductId,
                        principalTable: "WHProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_ParentId",
                table: "ProductTransfers",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_WHProductId",
                table: "ProductTransfers",
                column: "WHProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTransfers");
        }
    }
}
