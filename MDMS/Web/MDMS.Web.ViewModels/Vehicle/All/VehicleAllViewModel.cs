using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.Vehicle.All
{
    public class VehicleAllViewModel : IMapFrom<VehicleServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Make { get; set; }
        
        public string Model { get; set; }

        public string VSN { get; set; }

        public string Picture { get; set; }
    }
}
