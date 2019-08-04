﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Web.ViewModels.Part;
using MDMS.Web.ViewModels.Repair;

namespace MDMS.Web.ViewModels.Vehicle.Details
{
    public class VehicleDetailsViewModel : IMapFrom<VehicleServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string VSN { get; set; }

        public string VehicleProviderId { get; set; }

        public string VehicleProvider { get; set; }

        public DateTime AcquiredOn { get; set; }

        public decimal Price { get; set; }

        public decimal Depreciation { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public string Picture { get; set; }

        //public ICollection<InternalRepairViewModel> InternalRepairs { get; set; } = new HashSet<InternalRepairViewModel>();
        //public ICollection<ExternalRepairViewModel> ExternalRepairs { get; set; } = new HashSet<ExternalRepairViewModel>();

        public string VehicleType { get; set; }

        public bool IsActive { get; set; } = false;

        public int Mileage { get; set; }

        public string RegistrationNumber { get; set; }

        public bool IsInRepair { get; set; } = false;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<VehicleServiceModel, VehicleDetailsViewModel>()
                .ForMember(dest => dest.VehicleProvider, opts => opts.MapFrom(x => x.VehicleProvider.Name))
                .ForMember(dest => dest.VehicleType, opts => opts.MapFrom(x => x.VehicleType.Name));

        }
    }
}
