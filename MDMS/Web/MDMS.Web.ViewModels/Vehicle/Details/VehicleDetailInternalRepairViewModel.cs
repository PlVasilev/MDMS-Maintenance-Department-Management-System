using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Vehicle.Details
{
    public class VehicleDetailInternalRepairViewModel : IMapFrom<InternalRepairServiceModel>
    {
        public string Name { get; set; }
    }
}
