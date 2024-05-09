using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Migrations
{
    public partial class AddModelsForOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_UserAccount_ExecutorId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_UserAccount_ExecutorIsEmulationId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_UserAccount_ExecutorReplacedId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_BusinessTasks_BusinessTaskId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_UserAccount_CreationAuthorId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_WorkflowInstances_WorkflowInstanceId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Contact_ContactId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyContract_Company_CustomerCompaniesId",
                table: "CompanyContract");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmployee_Company_CompaniesId",
                table: "CompanyEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmployee_Employee_EmployeesId",
                table: "CompanyEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractCustomer_Customer_CustomersId",
                table: "ContractCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractEmployee_Employee_OurEmployeesId",
                table: "ContractEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractOrganization_Organization_OurOrganizationsId",
                table: "ContractOrganization");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Company_CompanyId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Contact_ContactId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_UserAccount_UserAccountId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Company_CompanyId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_OrganizationItem_HeadItemId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_OrganizationItem_ParentItemId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_UserAccount_UserId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Company_CompanyId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Customer_CustomerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employee_ManagerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employee_ChangeAuthorId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employee_CreationAuthorId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employee_ResolvingAuthorId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Employee_EmployeeId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Employee_EmployeeId",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_OrganizationItem_OrganizationItemId",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowInstanceMember_UserAccount_UserAccountId",
                table: "WorkflowInstanceMember");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowInstances_UserAccount_InitiatorId",
                table: "WorkflowInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowTrackingItems_Comment_CommentId",
                table: "WorkflowTrackingItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationItem",
                table: "OrganizationItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "UserAccount",
                newName: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "OrganizationItem",
                newName: "OrganizationItems");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_OrganizationItemId",
                table: "UserAccounts",
                newName: "IX_UserAccounts_OrganizationItemId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_EmployeeId",
                table: "UserAccounts",
                newName: "IX_UserAccounts_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItem_UserId",
                table: "OrganizationItems",
                newName: "IX_OrganizationItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItem_ParentItemId",
                table: "OrganizationItems",
                newName: "IX_OrganizationItems_ParentItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_HeadItemId",
                table: "Organizations",
                newName: "IX_Organizations_HeadItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_CompanyId",
                table: "Organizations",
                newName: "IX_Organizations_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_UserAccountId",
                table: "Customers",
                newName: "IX_Customers_UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ContactId",
                table: "Customers",
                newName: "IX_Customers_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_CompanyId",
                table: "Customers",
                newName: "IX_Customers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_ContactId",
                table: "Companies",
                newName: "IX_Companies_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_WorkflowInstanceId",
                table: "Comments",
                newName: "IX_Comments_WorkflowInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CreationAuthorId",
                table: "Comments",
                newName: "IX_Comments_CreationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BusinessTaskId",
                table: "Comments",
                newName: "IX_Comments_BusinessTaskId");

            migrationBuilder.AddColumn<long>(
                name: "ContactId",
                table: "BusinessTasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "BusinessTasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeliveryMethodId",
                table: "BusinessTasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "BusinessTasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BusinessTasks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeneratedOrderQrCode",
                table: "BusinessTasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "BusinessTasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "BusinessTasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserGroupId",
                table: "UserAccounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationItems",
                table: "OrganizationItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InitialOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserUid = table.Column<string>(type: "text", nullable: true),
                    Login = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PaymentType = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    CookingOperationId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryKitchen2WhId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryWh2KitchenId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialOrders_BusinessTasks_CookingOperationId",
                        column: x => x.CookingOperationId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrders_BusinessTasks_DeliveryKitchen2WhId",
                        column: x => x.DeliveryKitchen2WhId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrders_BusinessTasks_DeliveryWh2KitchenId",
                        column: x => x.DeliveryWh2KitchenId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: false),
                    TitleText = table.Column<string>(type: "text", nullable: false),
                    BodyText = table.Column<string>(type: "text", nullable: true),
                    SentDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReceivedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PictureUrl = table.Column<string>(type: "text", nullable: true),
                    PictureDescription = table.Column<string>(type: "text", nullable: true),
                    ProductCategoryType = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsGroupByDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsSystem = table.Column<bool>(type: "boolean", nullable: false),
                    CreationAuthorId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChangeAuthorId = table.Column<long>(type: "bigint", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: true),
                    OpenOrderDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CloseOrderDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ParentOrderId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerUid = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    OrderCustomerType = table.Column<int>(type: "integer", nullable: true),
                    ExecutorUid = table.Column<string>(type: "text", nullable: true),
                    ExecutorName = table.Column<string>(type: "text", nullable: true),
                    OrderExecutorType = table.Column<int>(type: "integer", nullable: true),
                    ProductsPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    AdditonalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CouldBeCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ParentDeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryMethodId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Origin = table.Column<string>(type: "text", nullable: true),
                    Destination = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Orders_ParentDeliveryOrderId",
                        column: x => x.ParentDeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Orders_ParentOrderId",
                        column: x => x.ParentOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    PictureUrl = table.Column<string>(type: "text", nullable: true),
                    PictureDescription = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
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
                name: "BusinessTaskDeliveryOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessTaskId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTaskDeliveryOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTaskDeliveryOrders_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTaskDeliveryOrders_Orders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Payer = table.Column<string>(type: "text", nullable: true),
                    Receiver = table.Column<string>(type: "text", nullable: true),
                    CardNumber = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PaymentType = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrderProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderProducts_Orders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InitialOrderProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    InitialOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CookingOperationId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryKitchen2WhId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryWh2KitchenId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_BusinessTasks_CookingOperationId",
                        column: x => x.CookingOperationId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_BusinessTasks_DeliveryKitchen2WhId",
                        column: x => x.DeliveryKitchen2WhId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_BusinessTasks_DeliveryWh2KitchenId",
                        column: x => x.DeliveryWh2KitchenId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_InitialOrders_InitialOrderId",
                        column: x => x.InitialOrderId,
                        principalTable: "InitialOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    Instruction = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    MinQuantity = table.Column<int>(type: "integer", nullable: false),
                    MaxQuantity = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientProductId = table.Column<long>(type: "bigint", nullable: true),
                    FinalProductId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    RecipeId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
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
                name: "ProductTransfers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WHProductId = table.Column<long>(type: "bigint", nullable: true),
                    OrderProductId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryOrderProductId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    BusinessOperationId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OldQuantity = table.Column<double>(type: "double precision", nullable: true),
                    NewQuantity = table.Column<double>(type: "double precision", nullable: false),
                    QuantityDelta = table.Column<double>(type: "double precision", nullable: false),
                    OldStatus = table.Column<string>(type: "text", nullable: true),
                    NewStatus = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTransfers_DeliveryOrderProducts_DeliveryOrderProduct~",
                        column: x => x.DeliveryOrderProductId,
                        principalTable: "DeliveryOrderProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_OrderProducts_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "OrderProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_Orders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_ProductTransfers_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductTransfers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_WHProducts_WHProductId",
                        column: x => x.WHProductId,
                        principalTable: "WHProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InitialOrderIngredients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientId = table.Column<long>(type: "bigint", nullable: true),
                    InitialOrderId = table.Column<long>(type: "bigint", nullable: true),
                    InitialOrderProductId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CookingOperationId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryWh2KitchenId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrderIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_BusinessTasks_CookingOperationId",
                        column: x => x.CookingOperationId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_BusinessTasks_DeliveryWh2KitchenId",
                        column: x => x.DeliveryWh2KitchenId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_InitialOrderProducts_InitialOrderPr~",
                        column: x => x.InitialOrderProductId,
                        principalTable: "InitialOrderProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_InitialOrders_InitialOrderId",
                        column: x => x.InitialOrderId,
                        principalTable: "InitialOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ContactId",
                table: "BusinessTasks",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_DeliveryMethodId",
                table: "BusinessTasks",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserGroupId",
                table: "UserAccounts",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTaskDeliveryOrders_BusinessTaskId",
                table: "BusinessTaskDeliveryOrders",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTaskDeliveryOrders_DeliveryOrderId",
                table: "BusinessTaskDeliveryOrders",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderProducts_DeliveryOrderId",
                table: "DeliveryOrderProducts",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderProducts_ProductId",
                table: "DeliveryOrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FinalProductId",
                table: "Ingredients",
                column: "FinalProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientProductId",
                table: "Ingredients",
                column: "IngredientProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_CookingOperationId",
                table: "InitialOrderIngredients",
                column: "CookingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_DeliveryWh2KitchenId",
                table: "InitialOrderIngredients",
                column: "DeliveryWh2KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_IngredientId",
                table: "InitialOrderIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_InitialOrderId",
                table: "InitialOrderIngredients",
                column: "InitialOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_InitialOrderProductId",
                table: "InitialOrderIngredients",
                column: "InitialOrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_CookingOperationId",
                table: "InitialOrderProducts",
                column: "CookingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_DeliveryKitchen2WhId",
                table: "InitialOrderProducts",
                column: "DeliveryKitchen2WhId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_DeliveryWh2KitchenId",
                table: "InitialOrderProducts",
                column: "DeliveryWh2KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_InitialOrderId",
                table: "InitialOrderProducts",
                column: "InitialOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_ProductId",
                table: "InitialOrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_CookingOperationId",
                table: "InitialOrders",
                column: "CookingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_DeliveryKitchen2WhId",
                table: "InitialOrders",
                column: "DeliveryKitchen2WhId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_DeliveryWh2KitchenId",
                table: "InitialOrders",
                column: "DeliveryWh2KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ParentDeliveryOrderId",
                table: "Orders",
                column: "ParentDeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ParentOrderId",
                table: "Orders",
                column: "ParentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_DeliveryOrderId",
                table: "ProductTransfers",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_DeliveryOrderProductId",
                table: "ProductTransfers",
                column: "DeliveryOrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_OrderId",
                table: "ProductTransfers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_OrderProductId",
                table: "ProductTransfers",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_ParentId",
                table: "ProductTransfers",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_WHProductId",
                table: "ProductTransfers",
                column: "WHProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ProductId",
                table: "Recipes",
                column: "ProductId");

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
                name: "FK_BusinessTasks_Contacts_ContactId",
                table: "BusinessTasks",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_DeliveryMethods_DeliveryMethodId",
                table: "BusinessTasks",
                column: "DeliveryMethodId",
                principalTable: "DeliveryMethods",
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
                name: "FK_Comments_BusinessTasks_BusinessTaskId",
                table: "Comments",
                column: "BusinessTaskId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserAccounts_CreationAuthorId",
                table: "Comments",
                column: "CreationAuthorId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_WorkflowInstances_WorkflowInstanceId",
                table: "Comments",
                column: "WorkflowInstanceId",
                principalTable: "WorkflowInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Contacts_ContactId",
                table: "Companies",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyContract_Companies_CustomerCompaniesId",
                table: "CompanyContract",
                column: "CustomerCompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEmployee_Companies_CompaniesId",
                table: "CompanyEmployee",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEmployee_Employees_EmployeesId",
                table: "CompanyEmployee",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractCustomer_Customers_CustomersId",
                table: "ContractCustomer",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractEmployee_Employees_OurEmployeesId",
                table: "ContractEmployee",
                column: "OurEmployeesId",
                principalTable: "Employees",
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
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Contacts_ContactId",
                table: "Customers",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_UserAccounts_UserAccountId",
                table: "Customers",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItems_OrganizationItems_ParentItemId",
                table: "OrganizationItems",
                column: "ParentItemId",
                principalTable: "OrganizationItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItems_UserAccounts_UserId",
                table: "OrganizationItems",
                column: "UserId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Companies_CompanyId",
                table: "Organizations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrganizationItems_HeadItemId",
                table: "Organizations",
                column: "HeadItemId",
                principalTable: "OrganizationItems",
                principalColumn: "Id");

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
                name: "FK_Skill_Employees_EmployeeId",
                table: "Skill",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Employees_EmployeeId",
                table: "UserAccounts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_OrganizationItems_OrganizationItemId",
                table: "UserAccounts",
                column: "OrganizationItemId",
                principalTable: "OrganizationItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_UserGroups_UserGroupId",
                table: "UserAccounts",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowInstanceMember_UserAccounts_UserAccountId",
                table: "WorkflowInstanceMember",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowInstances_UserAccounts_InitiatorId",
                table: "WorkflowInstances",
                column: "InitiatorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowTrackingItems_Comments_CommentId",
                table: "WorkflowTrackingItems",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_Contacts_ContactId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_DeliveryMethods_DeliveryMethodId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_UserAccounts_ExecutorId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_UserAccounts_ExecutorIsEmulationId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_UserAccounts_ExecutorReplacedId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BusinessTasks_BusinessTaskId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserAccounts_CreationAuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_WorkflowInstances_WorkflowInstanceId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Contacts_ContactId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyContract_Companies_CustomerCompaniesId",
                table: "CompanyContract");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmployee_Companies_CompaniesId",
                table: "CompanyEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmployee_Employees_EmployeesId",
                table: "CompanyEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractCustomer_Customers_CustomersId",
                table: "ContractCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractEmployee_Employees_OurEmployeesId",
                table: "ContractEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractOrganization_Organizations_OurOrganizationsId",
                table: "ContractOrganization");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Contacts_ContactId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_UserAccounts_UserAccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_OrganizationItems_ParentItemId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_UserAccounts_UserId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Companies_CompanyId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrganizationItems_HeadItemId",
                table: "Organizations");

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
                name: "FK_Risk_Employees_ChangeAuthorId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_CreationAuthorId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Employees_ResolvingAuthorId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Employees_EmployeeId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Employees_EmployeeId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_OrganizationItems_OrganizationItemId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_UserGroups_UserGroupId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowInstanceMember_UserAccounts_UserAccountId",
                table: "WorkflowInstanceMember");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowInstances_UserAccounts_InitiatorId",
                table: "WorkflowInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowTrackingItems_Comments_CommentId",
                table: "WorkflowTrackingItems");

            migrationBuilder.DropTable(
                name: "BusinessTaskDeliveryOrders");

            migrationBuilder.DropTable(
                name: "InitialOrderIngredients");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductTransfers");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "InitialOrderProducts");

            migrationBuilder.DropTable(
                name: "DeliveryOrderProducts");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "WHProducts");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "InitialOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "DeliveryMethods");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_BusinessTasks_ContactId",
                table: "BusinessTasks");

            migrationBuilder.DropIndex(
                name: "IX_BusinessTasks_DeliveryMethodId",
                table: "BusinessTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_UserGroupId",
                table: "UserAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationItems",
                table: "OrganizationItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "DeliveryMethodId",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "GeneratedOrderQrCode",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "BusinessTasks");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "UserAccounts",
                newName: "UserAccount");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameTable(
                name: "OrganizationItems",
                newName: "OrganizationItem");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccounts_OrganizationItemId",
                table: "UserAccount",
                newName: "IX_UserAccount_OrganizationItemId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccounts_EmployeeId",
                table: "UserAccount",
                newName: "IX_UserAccount_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_HeadItemId",
                table: "Organization",
                newName: "IX_Organization_HeadItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_CompanyId",
                table: "Organization",
                newName: "IX_Organization_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItems_UserId",
                table: "OrganizationItem",
                newName: "IX_OrganizationItem_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItems_ParentItemId",
                table: "OrganizationItem",
                newName: "IX_OrganizationItem_ParentItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserAccountId",
                table: "Customer",
                newName: "IX_Customer_UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ContactId",
                table: "Customer",
                newName: "IX_Customer_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CompanyId",
                table: "Customer",
                newName: "IX_Customer_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_ContactId",
                table: "Company",
                newName: "IX_Company_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_WorkflowInstanceId",
                table: "Comment",
                newName: "IX_Comment_WorkflowInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CreationAuthorId",
                table: "Comment",
                newName: "IX_Comment_CreationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BusinessTaskId",
                table: "Comment",
                newName: "IX_Comment_BusinessTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationItem",
                table: "OrganizationItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

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
                name: "FK_Comment_BusinessTasks_BusinessTaskId",
                table: "Comment",
                column: "BusinessTaskId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_UserAccount_CreationAuthorId",
                table: "Comment",
                column: "CreationAuthorId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_WorkflowInstances_WorkflowInstanceId",
                table: "Comment",
                column: "WorkflowInstanceId",
                principalTable: "WorkflowInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Contact_ContactId",
                table: "Company",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyContract_Company_CustomerCompaniesId",
                table: "CompanyContract",
                column: "CustomerCompaniesId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEmployee_Company_CompaniesId",
                table: "CompanyEmployee",
                column: "CompaniesId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEmployee_Employee_EmployeesId",
                table: "CompanyEmployee",
                column: "EmployeesId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractCustomer_Customer_CustomersId",
                table: "ContractCustomer",
                column: "CustomersId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractEmployee_Employee_OurEmployeesId",
                table: "ContractEmployee",
                column: "OurEmployeesId",
                principalTable: "Employee",
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
                name: "FK_Customer_Company_CompanyId",
                table: "Customer",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Contact_ContactId",
                table: "Customer",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_UserAccount_UserAccountId",
                table: "Customer",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Company_CompanyId",
                table: "Organization",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_OrganizationItem_HeadItemId",
                table: "Organization",
                column: "HeadItemId",
                principalTable: "OrganizationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_OrganizationItem_ParentItemId",
                table: "OrganizationItem",
                column: "ParentItemId",
                principalTable: "OrganizationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_UserAccount_UserId",
                table: "OrganizationItem",
                column: "UserId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Company_CompanyId",
                table: "Project",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customer_CustomerId",
                table: "Project",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_ManagerId",
                table: "Project",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employee_ChangeAuthorId",
                table: "Risk",
                column: "ChangeAuthorId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employee_CreationAuthorId",
                table: "Risk",
                column: "CreationAuthorId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employee_ResolvingAuthorId",
                table: "Risk",
                column: "ResolvingAuthorId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Employee_EmployeeId",
                table: "Skill",
                column: "EmployeeId",
                principalTable: "Employee",
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
                name: "FK_WorkflowInstanceMember_UserAccount_UserAccountId",
                table: "WorkflowInstanceMember",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowInstances_UserAccount_InitiatorId",
                table: "WorkflowInstances",
                column: "InitiatorId",
                principalTable: "UserAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowTrackingItems_Comment_CommentId",
                table: "WorkflowTrackingItems",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }
    }
}
