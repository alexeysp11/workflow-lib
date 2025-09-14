using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Migrations
{
    public partial class RenameCrmRoleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Companies_CompanyId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Customers_CustomerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employees_ManagerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_AuthorChangedId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_AuthorCreatedId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_AuthorResolvedId",
                table: "Risk");

            migrationBuilder.RenameColumn(
                name: "CRMRoleType",
                table: "Customers",
                newName: "CrmRoleType");

            migrationBuilder.RenameColumn(
                name: "CRMRoleType",
                table: "Companies",
                newName: "CrmRoleType");

            migrationBuilder.AlterColumn<long>(
                name: "AuthorResolvedId",
                table: "Risk",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AuthorCreatedId",
                table: "Risk",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AuthorChangedId",
                table: "Risk",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ManagerId",
                table: "Project",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "Project",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Project",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Companies_CompanyId",
                table: "Project",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customers_CustomerId",
                table: "Project",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employees_ManagerId",
                table: "Project",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_AuthorChangedId",
                table: "Risk",
                column: "AuthorChangedId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_AuthorCreatedId",
                table: "Risk",
                column: "AuthorCreatedId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_AuthorResolvedId",
                table: "Risk",
                column: "AuthorResolvedId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Companies_CompanyId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Customers_CustomerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employees_ManagerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_AuthorChangedId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_AuthorCreatedId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_AuthorResolvedId",
                table: "Risk");

            migrationBuilder.RenameColumn(
                name: "CrmRoleType",
                table: "Customers",
                newName: "CRMRoleType");

            migrationBuilder.RenameColumn(
                name: "CrmRoleType",
                table: "Companies",
                newName: "CRMRoleType");

            migrationBuilder.AlterColumn<long>(
                name: "AuthorResolvedId",
                table: "Risk",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorCreatedId",
                table: "Risk",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorChangedId",
                table: "Risk",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ManagerId",
                table: "Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Companies_CompanyId",
                table: "Project",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customers_CustomerId",
                table: "Project",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employees_ManagerId",
                table: "Project",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_AuthorChangedId",
                table: "Risk",
                column: "AuthorChangedId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_AuthorCreatedId",
                table: "Risk",
                column: "AuthorCreatedId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_AuthorResolvedId",
                table: "Risk",
                column: "AuthorResolvedId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
