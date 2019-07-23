using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_Unique_For_Vehicle_VSN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VSN",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VSN",
                table: "Vehicles",
                column: "VSN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VSN",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "VSN",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
