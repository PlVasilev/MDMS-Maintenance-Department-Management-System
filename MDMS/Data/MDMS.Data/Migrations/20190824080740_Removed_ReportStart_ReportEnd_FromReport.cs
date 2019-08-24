using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Removed_ReportStart_ReportEnd_FromReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Reports_ReportId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Reports_ReportId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Reports_ReportId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ReportId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Parts_ReportId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ReportId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ReportEnd",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportStart",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "MonthlySalaries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalaries_ReportId",
                table: "MonthlySalaries",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalaries_Reports_ReportId",
                table: "MonthlySalaries",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalaries_Reports_ReportId",
                table: "MonthlySalaries");

            migrationBuilder.DropIndex(
                name: "IX_MonthlySalaries_ReportId",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "MonthlySalaries");

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "Vehicles",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "Parts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ReportId",
                table: "Vehicles",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ReportId",
                table: "Parts",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ReportId",
                table: "AspNetUsers",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Reports_ReportId",
                table: "AspNetUsers",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Reports_ReportId",
                table: "Parts",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Reports_ReportId",
                table: "Vehicles",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
