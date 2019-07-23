using Mdms.Data.Models;
using MDMS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MDMS.Data
{
    public class MdmsDbContext : IdentityDbContext<MdmsUser,IdentityRole,string>
    {
        public DbSet<MdmsUserRepair> MdmsUsersRepairs { get; set; }
        public DbSet<MonthlySalary> MonthlySalaries { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartsProvider> PartsProviders { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairedSystem> RepairedSystems { get; set; }
        public DbSet<RepairPart> RepairsParts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleProvider> VehicleProviders { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }


        public MdmsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MdmsUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Vehicle>()
                .HasIndex(u => u.VSN)
                .IsUnique();

            builder.Entity<MdmsUserRepair>()
                .HasKey(k => new { k.MdmsUserId, k.RepairId });

            builder.Entity<MdmsUserRepair>()
                .HasOne(ur => ur.MdmsUser)
                .WithMany(u => u.MdmsUserRepairs)
                .HasForeignKey(ur => ur.MdmsUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MdmsUserRepair>()
                .HasOne(ur => ur.Repair)
                .WithMany(r => r.MdmsUserRepairs)
                .HasForeignKey(ur => ur.RepairId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RepairPart>()
                .HasKey(k => new { k.RepairId, k.PartId });

            builder.Entity<RepairPart>()
                .HasOne(rp => rp.Repair)
                .WithMany(r => r.RepairParts)
                .HasForeignKey(rp => rp.RepairId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RepairPart>()
                .HasOne(rp => rp.Part)
                .WithMany(p => p.RepairParts)
                .HasForeignKey(rp => rp.PartId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
