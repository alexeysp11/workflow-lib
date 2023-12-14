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
                name: "Address",
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
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
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
                    table.PrimaryKey("PK_Contact", x => x.Id);
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
                name: "DeliveryMethod",
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
                    table.PrimaryKey("PK_DeliveryMethod", x => x.Id);
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
                name: "Company",
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
                    ContractId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_Address_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
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
                    InitialOrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_InitialOrders_InitialOrderId",
                        column: x => x.InitialOrderId,
                        principalTable: "InitialOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
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
                        name: "FK_CompanyEmployee_Company_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
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
                    ContractId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Customer_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
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
                        name: "FK_DeliveryOrders_Address_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_Address_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_DeliveryMethod_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethod",
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
                name: "BusinessTask",
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
                    table.PrimaryKey("PK_BusinessTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTask_Address_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTask_Address_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTask_BusinessTask_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "BusinessTask",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTask_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTask_DeliveryMethod_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTask_DeliveryOrders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "DeliveryOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTask_ExecutionTime_ActualExecutionTimeId",
                        column: x => x.ActualExecutionTimeId,
                        principalTable: "ExecutionTime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTask_ExecutionTime_EstimatedExecutionTimeId",
                        column: x => x.EstimatedExecutionTimeId,
                        principalTable: "ExecutionTime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
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
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_BusinessTask_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
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
                    ContractId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
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
                        name: "FK_Project_Address_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id");
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
                        name: "FK_Skill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
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
                        name: "FK_Risk_BusinessTask_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTask",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Employee_ChangeAuthorId",
                        column: x => x.ChangeAuthorId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Employee_CreationAuthorId",
                        column: x => x.CreationAuthorId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Employee_ResolvingAuthorId",
                        column: x => x.ResolvingAuthorId,
                        principalTable: "Employee",
                        principalColumn: "Id");
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
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true),
                    HeadItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    ContractId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organization_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
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
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroup_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationItem",
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
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true),
                    UserGroupId = table.Column<long>(type: "INTEGER", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationItem_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationItem_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationItem_OrganizationItem_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "OrganizationItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationItem_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
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
                    table.ForeignKey(
                        name: "FK_UserAccount_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_ActualExecutionTimeId",
                table: "BusinessTask",
                column: "ActualExecutionTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_ContactId",
                table: "BusinessTask",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_DeliveryMethodId",
                table: "BusinessTask",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_DeliveryOrderId",
                table: "BusinessTask",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_DestinationId",
                table: "BusinessTask",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_EstimatedExecutionTimeId",
                table: "BusinessTask",
                column: "EstimatedExecutionTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_ExecutorId",
                table: "BusinessTask",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_ExecutorIsEmulationId",
                table: "BusinessTask",
                column: "ExecutorIsEmulationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_ExecutorReplacedId",
                table: "BusinessTask",
                column: "ExecutorReplacedId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_OriginId",
                table: "BusinessTask",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTask_ParentTaskId",
                table: "BusinessTask",
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
                name: "IX_Company_AddressId",
                table: "Company",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ContactId",
                table: "Company",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ContractId",
                table: "Company",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ShippingAddressId",
                table: "Company",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_EmployeesId",
                table: "CompanyEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CompanyId",
                table: "Customer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ContactId",
                table: "Customer",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ContractId",
                table: "Customer",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserAccountId",
                table: "Customer",
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
                name: "IX_Employee_ContractId",
                table: "Employee",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProjectId",
                table: "Employee",
                column: "ProjectId");

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
                name: "IX_Organization_CompanyId",
                table: "Organization",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ContractId",
                table: "Organization",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_HeadItemId",
                table: "Organization",
                column: "HeadItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItem_AddressId",
                table: "OrganizationItem",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItem_EmployeeId",
                table: "OrganizationItem",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItem_ParentItemId",
                table: "OrganizationItem",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItem_UserGroupId",
                table: "OrganizationItem",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItem_UserId",
                table: "OrganizationItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DeliveryOrderId",
                table: "Payments",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InitialOrderId",
                table: "Products",
                column: "InitialOrderId");

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
                name: "IX_UserAccount_EmployeeId",
                table: "UserAccount",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_OrganizationItemId",
                table: "UserAccount",
                column: "OrganizationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_UserGroupId",
                table: "UserAccount",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_ChangeAuthorId",
                table: "UserGroup",
                column: "ChangeAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_CreationAuthorId",
                table: "UserGroup",
                column: "CreationAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_EmployeeId",
                table: "UserGroup",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WHProducts_ProductId",
                table: "WHProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEmployee_Employee_EmployeesId",
                table: "CompanyEmployee",
                column: "EmployeesId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_UserAccount_UserAccountId",
                table: "Customer",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrderProducts_DeliveryOrders_DeliveryOrderId",
                table: "DeliveryOrderProducts",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_BusinessTask_DeliveryOperationId",
                table: "DeliveryOrders",
                column: "DeliveryOperationId",
                principalTable: "BusinessTask",
                principalColumn: "Id");

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
                name: "FK_Employee_Project_ProjectId",
                table: "Employee",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_OrganizationItem_HeadItemId",
                table: "Organization",
                column: "HeadItemId",
                principalTable: "OrganizationItem",
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
                name: "FK_BusinessTask_DeliveryOrders_DeliveryOrderId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Project_ProjectId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_Address_AddressId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Contract_ContractId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_OrganizationItem_OrganizationItemId",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_UserAccount_ChangeAuthorId",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_UserAccount_CreationAuthorId",
                table: "UserGroup");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "CompanyEmployee");

            migrationBuilder.DropTable(
                name: "DeliveryOrderProducts");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Organization");

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
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "ProjectPlanItem");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "InitialOrders");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "DeliveryOrders");

            migrationBuilder.DropTable(
                name: "BusinessTask");

            migrationBuilder.DropTable(
                name: "DeliveryMethod");

            migrationBuilder.DropTable(
                name: "ExecutionTime");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "OrganizationItem");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
