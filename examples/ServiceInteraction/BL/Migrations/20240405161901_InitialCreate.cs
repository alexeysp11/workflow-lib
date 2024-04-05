using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WorkflowLib.Examples.ServiceInteraction.BL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessProcesses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    VersionNumber = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcesses_BusinessProcesses_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BusinessProcesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DbgLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceName = table.Column<string>(type: "text", nullable: true),
                    SourceDetails = table.Column<string>(type: "text", nullable: true),
                    SourceStatus = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbgLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EndpointTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcessStates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessProcessId = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcessStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcessStates_BusinessProcesses_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsEmulation = table.Column<bool>(type: "boolean", nullable: false),
                    ParentInstanceId = table.Column<long>(type: "bigint", nullable: true),
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Endpoints",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ClassName = table.Column<string>(type: "text", nullable: true),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    Port = table.Column<int>(type: "integer", nullable: true),
                    NetworkAddress = table.Column<string>(type: "text", nullable: true),
                    EndpointTypeId = table.Column<long>(type: "bigint", nullable: true),
                    EndpointDeploymentType = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endpoints_EndpointTypes_EndpointTypeId",
                        column: x => x.EndpointTypeId,
                        principalTable: "EndpointTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcessStateTransitions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessProcessId = table.Column<long>(type: "bigint", nullable: true),
                    FromStateId = table.Column<long>(type: "bigint", nullable: true),
                    ToStateId = table.Column<long>(type: "bigint", nullable: true),
                    PreviousId = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcessStateTransitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcessStateTransitions_BusinessProcesses_BusinessP~",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessProcessStateTransitions_BusinessProcessStates_FromS~",
                        column: x => x.FromStateId,
                        principalTable: "BusinessProcessStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessProcessStateTransitions_BusinessProcessStates_ToSta~",
                        column: x => x.ToStateId,
                        principalTable: "BusinessProcessStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessProcessStateTransitions_BusinessProcessStateTransit~",
                        column: x => x.PreviousId,
                        principalTable: "BusinessProcessStateTransitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    ExpiredNotificationSent = table.Column<bool>(type: "boolean", nullable: false),
                    IsEmulation = table.Column<bool>(type: "boolean", nullable: false),
                    ParentTaskId = table.Column<long>(type: "bigint", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    BusinessProcessStateId = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_BusinessTasks_BusinessProcessStates_BusinessProcessStateId",
                        column: x => x.BusinessProcessStateId,
                        principalTable: "BusinessProcessStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EndpointCalls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EndpointFromId = table.Column<long>(type: "bigint", nullable: true),
                    EndpointToId = table.Column<long>(type: "bigint", nullable: true),
                    EndpointTypeFromId = table.Column<long>(type: "bigint", nullable: true),
                    EndpointTypeToId = table.Column<long>(type: "bigint", nullable: true),
                    EndpointCallType = table.Column<int>(type: "integer", nullable: true),
                    BusinessProcessStateId = table.Column<long>(type: "bigint", nullable: true),
                    BusinessProcessStateTransitionId = table.Column<long>(type: "bigint", nullable: true),
                    ApiMethodName = table.Column<string>(type: "text", nullable: true),
                    MessageBrokerType = table.Column<int>(type: "integer", nullable: true),
                    QueueName = table.Column<string>(type: "text", nullable: true),
                    TimeoutLimit = table.Column<int>(type: "integer", nullable: true),
                    AttemptsLimit = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndpointCalls_BusinessProcessStates_BusinessProcessStateId",
                        column: x => x.BusinessProcessStateId,
                        principalTable: "BusinessProcessStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EndpointCalls_BusinessProcessStateTransitions_BusinessProce~",
                        column: x => x.BusinessProcessStateTransitionId,
                        principalTable: "BusinessProcessStateTransitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EndpointCalls_Endpoints_EndpointFromId",
                        column: x => x.EndpointFromId,
                        principalTable: "Endpoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EndpointCalls_Endpoints_EndpointToId",
                        column: x => x.EndpointToId,
                        principalTable: "Endpoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EndpointCalls_EndpointTypes_EndpointTypeFromId",
                        column: x => x.EndpointTypeFromId,
                        principalTable: "EndpointTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EndpointCalls_EndpointTypes_EndpointTypeToId",
                        column: x => x.EndpointTypeToId,
                        principalTable: "EndpointTypes",
                        principalColumn: "Id");
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
                name: "IX_BusinessProcesses_ParentId",
                table: "BusinessProcesses",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessStates_BusinessProcessId",
                table: "BusinessProcessStates",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessStateTransitions_BusinessProcessId",
                table: "BusinessProcessStateTransitions",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessStateTransitions_FromStateId",
                table: "BusinessProcessStateTransitions",
                column: "FromStateId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessStateTransitions_PreviousId",
                table: "BusinessProcessStateTransitions",
                column: "PreviousId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessStateTransitions_ToStateId",
                table: "BusinessProcessStateTransitions",
                column: "ToStateId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_BusinessProcessStateId",
                table: "BusinessTasks",
                column: "BusinessProcessStateId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ParentTaskId",
                table: "BusinessTasks",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointCalls_BusinessProcessStateId",
                table: "EndpointCalls",
                column: "BusinessProcessStateId");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointCalls_BusinessProcessStateTransitionId",
                table: "EndpointCalls",
                column: "BusinessProcessStateTransitionId");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointCalls_EndpointFromId",
                table: "EndpointCalls",
                column: "EndpointFromId");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointCalls_EndpointToId",
                table: "EndpointCalls",
                column: "EndpointToId");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointCalls_EndpointTypeFromId",
                table: "EndpointCalls",
                column: "EndpointTypeFromId");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointCalls_EndpointTypeToId",
                table: "EndpointCalls",
                column: "EndpointTypeToId");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_EndpointTypeId",
                table: "Endpoints",
                column: "EndpointTypeId");

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
                name: "DbgLogs");

            migrationBuilder.DropTable(
                name: "EndpointCalls");

            migrationBuilder.DropTable(
                name: "WorkflowTrackingItems");

            migrationBuilder.DropTable(
                name: "BusinessProcessStateTransitions");

            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "BusinessTasks");

            migrationBuilder.DropTable(
                name: "WorkflowInstances");

            migrationBuilder.DropTable(
                name: "EndpointTypes");

            migrationBuilder.DropTable(
                name: "BusinessProcessStates");

            migrationBuilder.DropTable(
                name: "BusinessProcesses");
        }
    }
}
