using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class AddUserAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_UserAccount_ExecutorId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_UserAccount_ExecutorIsEmulationId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_UserAccount_ExecutorReplacedId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_UserAccount_CreationAuthorId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_UserAccount_UserAccountId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_UserAccount_UserId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_UserGroup_UserGroupId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Employee_EmployeeId",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_OrganizationItem_OrganizationItemId",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_UserGroup_UserGroupId",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Employee_EmployeeId",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_UserAccount_ChangeAuthorId",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_UserAccount_CreationAuthorId",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount");

            migrationBuilder.RenameTable(
                name: "UserGroup",
                newName: "UserGroups");

            migrationBuilder.RenameTable(
                name: "UserAccount",
                newName: "UserAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_EmployeeId",
                table: "UserGroups",
                newName: "IX_UserGroups_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_CreationAuthorId",
                table: "UserGroups",
                newName: "IX_UserGroups_CreationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_ChangeAuthorId",
                table: "UserGroups",
                newName: "IX_UserGroups_ChangeAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_UserGroupId",
                table: "UserAccounts",
                newName: "IX_UserAccounts_UserGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_OrganizationItemId",
                table: "UserAccounts",
                newName: "IX_UserAccounts_OrganizationItemId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_EmployeeId",
                table: "UserAccounts",
                newName: "IX_UserAccounts_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorId",
                table: "BusinessTask",
                column: "ExecutorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorIsEmulationId",
                table: "BusinessTask",
                column: "ExecutorIsEmulationId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorReplacedId",
                table: "BusinessTask",
                column: "ExecutorReplacedId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_UserAccounts_CreationAuthorId",
                table: "Comment",
                column: "CreationAuthorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_UserAccounts_UserAccountId",
                table: "Customer",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_UserAccounts_UserId",
                table: "OrganizationItem",
                column: "UserId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_UserGroups_UserGroupId",
                table: "OrganizationItem",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Employee_EmployeeId",
                table: "UserAccounts",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_OrganizationItem_OrganizationItemId",
                table: "UserAccounts",
                column: "OrganizationItemId",
                principalTable: "OrganizationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_UserGroups_UserGroupId",
                table: "UserAccounts",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Employee_EmployeeId",
                table: "UserGroups",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_UserAccounts_ChangeAuthorId",
                table: "UserGroups",
                column: "ChangeAuthorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_UserAccounts_CreationAuthorId",
                table: "UserGroups",
                column: "CreationAuthorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorIsEmulationId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorReplacedId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_UserAccounts_CreationAuthorId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_UserAccounts_UserAccountId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_UserAccounts_UserId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_UserGroups_UserGroupId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Employee_EmployeeId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_OrganizationItem_OrganizationItemId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_UserGroups_UserGroupId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Employee_EmployeeId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_ChangeAuthorId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_CreationAuthorId",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "UserGroup");

            migrationBuilder.RenameTable(
                name: "UserAccounts",
                newName: "UserAccount");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_EmployeeId",
                table: "UserGroup",
                newName: "IX_UserGroup_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_CreationAuthorId",
                table: "UserGroup",
                newName: "IX_UserGroup_CreationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_ChangeAuthorId",
                table: "UserGroup",
                newName: "IX_UserGroup_ChangeAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccounts_UserGroupId",
                table: "UserAccount",
                newName: "IX_UserAccount_UserGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccounts_OrganizationItemId",
                table: "UserAccount",
                newName: "IX_UserAccount_OrganizationItemId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccounts_EmployeeId",
                table: "UserAccount",
                newName: "IX_UserAccount_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_UserAccount_ExecutorId",
                table: "BusinessTask",
                column: "ExecutorId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_UserAccount_ExecutorIsEmulationId",
                table: "BusinessTask",
                column: "ExecutorIsEmulationId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_UserAccount_ExecutorReplacedId",
                table: "BusinessTask",
                column: "ExecutorReplacedId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_UserAccount_CreationAuthorId",
                table: "Comment",
                column: "CreationAuthorId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_UserAccount_UserAccountId",
                table: "Customer",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_UserAccount_UserId",
                table: "OrganizationItem",
                column: "UserId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_UserGroup_UserGroupId",
                table: "OrganizationItem",
                column: "UserGroupId",
                principalTable: "UserGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_Employee_EmployeeId",
                table: "UserAccount",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_OrganizationItem_OrganizationItemId",
                table: "UserAccount",
                column: "OrganizationItemId",
                principalTable: "OrganizationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_UserGroup_UserGroupId",
                table: "UserAccount",
                column: "UserGroupId",
                principalTable: "UserGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Employee_EmployeeId",
                table: "UserGroup",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_UserAccount_ChangeAuthorId",
                table: "UserGroup",
                column: "ChangeAuthorId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_UserAccount_CreationAuthorId",
                table: "UserGroup",
                column: "CreationAuthorId",
                principalTable: "UserAccount",
                principalColumn: "Id");
        }
    }
}
