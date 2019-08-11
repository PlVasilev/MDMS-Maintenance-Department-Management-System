using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.User.Payment
{
    public class MdmsUserAddMonthlySalaryBindingModel : IMapFrom<MDMSUserServiceModel>, IMapTo<MonthlySalaryServiceModel>,IHaveCustomMappings
    {
        [Range(1, 12)] public int Month { get; set; } = DateTime.UtcNow.Month;

        [Range(1900, 2200)] public int Year { get; set; } = DateTime.UtcNow.Year;

        [Required]
        public string MechanicId { get; set; }

        [Required]
        public string Name{ get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999")]
        public decimal AdditionalOnHourPayment { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999999")]
        public decimal BaseSalary { get; set; }

        [Range(0, 1000)]
        public double HoursWorked { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MDMSUserServiceModel, MdmsUserAddMonthlySalaryBindingModel>()
                .ForMember(dest => dest.MechanicId, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(x => x.UserName));
        }
    }
}
