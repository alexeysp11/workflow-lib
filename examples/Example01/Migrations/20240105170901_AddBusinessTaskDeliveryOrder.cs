using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class AddBusinessTaskDeliveryOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessTaskDeliveryOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusinessTaskId = table.Column<long>(type: "INTEGER", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTaskDeliveryOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTaskDeliveryOrders_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTaskDeliveryOrders_Orders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTaskDeliveryOrders_BusinessTaskId",
                table: "BusinessTaskDeliveryOrders",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTaskDeliveryOrders_DeliveryOrderId",
                table: "BusinessTaskDeliveryOrders",
                column: "DeliveryOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessTaskDeliveryOrders");
        }
    }
}
