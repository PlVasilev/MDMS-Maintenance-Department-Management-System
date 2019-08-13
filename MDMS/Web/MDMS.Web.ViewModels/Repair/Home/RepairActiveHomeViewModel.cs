using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.ViewModels.Part;

namespace MDMS.Web.ViewModels.Repair.Home
{
    public class RepairActiveHomeViewModel 
    {
        public List<ExternalRepairActiveHomeViewModel> ExternalRepairActiveHomeViewModels = new List<ExternalRepairActiveHomeViewModel>();
        public List<InternalRepairActiveHomeViewModel> InternalRepairActiveHomeViewModels = new List<InternalRepairActiveHomeViewModel>();


    }
}
