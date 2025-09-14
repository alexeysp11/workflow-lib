using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Migrations
{
    public partial class UpdateIssue50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_UserAccounts_UserId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Employees_EmployeeId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_OrganizationItems_OrganizationItemId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_UserGroups_UserGroupId",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_EmployeeId",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_OrganizationItemId",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_UserGroupId",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationItems_UserId",
                table: "OrganizationItems");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "OrganizationItemId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrganizationItems");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "OrganizationItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Employees",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeOrganizationItem",
                columns: table => new
                {
                    EmployeesId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationItemsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOrganizationItem", x => new { x.EmployeesId, x.OrganizationItemsId });
                    table.ForeignKey(
                        name: "FK_EmployeeOrganizationItem_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeOrganizationItem_OrganizationItems_OrganizationItem~",
                        column: x => x.OrganizationItemsId,
                        principalTable: "OrganizationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserAccountId = table.Column<long>(type: "bigint", nullable: false),
                    UserGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccountGroups_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccountGroups_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOrganizationItem_OrganizationItemsId",
                table: "EmployeeOrganizationItem",
                column: "OrganizationItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountGroups_UserAccountId",
                table: "UserAccountGroups",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountGroups_UserGroupId",
                table: "UserAccountGroups",
                column: "UserGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeOrganizationItem");

            migrationBuilder.DropTable(
                name: "UserAccountGroups");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "OrganizationItems");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "UserAccounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrganizationItemId",
                table: "UserAccounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserGroupId",
                table: "UserAccounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "OrganizationItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_EmployeeId",
                table: "UserAccounts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_OrganizationItemId",
                table: "UserAccounts",
                column: "OrganizationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserGroupId",
                table: "UserAccounts",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItems_UserId",
                table: "OrganizationItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItems_UserAccounts_UserId",
                table: "OrganizationItems",
                column: "UserId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Employees_EmployeeId",
                table: "UserAccounts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_OrganizationItems_OrganizationItemId",
                table: "UserAccounts",
                column: "OrganizationItemId",
                principalTable: "OrganizationItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_UserGroups_UserGroupId",
                table: "UserAccounts",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");
        }
    }
}
