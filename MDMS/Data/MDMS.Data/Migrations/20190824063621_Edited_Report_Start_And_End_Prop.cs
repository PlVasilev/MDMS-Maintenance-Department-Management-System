using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Edited_Report_Start_And_End_Prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "EndMonth",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportEnd",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportStart",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartMonth",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartYear",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "Parts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ReportId",
                table: "Parts",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Reports_ReportId",
                table: "Parts",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Reports_ReportId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_ReportId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "EndMonth",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "EndYear",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportEnd",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportStart",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "StartMonth",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "StartYear",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Parts");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Reports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Reports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
