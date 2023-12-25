using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class EditedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyUid",
                table: "Orders",
                newName: "ExecutorUid");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Orders",
                newName: "ExecutorName");

            migrationBuilder.AddColumn<int>(
                name: "OrderCustomerType",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderExecutorType",
                table: "Orders",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCustomerType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderExecutorType",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ExecutorUid",
                table: "Orders",
                newName: "CompanyUid");

            migrationBuilder.RenameColumn(
                name: "ExecutorName",
                table: "Orders",
                newName: "CompanyName");
        }
    }
}
