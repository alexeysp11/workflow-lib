using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdditionalInfo = table.Column<string>(type: "TEXT", nullable: true),
                    RoomNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Floor = table.Column<int>(type: "INTEGER", nullable: false),
                    StreetNumber = table.Column<string>(type: "TEXT", nullable: true),
                    StreetName = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    CountryProvince = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MobilePhone = table.Column<string>(type: "TEXT", nullable: true),
                    HomePhone = table.Column<string>(type: "TEXT", nullable: true),
                    WorkPhone = table.Column<string>(type: "TEXT", nullable: true),
                    OfficePhone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    OfficeEmail = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractType = table.Column<int>(type: "INTEGER", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    MobilePhone = table.Column<string>(type: "TEXT", nullable: true),
                    WorkPhone = table.Column<string>(type: "TEXT", nullable: true),
                    Skype = table.Column<string>(type: "TEXT", nullable: true),
                    ICQ = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReplacementMode = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthProviderType = table.Column<int>(type: "INTEGER", nullable: false),
                    Locale = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionTime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTimeBegin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InitialOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserUid = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentType = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SenderId = table.Column<long>(type: "INTEGER", nullable: false),
                    ReceiverId = table.Column<long>(type: "INTEGER", nullable: false),
                    TitleText = table.Column<string>(type: "TEXT", nullable: true),
                    BodyText = table.Column<string>(type: "TEXT", nullable: true),
                    SentDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReceivedDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PictureDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPlanItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectPlanItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegistrationNumber = table.Column<string>(type: "TEXT", nullable: true),
                    VatNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CRMRoleType = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactId = table.Column<long>(type: "INTEGER", nullable: true),
                    AddressId = table.Column<long>(type: "INTEGER", nullable: true),
                    ShippingAddressId = table.Column<long>(type: "INTEGER", nullable: true),
                    HasVatRegistration = table.Column<bool>(type: "INTEGER", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractEmployee",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "INTEGER", nullable: false),
                    OurEmployeesId = table.Column<long>(type: "INTEGER", nullable: false)
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
                        name: "FK_ContractEmployee_Employees_OurEmployeesId",
                        column: x => x.OurEmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCategoryId = table.Column<long>(type: "INTEGER", nullable: true),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PictureDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyContract",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "INTEGER", nullable: false),
                    CustomerCompaniesId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContract", x => new { x.ContractsId, x.CustomerCompaniesId });
                    table.ForeignKey(
                        name: "FK_CompanyContract_Companies_CustomerCompaniesId",
                        column: x => x.CustomerCompaniesId,
                        principalTable: "Companies",
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
                    CompaniesId = table.Column<long>(type: "INTEGER", nullable: false),
                    EmployeesId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployee", x => new { x.CompaniesId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InitialOrderProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: false),
                    InitialOrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_InitialOrders_InitialOrderId",
                        column: x => x.InitialOrderId,
                        principalTable: "InitialOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    Instruction = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WHProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    MinQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WHProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    FinalProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    IngredientId = table.Column<long>(type: "INTEGER", nullable: true),
                    RecipeId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredients_Products_FinalProductId",
                        column: x => x.FinalProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredients_Products_IngredientProductId",
                        column: x => x.IngredientProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractCustomer",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "INTEGER", nullable: false),
                    CustomersId = table.Column<long>(type: "INTEGER", nullable: false)
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
                    ContractsId = table.Column<long>(type: "INTEGER", nullable: false),
                    OurOrganizationsId = table.Column<long>(type: "INTEGER", nullable: false)
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    CRMRoleType = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactId = table.Column<long>(type: "INTEGER", nullable: true),
                    UserAccountId = table.Column<long>(type: "INTEGER", nullable: true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ContractId = table.Column<long>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<long>(type: "INTEGER", nullable: true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true),
                    CustomerId = table.Column<long>(type: "INTEGER", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GuaranteePeriodInMonths = table.Column<int>(type: "INTEGER", nullable: false),
                    ManagerId = table.Column<long>(type: "INTEGER", nullable: true),
                    CompletePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Addresses_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectPhase",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProjectPlanItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "DeliveryOrderProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeliveryMethodId = table.Column<long>(type: "INTEGER", nullable: true),
                    DeliveryOperationId = table.Column<long>(type: "INTEGER", nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    OriginId = table.Column<long>(type: "INTEGER", nullable: true),
                    DestinationId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    OpenOrderDt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CloseOrderDt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerUid = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyUid = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    ProductsPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    AdditonalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    TaxPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    CouldBeCancelled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_Addresses_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_Addresses_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Payer = table.Column<string>(type: "TEXT", nullable: true),
                    Receiver = table.Column<string>(type: "TEXT", nullable: true),
                    CardNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentType = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_DeliveryOrders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "DeliveryOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParentTaskId = table.Column<long>(type: "INTEGER", nullable: true),
                    ActualExecutionTimeId = table.Column<long>(type: "INTEGER", nullable: true),
                    EstimatedExecutionTimeId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExecutorId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExecutorIsEmulationId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExecutorReplacedId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExpiredNotificationSent = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsEmulation = table.Column<bool>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryMethodId = table.Column<long>(type: "INTEGER", nullable: true),
                    OriginId = table.Column<long>(type: "INTEGER", nullable: true),
                    DestinationId = table.Column<long>(type: "INTEGER", nullable: true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true),
                    ContactId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTasks_Addresses_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_Addresses_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_DeliveryOrders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "DeliveryOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_ExecutionTime_ActualExecutionTimeId",
                        column: x => x.ActualExecutionTimeId,
                        principalTable: "ExecutionTime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_ExecutionTime_EstimatedExecutionTimeId",
                        column: x => x.EstimatedExecutionTimeId,
                        principalTable: "ExecutionTime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Severity = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreationAuthorId = table.Column<long>(type: "INTEGER", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ChangeAuthorId = table.Column<long>(type: "INTEGER", nullable: true),
                    ResolvingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResolvingAuthorId = table.Column<long>(type: "INTEGER", nullable: true),
                    ResolvingComment = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    BusinessTaskId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
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
                        name: "FK_Risk_Employees_ChangeAuthorId",
                        column: x => x.ChangeAuthorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Employees_CreationAuthorId",
                        column: x => x.CreationAuthorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Employees_ResolvingAuthorId",
                        column: x => x.ResolvingAuthorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreationAuthorId = table.Column<long>(type: "INTEGER", nullable: true),
                    BusinessTaskId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemType = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    HardDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParentItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: true),
                    AddressId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationItems_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationItems_OrganizationItems_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "OrganizationItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true),
                    HeadItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_OrganizationItems_HeadItemId",
                        column: x => x.HeadItemId,
                        principalTable: "OrganizationItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Photo = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    LastSeenDt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrganizationItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    UserGroupId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccounts_OrganizationItems_OrganizationItemId",
                        column: x => x.OrganizationItemId,
                        principalTable: "OrganizationItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsGroupByDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationAuthorId = table.Column<long>(type: "INTEGER", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ChangeAuthorId = table.Column<long>(type: "INTEGER", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_UserAccounts_ChangeAuthorId",
                        column: x => x.ChangeAuthorId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroups_UserAccounts_CreationAuthorId",
                        column: x => x.CreationAuthorId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ActualExecutionTimeId",
                table: "BusinessTasks",
                column: "ActualExecutionTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ContactId",
                table: "BusinessTasks",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_DeliveryMethodId",
                table: "BusinessTasks",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_DeliveryOrderId",
                table: "BusinessTasks",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_DestinationId",
                table: "BusinessTasks",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_EstimatedExecutionTimeId",
                table: "BusinessTasks",
                column: "EstimatedExecutionTimeId");

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
                name: "IX_BusinessTasks_OriginId",
                table: "BusinessTasks",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ParentTaskId",
                table: "BusinessTasks",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BusinessTaskId",
                table: "Comments",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreationAuthorId",
                table: "Comments",
                column: "CreationAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ContactId",
                table: "Companies",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ShippingAddressId",
                table: "Companies",
                column: "ShippingAddressId");

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
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactId",
                table: "Customers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserAccountId",
                table: "Customers",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderProducts_DeliveryOrderId",
                table: "DeliveryOrderProducts",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderProducts_ProductId",
                table: "DeliveryOrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_DeliveryMethodId",
                table: "DeliveryOrders",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_DeliveryOperationId",
                table: "DeliveryOrders",
                column: "DeliveryOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_DestinationId",
                table: "DeliveryOrders",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_OriginId",
                table: "DeliveryOrders",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FinalProductId",
                table: "Ingredients",
                column: "FinalProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientId",
                table: "Ingredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientProductId",
                table: "Ingredients",
                column: "IngredientProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_InitialOrderId",
                table: "InitialOrderProducts",
                column: "InitialOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_ProductId",
                table: "InitialOrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItems_AddressId",
                table: "OrganizationItems",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItems_ParentItemId",
                table: "OrganizationItems",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItems_UserId",
                table: "OrganizationItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CompanyId",
                table: "Organizations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_HeadItemId",
                table: "Organizations",
                column: "HeadItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DeliveryOrderId",
                table: "Payments",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

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
                name: "IX_Project_LocationId",
                table: "Project",
                column: "LocationId");

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
                name: "IX_Recipes_ProductId",
                table: "Recipes",
                column: "ProductId");

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
                name: "IX_UserGroups_ChangeAuthorId",
                table: "UserGroups",
                column: "ChangeAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_CreationAuthorId",
                table: "UserGroups",
                column: "CreationAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_WHProducts_ProductId",
                table: "WHProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractCustomer_Customers_CustomersId",
                table: "ContractCustomer",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractOrganization_Organizations_OurOrganizationsId",
                table: "ContractOrganization",
                column: "OurOrganizationsId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_UserAccounts_UserAccountId",
                table: "Customers",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrderProducts_DeliveryOrders_DeliveryOrderId",
                table: "DeliveryOrderProducts",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_BusinessTasks_DeliveryOperationId",
                table: "DeliveryOrders",
                column: "DeliveryOperationId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_UserAccounts_ExecutorId",
                table: "BusinessTasks",
                column: "ExecutorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_UserAccounts_ExecutorIsEmulationId",
                table: "BusinessTasks",
                column: "ExecutorIsEmulationId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_UserAccounts_ExecutorReplacedId",
                table: "BusinessTasks",
                column: "ExecutorReplacedId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserAccounts_CreationAuthorId",
                table: "Comments",
                column: "CreationAuthorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItems_UserAccounts_UserId",
                table: "OrganizationItems",
                column: "UserId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_UserGroups_UserGroupId",
                table: "UserAccounts",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_Contacts_ContactId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_DeliveryOrders_DeliveryOrderId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_Addresses_AddressId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Employees_EmployeeId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_OrganizationItems_OrganizationItemId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_ChangeAuthorId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_CreationAuthorId",
                table: "UserGroups");

            migrationBuilder.DropTable(
                name: "Comments");

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
                name: "DeliveryOrderProducts");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "InitialOrderProducts");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProjectPhase");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "WHProducts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "InitialOrders");

            migrationBuilder.DropTable(
                name: "ProjectPlanItem");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DeliveryOrders");

            migrationBuilder.DropTable(
                name: "BusinessTasks");

            migrationBuilder.DropTable(
                name: "DeliveryMethods");

            migrationBuilder.DropTable(
                name: "ExecutionTime");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrganizationItems");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
