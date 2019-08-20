using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Web.BindingModels.Repair.Add
{
    public class InternalRepairAddPartsBindingModel
    {
        public string Name { get; set; }

        public List<InternalRepairRepairPartBindingModel> RepairParts = new List<InternalRepairRepairPartBindingModel>();
    }
}
