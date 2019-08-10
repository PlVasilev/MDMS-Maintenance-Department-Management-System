using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_BaseSalary_AdditionalOnHourPayment_TotalSAlary_To_MonthlySalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalOnHourPayment",
                table: "MonthlySalaries",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BaseSalary",
                table: "MonthlySalaries",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSalary",
                table: "MonthlySalaries",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalOnHourPayment",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "BaseSalary",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "TotalSalary",
                table: "MonthlySalaries");
        }
    }
}
