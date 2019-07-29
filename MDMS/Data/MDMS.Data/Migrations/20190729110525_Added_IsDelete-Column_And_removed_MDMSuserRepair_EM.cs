using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_IsDeleteColumn_And_removed_MDMSuserRepair_EM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MdmsUsersRepairs");

            migrationBuilder.DropIndex(
                name: "IX_MonthlySalaries_SalarySlipTitle",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "SalarySlipTitle",
                table: "MonthlySalaries");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VehicleTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleProviders",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VehicleProviders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReportTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Repairs",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AddColumn<double>(
                name: "HoursWorked",
                table: "Repairs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Repairs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MdmsUserId",
                table: "Repairs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RepairCost",
                table: "Repairs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RepairedSystems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PartsProviders",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PartsProviders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parts",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Parts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MonthlySalaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MonthlySalaries",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_MdmsUserId",
                table: "Repairs",
                column: "MdmsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalaries_Name",
                table: "MonthlySalaries",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_AspNetUsers_MdmsUserId",
                table: "Repairs",
                column: "MdmsUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_AspNetUsers_MdmsUserId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_MdmsUserId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_MonthlySalaries_Name",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VehicleProviders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReportTypes");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "MdmsUserId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "RepairCost",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RepairedSystems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PartsProviders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MonthlySalaries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleProviders",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Repairs",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PartsProviders",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parts",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "SalarySlipTitle",
                table: "MonthlySalaries",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MdmsUsersRepairs",
                columns: table => new
                {
                    MdmsUserId = table.Column<string>(nullable: false),
                    RepairId = table.Column<string>(nullable: false),
                    HoursWorked = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MdmsUsersRepairs", x => new { x.MdmsUserId, x.RepairId });
                    table.ForeignKey(
                        name: "FK_MdmsUsersRepairs_AspNetUsers_MdmsUserId",
                        column: x => x.MdmsUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MdmsUsersRepairs_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalaries_SalarySlipTitle",
                table: "MonthlySalaries",
                column: "SalarySlipTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MdmsUsersRepairs_RepairId",
                table: "MdmsUsersRepairs",
                column: "RepairId");
        }
    }
}
