using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowLib.Example01.Migrations
{
    public partial class RenameTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_Address_DestinationId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_Address_OriginId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_BusinessTask_ParentTaskId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_Contact_ContactId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_DeliveryMethod_DeliveryMethodId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_DeliveryOrders_DeliveryOrderId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_ExecutionTime_ActualExecutionTimeId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_ExecutionTime_EstimatedExecutionTimeId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorIsEmulationId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorReplacedId",
                table: "BusinessTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_BusinessTask_BusinessTaskId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_UserAccounts_CreationAuthorId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Address_AddressId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Address_ShippingAddressId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Contact_ContactId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Contract_ContractId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmployee_Company_CompaniesId",
                table: "CompanyEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmployee_Employee_EmployeesId",
                table: "CompanyEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Company_CompanyId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Contact_ContactId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Contract_ContractId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_UserAccounts_UserAccountId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrders_Address_DestinationId",
                table: "DeliveryOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrders_Address_OriginId",
                table: "DeliveryOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrders_BusinessTask_DeliveryOperationId",
                table: "DeliveryOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrders_DeliveryMethod_DeliveryMethodId",
                table: "DeliveryOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Contract_ContractId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Project_ProjectId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Company_CompanyId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Contract_ContractId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_OrganizationItem_HeadItemId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_Address_AddressId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_Employee_EmployeeId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_OrganizationItem_ParentItemId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_UserAccounts_UserId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItem_UserGroups_UserGroupId",
                table: "OrganizationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Address_LocationId",
                table: "Project");

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
                name: "FK_Risk_BusinessTask_BusinessTaskId",
                table: "Risk");

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
                name: "FK_UserAccounts_Employee_EmployeeId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_OrganizationItem_OrganizationItemId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Employee_EmployeeId",
                table: "UserGroups");

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
                name: "PK_DeliveryMethod",
                table: "DeliveryMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessTask",
                table: "BusinessTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

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
                name: "DeliveryMethod",
                newName: "DeliveryMethods");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "BusinessTask",
                newName: "BusinessTasks");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItem_UserId",
                table: "OrganizationItems",
                newName: "IX_OrganizationItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItem_UserGroupId",
                table: "OrganizationItems",
                newName: "IX_OrganizationItems_UserGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItem_ParentItemId",
                table: "OrganizationItems",
                newName: "IX_OrganizationItems_ParentItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItem_EmployeeId",
                table: "OrganizationItems",
                newName: "IX_OrganizationItems_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItem_AddressId",
                table: "OrganizationItems",
                newName: "IX_OrganizationItems_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_HeadItemId",
                table: "Organizations",
                newName: "IX_Organizations_HeadItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_ContractId",
                table: "Organizations",
                newName: "IX_Organizations_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_CompanyId",
                table: "Organizations",
                newName: "IX_Organizations_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ProjectId",
                table: "Employees",
                newName: "IX_Employees_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ContractId",
                table: "Employees",
                newName: "IX_Employees_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_UserAccountId",
                table: "Customers",
                newName: "IX_Customers_UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ContractId",
                table: "Customers",
                newName: "IX_Customers_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ContactId",
                table: "Customers",
                newName: "IX_Customers_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_CompanyId",
                table: "Customers",
                newName: "IX_Customers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_ShippingAddressId",
                table: "Companies",
                newName: "IX_Companies_ShippingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_ContractId",
                table: "Companies",
                newName: "IX_Companies_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_ContactId",
                table: "Companies",
                newName: "IX_Companies_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_AddressId",
                table: "Companies",
                newName: "IX_Companies_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CreationAuthorId",
                table: "Comments",
                newName: "IX_Comments_CreationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BusinessTaskId",
                table: "Comments",
                newName: "IX_Comments_BusinessTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_ParentTaskId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_ParentTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_OriginId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_ExecutorReplacedId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_ExecutorReplacedId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_ExecutorIsEmulationId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_ExecutorIsEmulationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_ExecutorId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_ExecutorId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_EstimatedExecutionTimeId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_EstimatedExecutionTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_DestinationId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_DeliveryOrderId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_DeliveryOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_DeliveryMethodId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_DeliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_ContactId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTask_ActualExecutionTimeId",
                table: "BusinessTasks",
                newName: "IX_BusinessTasks_ActualExecutionTimeId");

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
                name: "PK_DeliveryMethods",
                table: "DeliveryMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessTasks",
                table: "BusinessTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_Addresses_DestinationId",
                table: "BusinessTasks",
                column: "DestinationId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_Addresses_OriginId",
                table: "BusinessTasks",
                column: "OriginId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                table: "BusinessTasks",
                column: "ParentTaskId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_Contact_ContactId",
                table: "BusinessTasks",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_DeliveryMethods_DeliveryMethodId",
                table: "BusinessTasks",
                column: "DeliveryMethodId",
                principalTable: "DeliveryMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_DeliveryOrders_DeliveryOrderId",
                table: "BusinessTasks",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_ExecutionTime_ActualExecutionTimeId",
                table: "BusinessTasks",
                column: "ActualExecutionTimeId",
                principalTable: "ExecutionTime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_ExecutionTime_EstimatedExecutionTimeId",
                table: "BusinessTasks",
                column: "EstimatedExecutionTimeId",
                principalTable: "ExecutionTime",
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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_ShippingAddressId",
                table: "Companies",
                column: "ShippingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Contact_ContactId",
                table: "Companies",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Contract_ContractId",
                table: "Companies",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id");

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
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Contact_ContactId",
                table: "Customers",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Contract_ContractId",
                table: "Customers",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_UserAccounts_UserAccountId",
                table: "Customers",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_Addresses_DestinationId",
                table: "DeliveryOrders",
                column: "DestinationId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_Addresses_OriginId",
                table: "DeliveryOrders",
                column: "OriginId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_BusinessTasks_DeliveryOperationId",
                table: "DeliveryOrders",
                column: "DeliveryOperationId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_DeliveryMethods_DeliveryMethodId",
                table: "DeliveryOrders",
                column: "DeliveryMethodId",
                principalTable: "DeliveryMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Contract_ContractId",
                table: "Employees",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Project_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItems_Addresses_AddressId",
                table: "OrganizationItems",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItems_Employees_EmployeeId",
                table: "OrganizationItems",
                column: "EmployeeId",
                principalTable: "Employees",
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
                name: "FK_OrganizationItems_UserGroups_UserGroupId",
                table: "OrganizationItems",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Companies_CompanyId",
                table: "Organizations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Contract_ContractId",
                table: "Organizations",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrganizationItems_HeadItemId",
                table: "Organizations",
                column: "HeadItemId",
                principalTable: "OrganizationItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Addresses_LocationId",
                table: "Project",
                column: "LocationId",
                principalTable: "Addresses",
                principalColumn: "Id");

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
                name: "FK_Risk_BusinessTasks_BusinessTaskId",
                table: "Risk",
                column: "BusinessTaskId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_ChangeAuthorId",
                table: "Risk",
                column: "ChangeAuthorId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_CreationAuthorId",
                table: "Risk",
                column: "CreationAuthorId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employees_ResolvingAuthorId",
                table: "Risk",
                column: "ResolvingAuthorId",
                principalTable: "Employees",
                principalColumn: "Id");

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
                name: "FK_UserGroups_Employees_EmployeeId",
                table: "UserGroups",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_Addresses_DestinationId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_Addresses_OriginId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_Contact_ContactId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_DeliveryMethods_DeliveryMethodId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_DeliveryOrders_DeliveryOrderId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_ExecutionTime_ActualExecutionTimeId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_ExecutionTime_EstimatedExecutionTimeId",
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
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_ShippingAddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Contact_ContactId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Contract_ContractId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmployee_Companies_CompaniesId",
                table: "CompanyEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmployee_Employees_EmployeesId",
                table: "CompanyEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Contact_ContactId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Contract_ContractId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_UserAccounts_UserAccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrders_Addresses_DestinationId",
                table: "DeliveryOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrders_Addresses_OriginId",
                table: "DeliveryOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrders_BusinessTasks_DeliveryOperationId",
                table: "DeliveryOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrders_DeliveryMethods_DeliveryMethodId",
                table: "DeliveryOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Contract_ContractId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Project_ProjectId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_Addresses_AddressId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_Employees_EmployeeId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_OrganizationItems_ParentItemId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_UserAccounts_UserId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_UserGroups_UserGroupId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Companies_CompanyId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Contract_ContractId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrganizationItems_HeadItemId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Addresses_LocationId",
                table: "Project");

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
                name: "FK_Risk_BusinessTasks_BusinessTaskId",
                table: "Risk");

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
                name: "FK_UserGroups_Employees_EmployeeId",
                table: "UserGroups");

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
                name: "PK_DeliveryMethods",
                table: "DeliveryMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessTasks",
                table: "BusinessTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

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
                name: "DeliveryMethods",
                newName: "DeliveryMethod");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "BusinessTasks",
                newName: "BusinessTask");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_HeadItemId",
                table: "Organization",
                newName: "IX_Organization_HeadItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_ContractId",
                table: "Organization",
                newName: "IX_Organization_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_CompanyId",
                table: "Organization",
                newName: "IX_Organization_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItems_UserId",
                table: "OrganizationItem",
                newName: "IX_OrganizationItem_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItems_UserGroupId",
                table: "OrganizationItem",
                newName: "IX_OrganizationItem_UserGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItems_ParentItemId",
                table: "OrganizationItem",
                newName: "IX_OrganizationItem_ParentItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItems_EmployeeId",
                table: "OrganizationItem",
                newName: "IX_OrganizationItem_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationItems_AddressId",
                table: "OrganizationItem",
                newName: "IX_OrganizationItem_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ProjectId",
                table: "Employee",
                newName: "IX_Employee_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ContractId",
                table: "Employee",
                newName: "IX_Employee_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserAccountId",
                table: "Customer",
                newName: "IX_Customer_UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ContractId",
                table: "Customer",
                newName: "IX_Customer_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ContactId",
                table: "Customer",
                newName: "IX_Customer_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CompanyId",
                table: "Customer",
                newName: "IX_Customer_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_ShippingAddressId",
                table: "Company",
                newName: "IX_Company_ShippingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_ContractId",
                table: "Company",
                newName: "IX_Company_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_ContactId",
                table: "Company",
                newName: "IX_Company_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_AddressId",
                table: "Company",
                newName: "IX_Company_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CreationAuthorId",
                table: "Comment",
                newName: "IX_Comment_CreationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BusinessTaskId",
                table: "Comment",
                newName: "IX_Comment_BusinessTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_ParentTaskId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_ParentTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_OriginId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_ExecutorReplacedId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_ExecutorReplacedId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_ExecutorIsEmulationId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_ExecutorIsEmulationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_ExecutorId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_ExecutorId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_EstimatedExecutionTimeId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_EstimatedExecutionTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_DestinationId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_DeliveryOrderId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_DeliveryOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_DeliveryMethodId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_DeliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_ContactId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTasks_ActualExecutionTimeId",
                table: "BusinessTask",
                newName: "IX_BusinessTask_ActualExecutionTimeId");

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
                name: "PK_DeliveryMethod",
                table: "DeliveryMethod",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessTask",
                table: "BusinessTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_Address_DestinationId",
                table: "BusinessTask",
                column: "DestinationId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_Address_OriginId",
                table: "BusinessTask",
                column: "OriginId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_BusinessTask_ParentTaskId",
                table: "BusinessTask",
                column: "ParentTaskId",
                principalTable: "BusinessTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_Contact_ContactId",
                table: "BusinessTask",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_DeliveryMethod_DeliveryMethodId",
                table: "BusinessTask",
                column: "DeliveryMethodId",
                principalTable: "DeliveryMethod",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_DeliveryOrders_DeliveryOrderId",
                table: "BusinessTask",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_ExecutionTime_ActualExecutionTimeId",
                table: "BusinessTask",
                column: "ActualExecutionTimeId",
                principalTable: "ExecutionTime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_ExecutionTime_EstimatedExecutionTimeId",
                table: "BusinessTask",
                column: "EstimatedExecutionTimeId",
                principalTable: "ExecutionTime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorId",
                table: "BusinessTask",
                column: "ExecutorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorIsEmulationId",
                table: "BusinessTask",
                column: "ExecutorIsEmulationId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTask_UserAccounts_ExecutorReplacedId",
                table: "BusinessTask",
                column: "ExecutorReplacedId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_BusinessTask_BusinessTaskId",
                table: "Comment",
                column: "BusinessTaskId",
                principalTable: "BusinessTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_UserAccounts_CreationAuthorId",
                table: "Comment",
                column: "CreationAuthorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Address_AddressId",
                table: "Company",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Address_ShippingAddressId",
                table: "Company",
                column: "ShippingAddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Contact_ContactId",
                table: "Company",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Contract_ContractId",
                table: "Company",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id");

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
                name: "FK_Customer_Contract_ContractId",
                table: "Customer",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_UserAccounts_UserAccountId",
                table: "Customer",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_Address_DestinationId",
                table: "DeliveryOrders",
                column: "DestinationId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_Address_OriginId",
                table: "DeliveryOrders",
                column: "OriginId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_BusinessTask_DeliveryOperationId",
                table: "DeliveryOrders",
                column: "DeliveryOperationId",
                principalTable: "BusinessTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_DeliveryMethod_DeliveryMethodId",
                table: "DeliveryOrders",
                column: "DeliveryMethodId",
                principalTable: "DeliveryMethod",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Contract_ContractId",
                table: "Employee",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Project_ProjectId",
                table: "Employee",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Company_CompanyId",
                table: "Organization",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Contract_ContractId",
                table: "Organization",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_OrganizationItem_HeadItemId",
                table: "Organization",
                column: "HeadItemId",
                principalTable: "OrganizationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_Address_AddressId",
                table: "OrganizationItem",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_Employee_EmployeeId",
                table: "OrganizationItem",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_OrganizationItem_ParentItemId",
                table: "OrganizationItem",
                column: "ParentItemId",
                principalTable: "OrganizationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_UserAccounts_UserId",
                table: "OrganizationItem",
                column: "UserId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItem_UserGroups_UserGroupId",
                table: "OrganizationItem",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Address_LocationId",
                table: "Project",
                column: "LocationId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Company_CompanyId",
                table: "Project",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customer_CustomerId",
                table: "Project",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_ManagerId",
                table: "Project",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_BusinessTask_BusinessTaskId",
                table: "Risk",
                column: "BusinessTaskId",
                principalTable: "BusinessTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employee_ChangeAuthorId",
                table: "Risk",
                column: "ChangeAuthorId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employee_CreationAuthorId",
                table: "Risk",
                column: "CreationAuthorId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Employee_ResolvingAuthorId",
                table: "Risk",
                column: "ResolvingAuthorId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Employee_EmployeeId",
                table: "Skill",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Employee_EmployeeId",
                table: "UserAccounts",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_OrganizationItem_OrganizationItemId",
                table: "UserAccounts",
                column: "OrganizationItemId",
                principalTable: "OrganizationItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Employee_EmployeeId",
                table: "UserGroups",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
