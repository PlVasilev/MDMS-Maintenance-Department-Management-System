using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Report_Added_Vehicle_Cloection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalRepairs_Reports_ReportId",
                table: "ExternalRepairs");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalRepairs_Reports_ReportId",
                table: "InternalRepairs");

            migrationBuilder.DropIndex(
                name: "IX_InternalRepairs_ReportId",
                table: "InternalRepairs");

            migrationBuilder.DropIndex(
                name: "IX_ExternalRepairs_ReportId",
                table: "ExternalRepairs");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "InternalRepairs");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ExternalRepairs");

            migrationBuilder.RenameColumn(
                name: "BaseCosts",
                table: "Reports",
                newName: "VehicleBaseCost");

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MechanicsBaseCosts",
                table: "Reports",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ReportId",
                table: "Vehicles",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Reports_ReportId",
                table: "Vehicles",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Reports_ReportId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ReportId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MechanicsBaseCosts",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "VehicleBaseCost",
                table: "Reports",
                newName: "BaseCosts");

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "InternalRepairs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "ExternalRepairs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InternalRepairs_ReportId",
                table: "InternalRepairs",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRepairs_ReportId",
                table: "ExternalRepairs",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalRepairs_Reports_ReportId",
                table: "ExternalRepairs",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalRepairs_Reports_ReportId",
                table: "InternalRepairs",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
