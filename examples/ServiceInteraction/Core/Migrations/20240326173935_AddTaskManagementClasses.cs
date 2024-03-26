using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WorkflowLib.Examples.ServiceInteraction.Core.Migrations
{
    public partial class AddTaskManagementClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentTaskId = table.Column<long>(type: "bigint", nullable: false),
                    ExpiredNotificationSent = table.Column<bool>(type: "boolean", nullable: false),
                    IsEmulation = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsEmulation = table.Column<bool>(type: "boolean", nullable: false),
                    ParentInstanceId = table.Column<long>(type: "bigint", nullable: false),
                    BusinessProcessId = table.Column<long>(type: "bigint", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstances_BusinessProcesses_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowInstances_WorkflowInstances_ParentInstanceId",
                        column: x => x.ParentInstanceId,
                        principalTable: "WorkflowInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowTrackingItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkflowInstanceId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveTaskId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowTrackingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowTrackingItems_BusinessTasks_ActiveTaskId",
                        column: x => x.ActiveTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowTrackingItems_WorkflowInstances_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "WorkflowInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ParentTaskId",
                table: "BusinessTasks",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstances_BusinessProcessId",
                table: "WorkflowInstances",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstances_ParentInstanceId",
                table: "WorkflowInstances",
                column: "ParentInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowTrackingItems_ActiveTaskId",
                table: "WorkflowTrackingItems",
                column: "ActiveTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowTrackingItems_WorkflowInstanceId",
                table: "WorkflowTrackingItems",
                column: "WorkflowInstanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkflowTrackingItems");

            migrationBuilder.DropTable(
                name: "BusinessTasks");

            migrationBuilder.DropTable(
                name: "WorkflowInstances");
        }
    }
}
