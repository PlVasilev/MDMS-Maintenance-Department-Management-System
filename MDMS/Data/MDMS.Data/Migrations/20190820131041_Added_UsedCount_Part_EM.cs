using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_UsedCount_Part_EM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsedCount",
                table: "Parts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsedCount",
                table: "Parts");
        }
    }
}
