using System;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Repair.Home
{
   public class InternalRepairActiveHomeViewModel : IMapFrom<InternalRepairServiceModel>
    {
        public string Name { get; set; }
        public string VehicleMake { get; set; }
        public string VehiclePicture { get; set; }
        public string VehicleModel { get; set; }
        public string RepairedSystemName { get; set; }
        public string MdmsUserUsername { get; set; }
        public DateTime StartedOn { get; set; }
    }
}
