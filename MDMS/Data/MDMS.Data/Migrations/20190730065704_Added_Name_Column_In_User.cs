using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_Name_Column_In_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairsParts");

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "ExternalRepairs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InternalsRepairParts",
                columns: table => new
                {
                    InternalRepairId = table.Column<string>(nullable: false),
                    PartId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalsRepairParts", x => new { x.InternalRepairId, x.PartId });
                    table.ForeignKey(
                        name: "FK_InternalsRepairParts_InternalRepairs_InternalRepairId",
                        column: x => x.InternalRepairId,
                        principalTable: "InternalRepairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalsRepairParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ReportId",
                table: "Vehicles",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRepairs_ReportId",
                table: "ExternalRepairs",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ReportId",
                table: "AspNetUsers",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalsRepairParts_PartId",
                table: "InternalsRepairParts",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Reports_ReportId",
                table: "AspNetUsers",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalRepairs_Reports_ReportId",
                table: "ExternalRepairs",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Reports_ReportId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalRepairs_Reports_ReportId",
                table: "ExternalRepairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Reports_ReportId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "InternalsRepairParts");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ReportId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_ExternalRepairs_ReportId",
                table: "ExternalRepairs");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ReportId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ExternalRepairs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "RepairsParts",
                columns: table => new
                {
                    RepairId = table.Column<string>(nullable: false),
                    PartId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairsParts", x => new { x.RepairId, x.PartId });
                    table.ForeignKey(
                        name: "FK_RepairsParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairsParts_InternalRepairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "InternalRepairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairsParts_PartId",
                table: "RepairsParts",
                column: "PartId");
        }
    }
}
