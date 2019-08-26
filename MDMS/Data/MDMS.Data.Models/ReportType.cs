using System.Collections.Generic;

namespace MDMS.Data.Models
{
    public class ReportType : Base
    {
        public ICollection<Report> Reports { get; set; }  = new HashSet<Report>();
    }
}
