using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.Migrations
{
    public partial class PluralizeEntitiesTray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrderProducts_Tray_TrayId",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderProducts_Tray_TrayId",
                table: "InitialOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Tray_TrayId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tray_PackTypes_PackTypeId",
                table: "Tray");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tray",
                table: "Tray");

            migrationBuilder.RenameTable(
                name: "Tray",
                newName: "Trays");

            migrationBuilder.RenameIndex(
                name: "IX_Tray_PackTypeId",
                table: "Trays",
                newName: "IX_Trays_PackTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trays",
                table: "Trays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrderProducts_Trays_TrayId",
                table: "DeliveryOrderProducts",
                column: "TrayId",
                principalTable: "Trays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderProducts_Trays_TrayId",
                table: "InitialOrderProducts",
                column: "TrayId",
                principalTable: "Trays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Trays_TrayId",
                table: "OrderProducts",
                column: "TrayId",
                principalTable: "Trays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trays_PackTypes_PackTypeId",
                table: "Trays",
                column: "PackTypeId",
                principalTable: "PackTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrderProducts_Trays_TrayId",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderProducts_Trays_TrayId",
                table: "InitialOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Trays_TrayId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Trays_PackTypes_PackTypeId",
                table: "Trays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trays",
                table: "Trays");

            migrationBuilder.RenameTable(
                name: "Trays",
                newName: "Tray");

            migrationBuilder.RenameIndex(
                name: "IX_Trays_PackTypeId",
                table: "Tray",
                newName: "IX_Tray_PackTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tray",
                table: "Tray",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrderProducts_Tray_TrayId",
                table: "DeliveryOrderProducts",
                column: "TrayId",
                principalTable: "Tray",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderProducts_Tray_TrayId",
                table: "InitialOrderProducts",
                column: "TrayId",
                principalTable: "Tray",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Tray_TrayId",
                table: "OrderProducts",
                column: "TrayId",
                principalTable: "Tray",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tray_PackTypes_PackTypeId",
                table: "Tray",
                column: "PackTypeId",
                principalTable: "PackTypes",
                principalColumn: "Id");
        }
    }
}
