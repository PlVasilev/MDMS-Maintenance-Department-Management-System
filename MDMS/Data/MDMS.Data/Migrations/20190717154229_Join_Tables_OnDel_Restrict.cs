using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Join_Tables_OnDel_Restrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MdmsUsersRepairs_AspNetUsers_MdmsUserId",
                table: "MdmsUsersRepairs");

            migrationBuilder.DropForeignKey(
                name: "FK_MdmsUsersRepairs_Repairs_RepairId",
                table: "MdmsUsersRepairs");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairsParts_Parts_PartId",
                table: "RepairsParts");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairsParts_Repairs_RepairId",
                table: "RepairsParts");

            migrationBuilder.AddForeignKey(
                name: "FK_MdmsUsersRepairs_AspNetUsers_MdmsUserId",
                table: "MdmsUsersRepairs",
                column: "MdmsUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MdmsUsersRepairs_Repairs_RepairId",
                table: "MdmsUsersRepairs",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairsParts_Parts_PartId",
                table: "RepairsParts",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairsParts_Repairs_RepairId",
                table: "RepairsParts",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MdmsUsersRepairs_AspNetUsers_MdmsUserId",
                table: "MdmsUsersRepairs");

            migrationBuilder.DropForeignKey(
                name: "FK_MdmsUsersRepairs_Repairs_RepairId",
                table: "MdmsUsersRepairs");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairsParts_Parts_PartId",
                table: "RepairsParts");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairsParts_Repairs_RepairId",
                table: "RepairsParts");

            migrationBuilder.AddForeignKey(
                name: "FK_MdmsUsersRepairs_AspNetUsers_MdmsUserId",
                table: "MdmsUsersRepairs",
                column: "MdmsUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MdmsUsersRepairs_Repairs_RepairId",
                table: "MdmsUsersRepairs",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairsParts_Parts_PartId",
                table: "RepairsParts",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairsParts_Repairs_RepairId",
                table: "RepairsParts",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
