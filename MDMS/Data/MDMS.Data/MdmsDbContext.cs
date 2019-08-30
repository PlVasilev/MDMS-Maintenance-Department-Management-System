using Mdms.Data.Models;
using MDMS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MDMS.Data
{
    public class MdmsDbContext : IdentityDbContext<MdmsUser,IdentityRole,string>
    {
        public DbSet<MonthlySalary> MonthlySalaries { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartsProvider> PartsProviders { get; set; }
        public DbSet<InternalRepair> InternalRepairs { get; set; }
        public DbSet<ExternalRepair> ExternalRepairs { get; set; }
        public DbSet<RepairedSystem> RepairedSystems { get; set; }
        public DbSet<InternalRepairPart> InternalsRepairParts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleProvider> VehicleProviders { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<ExternalRepairProvider> ExternalRepairProviders { get; set; }
       


        public MdmsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MdmsUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Vehicle>()
                .HasIndex(v => v.VSN)
                .IsUnique();

            builder.Entity<VehicleProvider>()
                .HasIndex(vp => vp.Name)
                .IsUnique();

            builder.Entity<VehicleType>()
                .HasIndex(vt => vt.Name)
                .IsUnique();

            builder.Entity<MonthlySalary>()
                .HasIndex(ms => ms.Name)
                .IsUnique();

            builder.Entity<Part>()
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Entity<PartsProvider>()
                .HasIndex(pp => pp.Name)
                .IsUnique();

            builder.Entity<InternalRepair>()
                .HasIndex(r => r.Name)
                .IsUnique();

            builder.Entity<RepairedSystem>()
                .HasIndex(rs => rs.Name)
                .IsUnique();

            builder.Entity<ReportType>()
                .HasIndex(rt => rt.Name)
                .IsUnique();


            builder.Entity<InternalRepairPart>()
                .HasKey(k => new { k.InternalRepairId, k.PartId });

            builder.Entity<InternalRepairPart>()
                .HasOne(rp => rp.InternalRepair)
                .WithMany(r => r.InternalRepairParts)
                .HasForeignKey(rp => rp.InternalRepairId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<InternalRepairPart>()
                .HasOne(rp => rp.Part)
                .WithMany(p => p.InternalRepairParts)
                .HasForeignKey(rp => rp.PartId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
    }
}
