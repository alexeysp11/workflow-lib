using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.UnifiedBusinessPlatform.Core.Migrations
{
    public partial class AddedOrganizationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "OrganizationItems",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "OrganizationItems");
        }
    }
}
