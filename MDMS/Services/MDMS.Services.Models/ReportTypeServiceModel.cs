using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
    public class ReportTypeServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<ReportServiceModel> Reports { get; set; } = new HashSet<ReportServiceModel>();
    }
}
