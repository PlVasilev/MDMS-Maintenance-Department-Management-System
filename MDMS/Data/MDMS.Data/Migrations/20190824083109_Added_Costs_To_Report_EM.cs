using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_Costs_To_Report_EM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BaseCosts",
                table: "Reports",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExternalRepairCosts",
                table: "Reports",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InternalRepairCosts",
                table: "Reports",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseCosts",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ExternalRepairCosts",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "InternalRepairCosts",
                table: "Reports");
        }
    }
}
