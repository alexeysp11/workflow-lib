using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Examples.Delivering.Example01.Migrations
{
    public partial class NullableStringFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserAccounts_CreationAuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_ChangeAuthorId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_CreationAuthorId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_ResolvingAuthorId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_ChangeAuthorId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_CreationAuthorId",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "ResolvingComment",
                table: "Risk");

            migrationBuilder.RenameColumn(
                name: "CreationAuthorId",
                table: "UserGroups",
                newName: "AuthorCreatedId");

            migrationBuilder.RenameColumn(
                name: "ChangeAuthorId",
                table: "UserGroups",
                newName: "AuthorChangedId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_CreationAuthorId",
                table: "UserGroups",
                newName: "IX_UserGroups_AuthorCreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_ChangeAuthorId",
                table: "UserGroups",
                newName: "IX_UserGroups_AuthorChangedId");

            migrationBuilder.RenameColumn(
                name: "ResolvingDate",
                table: "Risk",
                newName: "DateResolved");

            migrationBuilder.RenameColumn(
                name: "ResolvingAuthorId",
                table: "Risk",
                newName: "AuthorResolvedId");

            migrationBuilder.RenameColumn(
                name: "CreationAuthorId",
                table: "Risk",
                newName: "AuthorCreatedId");

            migrationBuilder.RenameColumn(
                name: "ChangeAuthorId",
                table: "Risk",
                newName: "AuthorChangedId");

            migrationBuilder.RenameIndex(
                name: "IX_Risk_ResolvingAuthorId",
                table: "Risk",
                newName: "IX_Risk_AuthorResolvedId");

            migrationBuilder.RenameIndex(
                name: "IX_Risk_CreationAuthorId",
                table: "Risk",
                newName: "IX_Risk_AuthorCreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Risk_ChangeAuthorId",
                table: "Risk",
                newName: "IX_Risk_AuthorChangedId");

            migrationBuilder.RenameColumn(
                name: "CreationAuthorId",
                table: "Comments",
                newName: "AuthorCreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CreationAuthorId",
                table: "Comments",
                newName: "IX_Comments_AuthorCreatedId");

            migrationBuilder.AddColumn<string>(
                name: "CommentResolved",
                table: "Risk",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TitleText",
                table: "Notifications",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Customers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                table: "Companies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Companies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "BusinessTaskDeliveryOrders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserAccounts_AuthorCreatedId",
                table: "Comments",
                column: "AuthorCreatedId",
                principalTable: "UserAccounts",
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

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_UserAccounts_AuthorChangedId",
                table: "UserGroups",
                column: "AuthorChangedId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_UserAccounts_AuthorCreatedId",
                table: "UserGroups",
                column: "AuthorCreatedId",
                principalTable: "UserAccounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserAccounts_AuthorCreatedId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_AuthorChangedId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_AuthorCreatedId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_AuthorResolvedId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_AuthorChangedId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_AuthorCreatedId",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "CommentResolved",
                table: "Risk");

            migrationBuilder.RenameColumn(
                name: "AuthorCreatedId",
                table: "UserGroups",
                newName: "CreationAuthorId");

            migrationBuilder.RenameColumn(
                name: "AuthorChangedId",
                table: "UserGroups",
                newName: "ChangeAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_AuthorCreatedId",
                table: "UserGroups",
                newName: "IX_UserGroups_CreationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_AuthorChangedId",
                table: "UserGroups",
                newName: "IX_UserGroups_ChangeAuthorId");

            migrationBuilder.RenameColumn(
                name: "DateResolved",
                table: "Risk",
                newName: "ResolvingDate");

            migrationBuilder.RenameColumn(
                name: "AuthorResolvedId",
                table: "Risk",
                newName: "ResolvingAuthorId");

            migrationBuilder.RenameColumn(
                name: "AuthorCreatedId",
                table: "Risk",
                newName: "CreationAuthorId");

            migrationBuilder.RenameColumn(
                name: "AuthorChangedId",
                table: "Risk",
                newName: "ChangeAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Risk_AuthorResolvedId",
                table: "Risk",
                newName: "IX_Risk_ResolvingAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Risk_AuthorCreatedId",
                table: "Risk",
                newName: "IX_Risk_CreationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Risk_AuthorChangedId",
                table: "Risk",
                newName: "IX_Risk_ChangeAuthorId");

            migrationBuilder.RenameColumn(
                name: "AuthorCreatedId",
                table: "Comments",
                newName: "CreationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorCreatedId",
                table: "Comments",
                newName: "IX_Comments_CreationAuthorId");

            migrationBuilder.AddColumn<string>(
                name: "ResolvingComment",
                table: "Risk",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TitleText",
                table: "Notifications",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                table: "Companies",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Companies",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "BusinessTaskDeliveryOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserAccounts_CreationAuthorId",
                table: "Comments",
                column: "CreationAuthorId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_ChangeAuthorId",
                table: "Risk",
                column: "ChangeAuthorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_CreationAuthorId",
                table: "Risk",
                column: "CreationAuthorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_ResolvingAuthorId",
                table: "Risk",
                column: "ResolvingAuthorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
