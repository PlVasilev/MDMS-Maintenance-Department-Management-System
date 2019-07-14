﻿// <auto-generated />
using System;
using MDMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MDMS.Data.Migrations
{
    [DbContext(typeof(MdmsDbContext))]
    partial class MdmsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MDMS.Data.Models.MdmsUserRepair", b =>
                {
                    b.Property<string>("MdmsUserId");

                    b.Property<string>("RepairId");

                    b.Property<double>("HoursWorked");

                    b.HasKey("MdmsUserId", "RepairId");

                    b.HasIndex("RepairId");

                    b.ToTable("MdmsUsersRepairs");
                });

            modelBuilder.Entity("MDMS.Data.Models.MonthlySalary", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("HoursWorked");

                    b.Property<string>("MechanicId");

                    b.Property<int>("Month");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("MechanicId");

                    b.ToTable("MonthlySalaries");
                });

            modelBuilder.Entity("MDMS.Data.Models.Part", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PartsProviderId")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("Stock");

                    b.HasKey("Id");

                    b.HasIndex("PartsProviderId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("MDMS.Data.Models.PartsProvider", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("PartsProviders");
                });

            modelBuilder.Entity("MDMS.Data.Models.Repair", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("FinishedOn");

                    b.Property<int>("Mileage");

                    b.Property<string>("RepairedSystemId")
                        .IsRequired();

                    b.Property<string>("ReportId");

                    b.Property<string>("ReportId1");

                    b.Property<DateTime>("StartedOn");

                    b.Property<string>("VehicleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RepairedSystemId");

                    b.HasIndex("ReportId");

                    b.HasIndex("ReportId1");

                    b.HasIndex("VehicleId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("MDMS.Data.Models.RepairPart", b =>
                {
                    b.Property<string>("RepairId");

                    b.Property<string>("PartId");

                    b.Property<int>("Quantity");

                    b.HasKey("RepairId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("RepairsParts");
                });

            modelBuilder.Entity("MDMS.Data.Models.RepairedSystem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("RepairedSystems");
                });

            modelBuilder.Entity("MDMS.Data.Models.Report", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ReportTypeId")
                        .IsRequired();

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("ReportTypeId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("MDMS.Data.Models.ReportType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ReportTypes");
                });

            modelBuilder.Entity("MDMS.Data.Models.Vehicle", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AcquiredOn");

                    b.Property<decimal>("Depreciation");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("ManufacturedOn");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ReportId");

                    b.Property<string>("ReportId1");

                    b.Property<string>("VSN")
                        .IsRequired();

                    b.Property<string>("VehicleProviderId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.HasIndex("ReportId1");

                    b.HasIndex("VehicleProviderId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("MDMS.Data.Models.VehicleProvider", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("VehicleProviders");
                });

            modelBuilder.Entity("MDMS.Data.Models.VehicleType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Mdms.Data.Models.MdmsUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<decimal>("AdditionalOnHourPayment");

                    b.Property<decimal>("BaseSalary");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("IsAuthorized");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ReportId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ReportId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MDMS.Data.Models.MdmsUserRepair", b =>
                {
                    b.HasOne("Mdms.Data.Models.MdmsUser", "MdmsUser")
                        .WithMany("MdmsUserRepairs")
                        .HasForeignKey("MdmsUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MDMS.Data.Models.Repair", "Repair")
                        .WithMany("MdmsUserRepairs")
                        .HasForeignKey("RepairId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MDMS.Data.Models.MonthlySalary", b =>
                {
                    b.HasOne("Mdms.Data.Models.MdmsUser", "Mechanic")
                        .WithMany("Salaries")
                        .HasForeignKey("MechanicId");
                });

            modelBuilder.Entity("MDMS.Data.Models.Part", b =>
                {
                    b.HasOne("MDMS.Data.Models.PartsProvider", "AcquiredFrom")
                        .WithMany("PartsBought")
                        .HasForeignKey("PartsProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MDMS.Data.Models.Repair", b =>
                {
                    b.HasOne("MDMS.Data.Models.RepairedSystem", "RepairedSystem")
                        .WithMany()
                        .HasForeignKey("RepairedSystemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MDMS.Data.Models.Report")
                        .WithMany("Repairs")
                        .HasForeignKey("ReportId");

                    b.HasOne("MDMS.Data.Models.Report")
                        .WithMany("RepairsInReport")
                        .HasForeignKey("ReportId1");

                    b.HasOne("MDMS.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Repairs")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MDMS.Data.Models.RepairPart", b =>
                {
                    b.HasOne("MDMS.Data.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MDMS.Data.Models.Repair", "Repair")
                        .WithMany("RepairParts")
                        .HasForeignKey("RepairId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MDMS.Data.Models.Report", b =>
                {
                    b.HasOne("MDMS.Data.Models.ReportType", "ReportType")
                        .WithMany()
                        .HasForeignKey("ReportTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MDMS.Data.Models.Vehicle", b =>
                {
                    b.HasOne("MDMS.Data.Models.Report")
                        .WithMany("RepairedVehicles")
                        .HasForeignKey("ReportId");

                    b.HasOne("MDMS.Data.Models.Report")
                        .WithMany("Vehicles")
                        .HasForeignKey("ReportId1");

                    b.HasOne("MDMS.Data.Models.VehicleProvider", "AcquiredBy")
                        .WithMany("VehiclesBought")
                        .HasForeignKey("VehicleProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mdms.Data.Models.MdmsUser", b =>
                {
                    b.HasOne("MDMS.Data.Models.Report")
                        .WithMany("Users")
                        .HasForeignKey("ReportId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Mdms.Data.Models.MdmsUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Mdms.Data.Models.MdmsUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mdms.Data.Models.MdmsUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Mdms.Data.Models.MdmsUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
