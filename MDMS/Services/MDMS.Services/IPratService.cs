using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MDMS.Web.BindingModels;

namespace MDMS.Services
{
    public interface IPratService
    {
        bool Create(VehicleCreateBindingModel vehicleCreateBindingModel);
    }
}
