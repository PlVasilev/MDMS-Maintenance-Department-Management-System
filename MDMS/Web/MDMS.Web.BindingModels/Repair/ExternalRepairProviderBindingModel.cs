using System;
using System.Collections.Generic;
using System.Text;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.Repair
{
    public class ExternalRepairProviderBindingModel : IMapTo<ExternalRepairProviderServiceModel>
    {
        public string Name { get; set; }
    }
}
