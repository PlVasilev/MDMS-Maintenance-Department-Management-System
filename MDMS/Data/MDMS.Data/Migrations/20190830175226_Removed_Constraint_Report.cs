using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Removed_Constraint_Report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalaries_AspNetUsers_MechanicId",
                table: "MonthlySalaries");

            migrationBuilder.DropIndex(
                name: "IX_Reports_Name",
                table: "Reports");

            migrationBuilder.AlterColumn<string>(
                name: "VSN",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicles",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Vehicles",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "MechanicId",
                table: "MonthlySalaries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalaries_AspNetUsers_MechanicId",
                table: "MonthlySalaries",
                column: "MechanicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalaries_AspNetUsers_MechanicId",
                table: "MonthlySalaries");

            migrationBuilder.AlterColumn<string>(
                name: "VSN",
                table: "Vehicles",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicles",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Vehicles",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "MechanicId",
                table: "MonthlySalaries",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Name",
                table: "Reports",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalaries_AspNetUsers_MechanicId",
                table: "MonthlySalaries",
                column: "MechanicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
