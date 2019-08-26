using System.Linq;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IReportService
    {
       Task<bool> CreateCustomReport(ReportServiceModel reportServiceModel);
       Task<bool> DeleteReport(string name);
       Task<ReportServiceModel> GetReportDetails(string name);
       IQueryable<ReportServiceModel> GetAllReports();
    }
}
