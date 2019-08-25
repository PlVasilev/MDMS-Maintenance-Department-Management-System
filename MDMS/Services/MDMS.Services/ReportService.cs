using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Models;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Services
{
    public class ReportService : IReportService
    {
        private readonly MdmsDbContext _context;

        public ReportService(MdmsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCustomReport(ReportServiceModel reportServiceModel)
        {
            ReportType reportType = await _context.ReportTypes.SingleOrDefaultAsync(x => x.Name == "Custom");
            reportServiceModel.Name =
                $"Custom_{reportServiceModel.StartYear}_{reportServiceModel.StartMonth}_{reportServiceModel.EndYear}_{reportServiceModel.EndMonth}";

            if (await _context.Reports.AnyAsync(x => x.Name == reportServiceModel.Name))
                return false;

            var report = reportServiceModel.To<Report>();
            report.ReportType = reportType;

            report.VehiclesInReport =  _context.Vehicles
                    .Where(y => y.InternalRepairs
                                    .Any(x => x.FinishedOn != null &&
                                ((x.FinishedOn.Value.Year >= reportServiceModel.StartYear && x.FinishedOn.Value.Year <= reportServiceModel.EndYear)
                                 && (x.FinishedOn.Value.Month >= reportServiceModel.StartMonth && x.FinishedOn.Value.Month <= reportServiceModel.EndMonth)))
                    || y.ExternalRepairs
                        .Any(x => x.FinishedOn != null && 
                                                  ((x.FinishedOn.Value.Year >= reportServiceModel.StartYear && x.FinishedOn.Value.Year <= reportServiceModel.EndYear)
                                               && (x.FinishedOn.Value.Month >= reportServiceModel.StartMonth && x.FinishedOn.Value.Month <= reportServiceModel.EndMonth))))
                .Include(x => x.InternalRepairs).ThenInclude(x => x.InternalRepairParts).ThenInclude(x => x.Part)
                .Include(x => x.InternalRepairs).ThenInclude(x => x.MdmsUser)
                .Include(x => x.ExternalRepairs)
                .Distinct()
                .ToList();

            report.MonthlySalariesInReport = _context.MonthlySalaries
                .Where(x => (x.Year >= reportServiceModel.StartYear && x.Year <= reportServiceModel.EndYear) && 
                            (x.Month >= reportServiceModel.StartMonth && x.Month <= reportServiceModel.EndMonth)).ToList();

            report.MechanicsBaseCosts = report.MonthlySalariesInReport.Sum(x => x.BaseSalary);
            report.VehicleBaseCost = report.VehiclesInReport.Sum(x => x.Depreciation);
            report.ExternalRepairCosts =
                report.VehiclesInReport.Sum(x => x.ExternalRepairs.Sum(y => y.LaborCost + y.PartsCost));
            report.InternalRepairCosts = report.VehiclesInReport.Sum(x => x.InternalRepairs.Sum(y =>(decimal) y.HoursWorked * y.MdmsUser.AdditionalOnHourPayment) +
                x.InternalRepairs.Sum(y => y.InternalRepairParts.Sum(z => z.Quantity * z.Part.Price)));

            await _context.AddAsync(report);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public IQueryable<ReportServiceModel> GetAllReports() => 
            _context.Reports.Where(x => x.IsDeleted == false).OrderBy(x => x.Name).To<ReportServiceModel>();
    }
}
