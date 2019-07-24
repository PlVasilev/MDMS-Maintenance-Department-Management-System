using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_Unique_Constr_To_Every_EF_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VSN",
                table: "Vehicles",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Repairs",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SalarySlipTitle",
                table: "MonthlySalaries",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_Name",
                table: "VehicleTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleProviders_Name",
                table: "VehicleProviders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportTypes_Name",
                table: "ReportTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Name",
                table: "Reports",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_Name",
                table: "Repairs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairedSystems_Name",
                table: "RepairedSystems",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsProviders_Name",
                table: "PartsProviders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_Name",
                table: "Parts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalaries_SalarySlipTitle",
                table: "MonthlySalaries",
                column: "SalarySlipTitle",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleTypes_Name",
                table: "VehicleTypes");

            migrationBuilder.DropIndex(
                name: "IX_VehicleProviders_Name",
                table: "VehicleProviders");

            migrationBuilder.DropIndex(
                name: "IX_ReportTypes_Name",
                table: "ReportTypes");

            migrationBuilder.DropIndex(
                name: "IX_Reports_Name",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_Name",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_RepairedSystems_Name",
                table: "RepairedSystems");

            migrationBuilder.DropIndex(
                name: "IX_PartsProviders_Name",
                table: "PartsProviders");

            migrationBuilder.DropIndex(
                name: "IX_Parts_Name",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_MonthlySalaries_SalarySlipTitle",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "SalarySlipTitle",
                table: "MonthlySalaries");

            migrationBuilder.AlterColumn<string>(
                name: "VSN",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
