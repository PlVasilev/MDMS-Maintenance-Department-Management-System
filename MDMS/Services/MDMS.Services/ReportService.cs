﻿using System;
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

            report.VehiclesInReport = GetVehiclesInReport(reportServiceModel.StartMonth, reportServiceModel.StartYear,
                reportServiceModel.EndMonth, reportServiceModel.EndYear);

            report.MonthlySalariesInReport = _context.MonthlySalaries
                .Where(x => (x.Year >= reportServiceModel.StartYear && x.Year <= reportServiceModel.EndYear) && 
                            (x.Month >= reportServiceModel.StartMonth && x.Month <= reportServiceModel.EndMonth)).ToList();

            report.MechanicsBaseCosts = report.MonthlySalariesInReport.Sum(x => x.BaseSalary);
            report.VehicleBaseCost = report.VehiclesInReport.Sum(x => x.Depreciation);
            report.ExternalRepairCosts = report.VehiclesInReport.Sum(x => x.ExternalRepairs.Sum(y => y.LaborCost + y.PartsCost));
            report.InternalRepairCosts = report.VehiclesInReport.Sum(x => x.InternalRepairs.Sum(y =>(decimal) y.HoursWorked * y.MdmsUser.AdditionalOnHourPayment) +
                x.InternalRepairs.Sum(y => y.InternalRepairParts.Sum(z => z.Quantity * z.Part.Price)));

            await _context.AddAsync(report);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteReport(string name)
        {
            var report = await _context.Reports.SingleOrDefaultAsync(x => x.Name == name);
            _context.Remove(report);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ReportServiceModel> GetReportDetails(string name)
        {
            var reportDetails = await _context.Reports.SingleOrDefaultAsync(x => x.Name == name);
            reportDetails.VehiclesInReport = GetVehiclesInReport(reportDetails.StartMonth, reportDetails.StartYear,
                reportDetails.EndMonth, reportDetails.EndYear);
            reportDetails.MonthlySalariesInReport = _context.MonthlySalaries
                .Where(x => (x.Year >= reportDetails.StartYear && x.Year <= reportDetails.EndYear) &&
                            (x.Month >= reportDetails.StartMonth && x.Month <= reportDetails.EndMonth))
                .Include(x => x.Mechanic)
                .ToList();
            var reportDetailsService = reportDetails.To<ReportServiceModel>();
            return reportDetailsService;
        }

        public IQueryable<ReportServiceModel> GetAllReports() => 
            _context.Reports.Where(x => x.IsDeleted == false).OrderBy(x => x.Name).To<ReportServiceModel>();

        private List<Vehicle> GetVehiclesInReport(int startM, int startY,int endM, int endY)
        {
           var vehicles = _context.Vehicles
                .Where(y => y.InternalRepairs
                                .Any(x => x.FinishedOn != null &&
                                          ((x.FinishedOn.Value.Year >= startY && x.FinishedOn.Value.Year <= endY)
                                           && (x.FinishedOn.Value.Month >= startM && x.FinishedOn.Value.Month <= endM)))
                            || y.ExternalRepairs
                                .Any(x => x.FinishedOn != null &&
                                          ((x.FinishedOn.Value.Year >= startY && x.FinishedOn.Value.Year <= endY)
                                           && (x.FinishedOn.Value.Month >= startM && x.FinishedOn.Value.Month <= endM))))
                .Include(x => x.InternalRepairs).ThenInclude(x => x.InternalRepairParts).ThenInclude(x => x.Part)
                .Include(x => x.InternalRepairs).ThenInclude(x => x.MdmsUser)
                .Include(x => x.InternalRepairs).ThenInclude(x => x.RepairedSystem)
                .Include(x => x.ExternalRepairs).ThenInclude(x => x.ExternalRepairProvider)
                .Include(x => x.ExternalRepairs).ThenInclude(x => x.RepairedSystem)
                .Distinct()
                .ToList();

           return vehicles;
        }
    }
}
