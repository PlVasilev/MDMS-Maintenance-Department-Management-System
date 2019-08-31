using System.Collections.Generic;

namespace MDMS.Services.Models
{
    public class ReportTypeServiceModel : BaseServiceModel
    {
        public ICollection<ReportServiceModel> Reports { get; set; } = new HashSet<ReportServiceModel>();
    }
}
