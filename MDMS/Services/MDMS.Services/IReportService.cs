using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IReportService
    {
       Task<bool> CreateCustomReport(ReportServiceModel reportServiceModel);

       IQueryable<ReportServiceModel> GetAllReports();
    }
}
