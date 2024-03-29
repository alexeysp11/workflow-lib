using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Examples.ServiceInteraction.Core.Migrations
{
    public partial class AddBusinessProcessStateForBusinessTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessProcessStateId",
                table: "BusinessTasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_BusinessProcessStateId",
                table: "BusinessTasks",
                column: "BusinessProcessStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_BusinessProcessStates_BusinessProcessStateId",
                table: "BusinessTasks",
                column: "BusinessProcessStateId",
                principalTable: "BusinessProcessStates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_BusinessProcessStates_BusinessProcessStateId",
                table: "BusinessTasks");

            migrationBuilder.DropIndex(
                name: "IX_BusinessTasks_BusinessProcessStateId",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "BusinessProcessStateId",
                table: "BusinessTasks");
        }
    }
}
