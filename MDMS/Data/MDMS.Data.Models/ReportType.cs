using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Data.Models
{
    public class ReportType : Base
    {
        public ICollection<Report> Reports { get; set; }  = new HashSet<Report>();
    }
}
