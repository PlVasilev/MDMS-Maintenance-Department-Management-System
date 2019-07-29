using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
    public class ReportTypeServiceModel : BaseServiceModel
    {
        public ICollection<ReportServiceModel> Reports { get; set; } = new HashSet<ReportServiceModel>();
    }
}
