using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MDMS.Web.BindingModels
{
   public class VehicleCreateBindingModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string VSN { get; set; }

        public string AcquiredBy { get; set; }

        public DateTime AcquiredOn { get; set; }

        public decimal Price { get; set; }

        public decimal Depreciation { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public string VehicleType { get; set; }

        public IFormFile Picture { get; set; }

    }
}
