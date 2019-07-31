using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_Vehicle_Mileage_IsInRepair_ReqNumber_Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInRepair",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInRepair",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Vehicles");
        }
    }
}
