using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Examples.ServiceInteraction.Core.Migrations
{
    public partial class AddedEndpointClassName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Endpoints",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Endpoints");
        }
    }
}
