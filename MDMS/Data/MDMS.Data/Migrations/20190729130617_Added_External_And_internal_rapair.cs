using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDMS.Data.Migrations
{
    public partial class Added_External_And_internal_rapair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Reports_ReportId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairsParts_Repairs_RepairId",
                table: "RepairsParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Reports_ReportId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Reports_ReportId1",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ReportId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ReportId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ReportId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ReportId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleTypes",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vehicles",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleProviders",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ReportTypes",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reports",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RepairedSystems",
                maxLength: 100,
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MonthlySalaries",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "ExternalRepairProviders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalRepairProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalRepairs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    VehicleId = table.Column<string>(nullable: false),
                    RepairedSystemId = table.Column<string>(nullable: false),
                    StartedOn = table.Column<DateTime>(nullable: false),
                    FinishedOn = table.Column<DateTime>(nullable: true),
                    MdmsUserId = table.Column<string>(nullable: false),
                    RepairCost = table.Column<decimal>(nullable: false),
                    HoursWorked = table.Column<double>(nullable: false),
                    ReportId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalRepairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalRepairs_AspNetUsers_MdmsUserId",
                        column: x => x.MdmsUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalRepairs_RepairedSystems_RepairedSystemId",
                        column: x => x.RepairedSystemId,
                        principalTable: "RepairedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalRepairs_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalRepairs_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalRepairs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    VehicleId = table.Column<string>(nullable: false),
                    RepairedSystemId = table.Column<string>(nullable: false),
                    StartedOn = table.Column<DateTime>(nullable: false),
                    FinishedOn = table.Column<DateTime>(nullable: true),
                    MdmsUserId = table.Column<string>(nullable: false),
                    RepairCost = table.Column<decimal>(nullable: false),
                    ExternalRepairProviderId = table.Column<string>(nullable: false),
                    LaborCost = table.Column<decimal>(nullable: false),
                    PartsCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalRepairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalRepairs_ExternalRepairProviders_ExternalRepairProviderId",
                        column: x => x.ExternalRepairProviderId,
                        principalTable: "ExternalRepairProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalRepairs_AspNetUsers_MdmsUserId",
                        column: x => x.MdmsUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalRepairs_RepairedSystems_RepairedSystemId",
                        column: x => x.RepairedSystemId,
                        principalTable: "RepairedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalRepairs_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRepairs_ExternalRepairProviderId",
                table: "ExternalRepairs",
                column: "ExternalRepairProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRepairs_MdmsUserId",
                table: "ExternalRepairs",
                column: "MdmsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRepairs_RepairedSystemId",
                table: "ExternalRepairs",
                column: "RepairedSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRepairs_VehicleId",
                table: "ExternalRepairs",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalRepairs_MdmsUserId",
                table: "InternalRepairs",
                column: "MdmsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalRepairs_Name",
                table: "InternalRepairs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InternalRepairs_RepairedSystemId",
                table: "InternalRepairs",
                column: "RepairedSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalRepairs_ReportId",
                table: "InternalRepairs",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalRepairs_VehicleId",
                table: "InternalRepairs",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairsParts_InternalRepairs_RepairId",
                table: "RepairsParts",
                column: "RepairId",
                principalTable: "InternalRepairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairsParts_InternalRepairs_RepairId",
                table: "RepairsParts");

            migrationBuilder.DropTable(
                name: "ExternalRepairs");

            migrationBuilder.DropTable(
                name: "InternalRepairs");

            migrationBuilder.DropTable(
                name: "ExternalRepairProviders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reports");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleTypes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vehicles",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportId1",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleProviders",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ReportTypes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RepairedSystems",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PartsProviders",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parts",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MonthlySalaries",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    FinishedOn = table.Column<DateTime>(nullable: true),
                    HoursWorked = table.Column<double>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MdmsUserId = table.Column<string>(nullable: true),
                    Mileage = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    RepairCost = table.Column<decimal>(nullable: false),
                    RepairedSystemId = table.Column<string>(nullable: false),
                    ReportId = table.Column<string>(nullable: true),
                    StartedOn = table.Column<DateTime>(nullable: false),
                    VehicleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_AspNetUsers_MdmsUserId",
                        column: x => x.MdmsUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repairs_RepairedSystems_RepairedSystemId",
                        column: x => x.RepairedSystemId,
                        principalTable: "RepairedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repairs_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ReportId",
                table: "Vehicles",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ReportId1",
                table: "Vehicles",
                column: "ReportId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ReportId",
                table: "AspNetUsers",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_MdmsUserId",
                table: "Repairs",
                column: "MdmsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_Name",
                table: "Repairs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_RepairedSystemId",
                table: "Repairs",
                column: "RepairedSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ReportId",
                table: "Repairs",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_VehicleId",
                table: "Repairs",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Reports_ReportId",
                table: "AspNetUsers",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairsParts_Repairs_RepairId",
                table: "RepairsParts",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Reports_ReportId",
                table: "Vehicles",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Reports_ReportId1",
                table: "Vehicles",
                column: "ReportId1",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
