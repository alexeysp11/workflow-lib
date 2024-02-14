using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WorkflowLib.Examples.ServiceInteraction.Core.Migrations
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
                name: "Endpoints",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    Port = table.Column<int>(type: "integer", nullable: true),
                    NetworkAddress = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    EndpointTypeId = table.Column<long>(type: "bigint", nullable: true),
                    EndpointDeploymentType = table.Column<int>(type: "integer", nullable: true)
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
                name: "IX_BusinessProcessStateTransitions_ToStateId",
                table: "BusinessProcessStateTransitions",
                column: "ToStateId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbgLogs");

            migrationBuilder.DropTable(
                name: "EndpointCalls");

            migrationBuilder.DropTable(
                name: "BusinessProcessStateTransitions");

            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "BusinessProcessStates");

            migrationBuilder.DropTable(
                name: "EndpointTypes");

            migrationBuilder.DropTable(
                name: "BusinessProcesses");
        }
    }
}
