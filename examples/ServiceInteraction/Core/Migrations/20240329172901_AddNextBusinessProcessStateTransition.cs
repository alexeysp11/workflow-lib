using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Examples.ServiceInteraction.Core.Migrations
{
    public partial class AddNextBusinessProcessStateTransition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NextId",
                table: "BusinessProcessStateTransitions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessStateTransitions_NextId",
                table: "BusinessProcessStateTransitions",
                column: "NextId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProcessStateTransitions_BusinessProcessStateTransit~",
                table: "BusinessProcessStateTransitions",
                column: "NextId",
                principalTable: "BusinessProcessStateTransitions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProcessStateTransitions_BusinessProcessStateTransit~",
                table: "BusinessProcessStateTransitions");

            migrationBuilder.DropIndex(
                name: "IX_BusinessProcessStateTransitions_NextId",
                table: "BusinessProcessStateTransitions");

            migrationBuilder.DropColumn(
                name: "NextId",
                table: "BusinessProcessStateTransitions");
        }
    }
}
