using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessDiagram",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDiagram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MobilePhone = table.Column<string>(type: "text", nullable: true),
                    HomePhone = table.Column<string>(type: "text", nullable: true),
                    WorkPhone = table.Column<string>(type: "text", nullable: true),
                    OfficePhone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    OfficeEmail = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractType = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
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
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    MobilePhone = table.Column<string>(type: "text", nullable: true),
                    WorkPhone = table.Column<string>(type: "text", nullable: true),
                    Skype = table.Column<string>(type: "text", nullable: true),
                    ICQ = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReplacementMode = table.Column<int>(type: "integer", nullable: false),
                    AuthProviderType = table.Column<int>(type: "integer", nullable: false),
                    Locale = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
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
                name: "ProjectPlanItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Priority = table.Column<int>(type: "integer", nullable: true),
                    ProjectPlanItemId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlanItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPlanItem_ProjectPlanItem_ProjectPlanItemId",
                        column: x => x.ProjectPlanItemId,
                        principalTable: "ProjectPlanItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessDiagramElement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessDiagramId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDiagramElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessDiagramElement_BusinessDiagram_BusinessDiagramId",
                        column: x => x.BusinessDiagramId,
                        principalTable: "BusinessDiagram",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcesses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiagramId = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_BusinessProcesses_BusinessDiagram_DiagramId",
                        column: x => x.DiagramId,
                        principalTable: "BusinessDiagram",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessProcesses_BusinessProcesses_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BusinessProcesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    VatNumber = table.Column<string>(type: "text", nullable: false),
                    CRMRoleType = table.Column<int>(type: "integer", nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    ShippingAddress = table.Column<string>(type: "text", nullable: true),
                    HasVatRegistration = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractEmployee",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "bigint", nullable: false),
                    OurEmployeesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEmployee", x => new { x.ContractsId, x.OurEmployeesId });
                    table.ForeignKey(
                        name: "FK_ContractEmployee_Contract_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractEmployee_Employee_OurEmployeesId",
                        column: x => x.OurEmployeesId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
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
                name: "BDEConnector",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartElementId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BDEConnector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BDEConnector_BusinessDiagramElement_StartElementId",
                        column: x => x.StartElementId,
                        principalTable: "BusinessDiagramElement",
                        principalColumn: "Id");
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
                name: "CompanyContract",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerCompaniesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContract", x => new { x.ContractsId, x.CustomerCompaniesId });
                    table.ForeignKey(
                        name: "FK_CompanyContract_Company_CustomerCompaniesId",
                        column: x => x.CustomerCompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyContract_Contract_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyEmployee",
                columns: table => new
                {
                    CompaniesId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployee", x => new { x.CompaniesId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Company_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Employee_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "BPStateEndpointCalls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessProcessStateId = table.Column<long>(type: "bigint", nullable: false),
                    EndpointCallId = table.Column<long>(type: "bigint", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPStateEndpointCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BPStateEndpointCalls_BusinessProcessStates_BusinessProcessS~",
                        column: x => x.BusinessProcessStateId,
                        principalTable: "BusinessProcessStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BPStateEndpointCalls_EndpointCalls_EndpointCallId",
                        column: x => x.EndpointCallId,
                        principalTable: "EndpointCalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    EndpointCallId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_BusinessProcessStateTransitions_EndpointCalls_EndpointCallId",
                        column: x => x.EndpointCallId,
                        principalTable: "EndpointCalls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    ParentTaskId = table.Column<long>(type: "bigint", nullable: true),
                    ActualDateTimeBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualDateTimeEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedDateTimeBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedDateTimeEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExecutorId = table.Column<long>(type: "bigint", nullable: true),
                    ExecutorIsEmulationId = table.Column<long>(type: "bigint", nullable: true),
                    ExecutorReplacedId = table.Column<long>(type: "bigint", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    BusinessProcessStateId = table.Column<long>(type: "bigint", nullable: true),
                    ExpiredNotificationSent = table.Column<bool>(type: "boolean", nullable: false),
                    IsEmulation = table.Column<bool>(type: "boolean", nullable: false),
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
                name: "ContractCustomer",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "bigint", nullable: false),
                    CustomersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCustomer", x => new { x.ContractsId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_ContractCustomer_Contract_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractOrganization",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "bigint", nullable: false),
                    OurOrganizationsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractOrganization", x => new { x.ContractsId, x.OurOrganizationsId });
                    table.ForeignKey(
                        name: "FK_ContractOrganization_Contract_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    CRMRoleType = table.Column<int>(type: "integer", nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    UserAccountId = table.Column<long>(type: "bigint", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GuaranteePeriodInMonths = table.Column<int>(type: "integer", nullable: false),
                    ManagerId = table.Column<long>(type: "bigint", nullable: false),
                    CompletePercent = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPhase",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectPlanItemId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPhase_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectPhase_ProjectPlanItem_ProjectPlanItemId",
                        column: x => x.ProjectPlanItemId,
                        principalTable: "ProjectPlanItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationAuthorId = table.Column<long>(type: "bigint", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChangeAuthorId = table.Column<long>(type: "bigint", nullable: false),
                    ResolvingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResolvingAuthorId = table.Column<long>(type: "bigint", nullable: false),
                    ResolvingComment = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    BusinessTaskId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Risk_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Employee_ChangeAuthorId",
                        column: x => x.ChangeAuthorId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Risk_Employee_CreationAuthorId",
                        column: x => x.CreationAuthorId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Risk_Employee_ResolvingAuthorId",
                        column: x => x.ResolvingAuthorId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Risk_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    HeadItemId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemType = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    HardDelete = table.Column<bool>(type: "boolean", nullable: false),
                    ParentItemId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationItem_OrganizationItem_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "OrganizationItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LastSeenDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizationItemId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccount_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccount_OrganizationItem_OrganizationItemId",
                        column: x => x.OrganizationItemId,
                        principalTable: "OrganizationItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessProcessId = table.Column<long>(type: "bigint", nullable: false),
                    ActualDateTimeBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualDateTimeEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedDateTimeBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedDateTimeEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InitiatorId = table.Column<long>(type: "bigint", nullable: true),
                    IsEmulation = table.Column<bool>(type: "boolean", nullable: false),
                    ParentInstanceId = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_WorkflowInstances_UserAccount_InitiatorId",
                        column: x => x.InitiatorId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowInstances_WorkflowInstances_ParentInstanceId",
                        column: x => x.ParentInstanceId,
                        principalTable: "WorkflowInstances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationAuthorId = table.Column<long>(type: "bigint", nullable: false),
                    BusinessTaskId = table.Column<long>(type: "bigint", nullable: true),
                    WorkflowInstanceId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_UserAccount_CreationAuthorId",
                        column: x => x.CreationAuthorId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_WorkflowInstances_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "WorkflowInstances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstanceId = table.Column<long>(type: "bigint", nullable: true),
                    UserAccountId = table.Column<long>(type: "bigint", nullable: true),
                    BusinessTaskId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceMember_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceMember_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceMember_WorkflowInstances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "WorkflowInstances",
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
                    BDEConnectorId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CommentId = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_WorkflowTrackingItems_BDEConnector_BDEConnectorId",
                        column: x => x.BDEConnectorId,
                        principalTable: "BDEConnector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowTrackingItems_BusinessTasks_ActiveTaskId",
                        column: x => x.ActiveTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowTrackingItems_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowTrackingItems_WorkflowInstances_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "WorkflowInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BDEConnector_StartElementId",
                table: "BDEConnector",
                column: "StartElementId");

            migrationBuilder.CreateIndex(
                name: "IX_BPStateEndpointCalls_BusinessProcessStateId",
                table: "BPStateEndpointCalls",
                column: "BusinessProcessStateId");

            migrationBuilder.CreateIndex(
                name: "IX_BPStateEndpointCalls_EndpointCallId",
                table: "BPStateEndpointCalls",
                column: "EndpointCallId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDiagramElement_BusinessDiagramId",
                table: "BusinessDiagramElement",
                column: "BusinessDiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcesses_DiagramId",
                table: "BusinessProcesses",
                column: "DiagramId");

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
                name: "IX_BusinessProcessStateTransitions_EndpointCallId",
                table: "BusinessProcessStateTransitions",
                column: "EndpointCallId");

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
                name: "IX_BusinessTasks_ExecutorId",
                table: "BusinessTasks",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ExecutorIsEmulationId",
                table: "BusinessTasks",
                column: "ExecutorIsEmulationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ExecutorReplacedId",
                table: "BusinessTasks",
                column: "ExecutorReplacedId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ParentTaskId",
                table: "BusinessTasks",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BusinessTaskId",
                table: "Comment",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreationAuthorId",
                table: "Comment",
                column: "CreationAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_WorkflowInstanceId",
                table: "Comment",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ContactId",
                table: "Company",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContract_CustomerCompaniesId",
                table: "CompanyContract",
                column: "CustomerCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_EmployeesId",
                table: "CompanyEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCustomer_CustomersId",
                table: "ContractCustomer",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractEmployee_OurEmployeesId",
                table: "ContractEmployee",
                column: "OurEmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractOrganization_OurOrganizationsId",
                table: "ContractOrganization",
                column: "OurOrganizationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CompanyId",
                table: "Customer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ContactId",
                table: "Customer",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserAccountId",
                table: "Customer",
                column: "UserAccountId");

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
                name: "IX_Organization_CompanyId",
                table: "Organization",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_HeadItemId",
                table: "Organization",
                column: "HeadItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItem_ParentItemId",
                table: "OrganizationItem",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItem_UserId",
                table: "OrganizationItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ContractId",
                table: "Project",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerId",
                table: "Project",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerId",
                table: "Project",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhase_ProjectId",
                table: "ProjectPhase",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhase_ProjectPlanItemId",
                table: "ProjectPhase",
                column: "ProjectPlanItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlanItem_ProjectPlanItemId",
                table: "ProjectPlanItem",
                column: "ProjectPlanItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_BusinessTaskId",
                table: "Risk",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_ChangeAuthorId",
                table: "Risk",
                column: "ChangeAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_CreationAuthorId",
                table: "Risk",
                column: "CreationAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_ProjectId",
                table: "Risk",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_ResolvingAuthorId",
                table: "Risk",
                column: "ResolvingAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_EmployeeId",
                table: "Skill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_EmployeeId",
                table: "UserAccount",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_OrganizationItemId",
                table: "UserAccount",
                column: "OrganizationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceMember_BusinessTaskId",
                table: "WorkflowInstanceMember",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceMember_InstanceId",
                table: "WorkflowInstanceMember",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceMember_UserAccountId",
                table: "WorkflowInstanceMember",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstances_BusinessProcessId",
                table: "WorkflowInstances",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstances_InitiatorId",
                table: "WorkflowInstances",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstances_ParentInstanceId",
                table: "WorkflowInstances",
                column: "ParentInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowTrackingItems_ActiveTaskId",
                table: "WorkflowTrackingItems",
                column: "ActiveTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowTrackingItems_BDEConnectorId",
                table: "WorkflowTrackingItems",
                column: "BDEConnectorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowTrackingItems_CommentId",
                table: "WorkflowTrackingItems",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowTrackingItems_WorkflowInstanceId",
                table: "WorkflowTrackingItems",
                column: "WorkflowInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_UserAccount_ExecutorId",
                table: "BusinessTasks",
                column: "ExecutorId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_UserAccount_ExecutorIsEmulationId",
                table: "BusinessTasks",
                column: "ExecutorIsEmulationId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_UserAccount_ExecutorReplacedId",
                table: "BusinessTasks",
                column: "ExecutorReplacedId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractCustomer_Customer_CustomersId",
                table: "ContractCustomer",
                column: "CustomersId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractOrganization_Organization_OurOrganizationsId",
                table: "ContractOrganization",
                column: "OurOrganizationsId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_UserAccount_UserAccountId",
                table: "Customer",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_OrganizationItem_HeadItemId",
                table: "Organization",
                column: "HeadItemId",
                principalTable: "OrganizationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_UserAccount_UserId",
                table: "OrganizationItem",
                column: "UserId",
                principalTable: "UserAccount",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_UserAccount_UserId",
                table: "OrganizationItem");

            migrationBuilder.DropTable(
                name: "BPStateEndpointCalls");

            migrationBuilder.DropTable(
                name: "BusinessProcessStateTransitions");

            migrationBuilder.DropTable(
                name: "CompanyContract");

            migrationBuilder.DropTable(
                name: "CompanyEmployee");

            migrationBuilder.DropTable(
                name: "ContractCustomer");

            migrationBuilder.DropTable(
                name: "ContractEmployee");

            migrationBuilder.DropTable(
                name: "ContractOrganization");

            migrationBuilder.DropTable(
                name: "DbgLogs");

            migrationBuilder.DropTable(
                name: "ProjectPhase");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceMember");

            migrationBuilder.DropTable(
                name: "WorkflowTrackingItems");

            migrationBuilder.DropTable(
                name: "EndpointCalls");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "ProjectPlanItem");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "BDEConnector");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "BusinessDiagramElement");

            migrationBuilder.DropTable(
                name: "BusinessTasks");

            migrationBuilder.DropTable(
                name: "WorkflowInstances");

            migrationBuilder.DropTable(
                name: "EndpointTypes");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "BusinessProcessStates");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "BusinessProcesses");

            migrationBuilder.DropTable(
                name: "BusinessDiagram");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "OrganizationItem");
        }
    }
}
