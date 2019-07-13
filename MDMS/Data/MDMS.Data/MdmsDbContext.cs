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
    }
}
