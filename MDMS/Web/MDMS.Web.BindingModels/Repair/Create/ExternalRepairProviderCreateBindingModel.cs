using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Repair.Create
{
    public class ExternalRepairProviderCreateBindingModel : IMapTo<ExternalRepairProviderServiceModel>
    {
        public string Name { get; set; }
    }
}
