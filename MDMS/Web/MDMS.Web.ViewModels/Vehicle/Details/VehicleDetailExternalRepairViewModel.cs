using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Vehicle.Details
{
   public class VehicleDetailExternalRepairViewModel : IMapFrom<ExternalRepairServiceModel>
    {
        public string Name { get; set; }
    }
}
