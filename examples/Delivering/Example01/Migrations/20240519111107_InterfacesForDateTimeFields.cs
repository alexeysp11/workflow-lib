using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocipedeUtils.Examples.Delivering.Example01.Migrations
{
    public partial class InterfacesForDateTimeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnded",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateStarted",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "DateEndedActual",
                table: "Project",
                newName: "DateStartExpected");

            migrationBuilder.RenameColumn(
                name: "OpenOrderDt",
                table: "Orders",
                newName: "DateStartExpected");

            migrationBuilder.RenameColumn(
                name: "CloseOrderDt",
                table: "Orders",
                newName: "DateStartActual");

            migrationBuilder.RenameColumn(
                name: "SentDateTime",
                table: "Notifications",
                newName: "DateSent");

            migrationBuilder.RenameColumn(
                name: "ReceivedDateTime",
                table: "Notifications",
                newName: "DateReceived");

            migrationBuilder.RenameColumn(
                name: "EstimatedDateTimeEnd",
                table: "BusinessTasks",
                newName: "DateStartExpected");

            migrationBuilder.RenameColumn(
                name: "EstimatedDateTimeBegin",
                table: "BusinessTasks",
                newName: "DateStartActual");

            migrationBuilder.RenameColumn(
                name: "ActualDateTimeEnd",
                table: "BusinessTasks",
                newName: "DateEndExpected");

            migrationBuilder.RenameColumn(
                name: "ActualDateTimeBegin",
                table: "BusinessTasks",
                newName: "DateEndActual");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEndActual",
                table: "Project",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEndExpected",
                table: "Project",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStartActual",
                table: "Project",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEndActual",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEndExpected",
                table: "Orders",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEndActual",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateEndExpected",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateStartActual",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateEndActual",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateEndExpected",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "DateStartExpected",
                table: "Project",
                newName: "DateEndedActual");

            migrationBuilder.RenameColumn(
                name: "DateStartExpected",
                table: "Orders",
                newName: "OpenOrderDt");

            migrationBuilder.RenameColumn(
                name: "DateStartActual",
                table: "Orders",
                newName: "CloseOrderDt");

            migrationBuilder.RenameColumn(
                name: "DateSent",
                table: "Notifications",
                newName: "SentDateTime");

            migrationBuilder.RenameColumn(
                name: "DateReceived",
                table: "Notifications",
                newName: "ReceivedDateTime");

            migrationBuilder.RenameColumn(
                name: "DateStartExpected",
                table: "BusinessTasks",
                newName: "EstimatedDateTimeEnd");

            migrationBuilder.RenameColumn(
                name: "DateStartActual",
                table: "BusinessTasks",
                newName: "EstimatedDateTimeBegin");

            migrationBuilder.RenameColumn(
                name: "DateEndExpected",
                table: "BusinessTasks",
                newName: "ActualDateTimeEnd");

            migrationBuilder.RenameColumn(
                name: "DateEndActual",
                table: "BusinessTasks",
                newName: "ActualDateTimeBegin");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnded",
                table: "Project",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStarted",
                table: "Project",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
