using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Part.Details
{
    public class PartDetailsViewModel : IMapFrom<PartServiceModel>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int UsedCount { get; set; }
        
        public string AcquiredFromName { get; set; }

        public List<PartDetailsInternalRepairPartViewModel> InternalRepairParts { get; set; } = new List<PartDetailsInternalRepairPartViewModel>();

        [Range(0, int.MaxValue, ErrorMessage = " Must Be positive Number")]
        public int Quantity { get; set; }
        public int Stock { get; set; }
    }
}
