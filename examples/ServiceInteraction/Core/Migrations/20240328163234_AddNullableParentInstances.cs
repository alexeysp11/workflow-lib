using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Examples.ServiceInteraction.Core.Migrations
{
    public partial class AddNullableParentInstances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowInstances_WorkflowInstances_ParentInstanceId",
                table: "WorkflowInstances");

            migrationBuilder.AlterColumn<long>(
                name: "ParentInstanceId",
                table: "WorkflowInstances",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ParentTaskId",
                table: "BusinessTasks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                table: "BusinessTasks",
                column: "ParentTaskId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowInstances_WorkflowInstances_ParentInstanceId",
                table: "WorkflowInstances",
                column: "ParentInstanceId",
                principalTable: "WorkflowInstances",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowInstances_WorkflowInstances_ParentInstanceId",
                table: "WorkflowInstances");

            migrationBuilder.AlterColumn<long>(
                name: "ParentInstanceId",
                table: "WorkflowInstances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ParentTaskId",
                table: "BusinessTasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                table: "BusinessTasks",
                column: "ParentTaskId",
                principalTable: "BusinessTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowInstances_WorkflowInstances_ParentInstanceId",
                table: "WorkflowInstances",
                column: "ParentInstanceId",
                principalTable: "WorkflowInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
