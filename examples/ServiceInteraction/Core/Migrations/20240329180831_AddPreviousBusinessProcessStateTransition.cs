using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Examples.ServiceInteraction.Core.Migrations
{
    public partial class AddPreviousBusinessProcessStateTransition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NextId",
                table: "BusinessProcessStateTransitions",
                newName: "PreviousId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProcessStateTransitions_NextId",
                table: "BusinessProcessStateTransitions",
                newName: "IX_BusinessProcessStateTransitions_PreviousId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviousId",
                table: "BusinessProcessStateTransitions",
                newName: "NextId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProcessStateTransitions_PreviousId",
                table: "BusinessProcessStateTransitions",
                newName: "IX_BusinessProcessStateTransitions_NextId");
        }
    }
}
