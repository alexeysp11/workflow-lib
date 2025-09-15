using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.Migrations
{
    public partial class PluralizeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessDiagramElement_BusinessDiagram_BusinessDiagramId",
                table: "BusinessDiagramElement");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProcess_BusinessDiagram_DiagramId",
                table: "BusinessProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProcess_BusinessProcess_ParentId",
                table: "BusinessProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProcessState_BusinessProcess_BusinessProcessId",
                table: "BusinessProcessState");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_BusinessProcessState_BusinessProcessStateId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Container_PackType_PackTypeId",
                table: "Container");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrderProducts_Container_ContainerId",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrderProducts_Lot_LotId",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderProducts_Container_ContainerId",
                table: "InitialOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderProducts_Lot_LotId",
                table: "InitialOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Lot_PackType_PackTypeId",
                table: "Lot");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Container_ContainerId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Lot_LotId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PackType_PackTypeMaterial_PackTypeMaterialId",
                table: "PackType");

            migrationBuilder.DropForeignKey(
                name: "FK_PackType_WeightUnit_WeightUnitId",
                table: "PackType");

            migrationBuilder.DropForeignKey(
                name: "FK_Tray_PackType_PackTypeId",
                table: "Tray");

            migrationBuilder.DropForeignKey(
                name: "FK_WHProducts_WeightUnit_WeightUnitId",
                table: "WHProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeightUnit",
                table: "WeightUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackTypeMaterial",
                table: "PackTypeMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackType",
                table: "PackType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lot",
                table: "Lot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Container",
                table: "Container");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessProcessState",
                table: "BusinessProcessState");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessProcess",
                table: "BusinessProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessDiagramElement",
                table: "BusinessDiagramElement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessDiagram",
                table: "BusinessDiagram");

            migrationBuilder.RenameTable(
                name: "WeightUnit",
                newName: "WeightUnits");

            migrationBuilder.RenameTable(
                name: "PackTypeMaterial",
                newName: "PackTypeMaterials");

            migrationBuilder.RenameTable(
                name: "PackType",
                newName: "PackTypes");

            migrationBuilder.RenameTable(
                name: "Lot",
                newName: "Lots");

            migrationBuilder.RenameTable(
                name: "Container",
                newName: "Containers");

            migrationBuilder.RenameTable(
                name: "BusinessProcessState",
                newName: "BusinessProcessStates");

            migrationBuilder.RenameTable(
                name: "BusinessProcess",
                newName: "BusinessProcesses");

            migrationBuilder.RenameTable(
                name: "BusinessDiagramElement",
                newName: "BusinessDiagramElements");

            migrationBuilder.RenameTable(
                name: "BusinessDiagram",
                newName: "BusinessDiagrams");

            migrationBuilder.RenameIndex(
                name: "IX_PackType_WeightUnitId",
                table: "PackTypes",
                newName: "IX_PackTypes_WeightUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_PackType_PackTypeMaterialId",
                table: "PackTypes",
                newName: "IX_PackTypes_PackTypeMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Lot_PackTypeId",
                table: "Lots",
                newName: "IX_Lots_PackTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Container_PackTypeId",
                table: "Containers",
                newName: "IX_Containers_PackTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProcessState_BusinessProcessId",
                table: "BusinessProcessStates",
                newName: "IX_BusinessProcessStates_BusinessProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProcess_ParentId",
                table: "BusinessProcesses",
                newName: "IX_BusinessProcesses_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProcess_DiagramId",
                table: "BusinessProcesses",
                newName: "IX_BusinessProcesses_DiagramId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessDiagramElement_BusinessDiagramId",
                table: "BusinessDiagramElements",
                newName: "IX_BusinessDiagramElements_BusinessDiagramId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "WeightUnits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PackTypes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeightUnits",
                table: "WeightUnits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackTypeMaterials",
                table: "PackTypeMaterials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackTypes",
                table: "PackTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lots",
                table: "Lots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Containers",
                table: "Containers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessProcessStates",
                table: "BusinessProcessStates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessProcesses",
                table: "BusinessProcesses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessDiagramElements",
                table: "BusinessDiagramElements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessDiagrams",
                table: "BusinessDiagrams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDiagramElements_BusinessDiagrams_BusinessDiagramId",
                table: "BusinessDiagramElements",
                column: "BusinessDiagramId",
                principalTable: "BusinessDiagrams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProcesses_BusinessDiagrams_DiagramId",
                table: "BusinessProcesses",
                column: "DiagramId",
                principalTable: "BusinessDiagrams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProcesses_BusinessProcesses_ParentId",
                table: "BusinessProcesses",
                column: "ParentId",
                principalTable: "BusinessProcesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProcessStates_BusinessProcesses_BusinessProcessId",
                table: "BusinessProcessStates",
                column: "BusinessProcessId",
                principalTable: "BusinessProcesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_BusinessProcessStates_BusinessProcessStateId",
                table: "BusinessTasks",
                column: "BusinessProcessStateId",
                principalTable: "BusinessProcessStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_PackTypes_PackTypeId",
                table: "Containers",
                column: "PackTypeId",
                principalTable: "PackTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrderProducts_Containers_ContainerId",
                table: "DeliveryOrderProducts",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrderProducts_Lots_LotId",
                table: "DeliveryOrderProducts",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderProducts_Containers_ContainerId",
                table: "InitialOrderProducts",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderProducts_Lots_LotId",
                table: "InitialOrderProducts",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_PackTypes_PackTypeId",
                table: "Lots",
                column: "PackTypeId",
                principalTable: "PackTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Containers_ContainerId",
                table: "OrderProducts",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Lots_LotId",
                table: "OrderProducts",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackTypes_PackTypeMaterials_PackTypeMaterialId",
                table: "PackTypes",
                column: "PackTypeMaterialId",
                principalTable: "PackTypeMaterials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackTypes_WeightUnits_WeightUnitId",
                table: "PackTypes",
                column: "WeightUnitId",
                principalTable: "WeightUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tray_PackTypes_PackTypeId",
                table: "Tray",
                column: "PackTypeId",
                principalTable: "PackTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WHProducts_WeightUnits_WeightUnitId",
                table: "WHProducts",
                column: "WeightUnitId",
                principalTable: "WeightUnits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessDiagramElements_BusinessDiagrams_BusinessDiagramId",
                table: "BusinessDiagramElements");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProcesses_BusinessDiagrams_DiagramId",
                table: "BusinessProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProcesses_BusinessProcesses_ParentId",
                table: "BusinessProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProcessStates_BusinessProcesses_BusinessProcessId",
                table: "BusinessProcessStates");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTasks_BusinessProcessStates_BusinessProcessStateId",
                table: "BusinessTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_PackTypes_PackTypeId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrderProducts_Containers_ContainerId",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrderProducts_Lots_LotId",
                table: "DeliveryOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderProducts_Containers_ContainerId",
                table: "InitialOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialOrderProducts_Lots_LotId",
                table: "InitialOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Lots_PackTypes_PackTypeId",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Containers_ContainerId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Lots_LotId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PackTypes_PackTypeMaterials_PackTypeMaterialId",
                table: "PackTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PackTypes_WeightUnits_WeightUnitId",
                table: "PackTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tray_PackTypes_PackTypeId",
                table: "Tray");

            migrationBuilder.DropForeignKey(
                name: "FK_WHProducts_WeightUnits_WeightUnitId",
                table: "WHProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeightUnits",
                table: "WeightUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackTypes",
                table: "PackTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackTypeMaterials",
                table: "PackTypeMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lots",
                table: "Lots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Containers",
                table: "Containers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessProcessStates",
                table: "BusinessProcessStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessProcesses",
                table: "BusinessProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessDiagrams",
                table: "BusinessDiagrams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessDiagramElements",
                table: "BusinessDiagramElements");

            migrationBuilder.RenameTable(
                name: "WeightUnits",
                newName: "WeightUnit");

            migrationBuilder.RenameTable(
                name: "PackTypes",
                newName: "PackType");

            migrationBuilder.RenameTable(
                name: "PackTypeMaterials",
                newName: "PackTypeMaterial");

            migrationBuilder.RenameTable(
                name: "Lots",
                newName: "Lot");

            migrationBuilder.RenameTable(
                name: "Containers",
                newName: "Container");

            migrationBuilder.RenameTable(
                name: "BusinessProcessStates",
                newName: "BusinessProcessState");

            migrationBuilder.RenameTable(
                name: "BusinessProcesses",
                newName: "BusinessProcess");

            migrationBuilder.RenameTable(
                name: "BusinessDiagrams",
                newName: "BusinessDiagram");

            migrationBuilder.RenameTable(
                name: "BusinessDiagramElements",
                newName: "BusinessDiagramElement");

            migrationBuilder.RenameIndex(
                name: "IX_PackTypes_WeightUnitId",
                table: "PackType",
                newName: "IX_PackType_WeightUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_PackTypes_PackTypeMaterialId",
                table: "PackType",
                newName: "IX_PackType_PackTypeMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Lots_PackTypeId",
                table: "Lot",
                newName: "IX_Lot_PackTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Containers_PackTypeId",
                table: "Container",
                newName: "IX_Container_PackTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProcessStates_BusinessProcessId",
                table: "BusinessProcessState",
                newName: "IX_BusinessProcessState_BusinessProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProcesses_ParentId",
                table: "BusinessProcess",
                newName: "IX_BusinessProcess_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProcesses_DiagramId",
                table: "BusinessProcess",
                newName: "IX_BusinessProcess_DiagramId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessDiagramElements_BusinessDiagramId",
                table: "BusinessDiagramElement",
                newName: "IX_BusinessDiagramElement_BusinessDiagramId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "WeightUnit",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PackType",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeightUnit",
                table: "WeightUnit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackType",
                table: "PackType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackTypeMaterial",
                table: "PackTypeMaterial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lot",
                table: "Lot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Container",
                table: "Container",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessProcessState",
                table: "BusinessProcessState",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessProcess",
                table: "BusinessProcess",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessDiagram",
                table: "BusinessDiagram",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessDiagramElement",
                table: "BusinessDiagramElement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDiagramElement_BusinessDiagram_BusinessDiagramId",
                table: "BusinessDiagramElement",
                column: "BusinessDiagramId",
                principalTable: "BusinessDiagram",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProcess_BusinessDiagram_DiagramId",
                table: "BusinessProcess",
                column: "DiagramId",
                principalTable: "BusinessDiagram",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProcess_BusinessProcess_ParentId",
                table: "BusinessProcess",
                column: "ParentId",
                principalTable: "BusinessProcess",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProcessState_BusinessProcess_BusinessProcessId",
                table: "BusinessProcessState",
                column: "BusinessProcessId",
                principalTable: "BusinessProcess",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_BusinessProcessState_BusinessProcessStateId",
                table: "BusinessTasks",
                column: "BusinessProcessStateId",
                principalTable: "BusinessProcessState",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Container_PackType_PackTypeId",
                table: "Container",
                column: "PackTypeId",
                principalTable: "PackType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrderProducts_Container_ContainerId",
                table: "DeliveryOrderProducts",
                column: "ContainerId",
                principalTable: "Container",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrderProducts_Lot_LotId",
                table: "DeliveryOrderProducts",
                column: "LotId",
                principalTable: "Lot",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderProducts_Container_ContainerId",
                table: "InitialOrderProducts",
                column: "ContainerId",
                principalTable: "Container",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialOrderProducts_Lot_LotId",
                table: "InitialOrderProducts",
                column: "LotId",
                principalTable: "Lot",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lot_PackType_PackTypeId",
                table: "Lot",
                column: "PackTypeId",
                principalTable: "PackType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Container_ContainerId",
                table: "OrderProducts",
                column: "ContainerId",
                principalTable: "Container",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Lot_LotId",
                table: "OrderProducts",
                column: "LotId",
                principalTable: "Lot",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackType_PackTypeMaterial_PackTypeMaterialId",
                table: "PackType",
                column: "PackTypeMaterialId",
                principalTable: "PackTypeMaterial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackType_WeightUnit_WeightUnitId",
                table: "PackType",
                column: "WeightUnitId",
                principalTable: "WeightUnit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tray_PackType_PackTypeId",
                table: "Tray",
                column: "PackTypeId",
                principalTable: "PackType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WHProducts_WeightUnit_WeightUnitId",
                table: "WHProducts",
                column: "WeightUnitId",
                principalTable: "WeightUnit",
                principalColumn: "Id");
        }
    }
}
