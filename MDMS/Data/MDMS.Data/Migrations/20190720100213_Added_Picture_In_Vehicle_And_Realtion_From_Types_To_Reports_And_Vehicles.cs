using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_Picture_In_Vehicle_And_Realtion_From_Types_To_Reports_And_Vehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Reports_ReportId1",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_ReportId1",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "ReportId1",
                table: "Repairs");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ReportId1",
                table: "Repairs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ReportId1",
                table: "Repairs",
                column: "ReportId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Reports_ReportId1",
                table: "Repairs",
                column: "ReportId1",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
