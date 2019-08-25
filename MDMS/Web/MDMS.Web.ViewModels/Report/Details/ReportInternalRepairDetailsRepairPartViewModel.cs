using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Web.ViewModels.Report.Details
{
    public class ReportInternalRepairDetailsRepairPartViewModel
    {
        public string PartName { get; set; }
        public bool PartIsDeleted { get; set; }
        public string PartAcquiredFromName { get; set; }
        public decimal PartPrice { get; set; }
        public int Quantity { get; set; }
    }
}
