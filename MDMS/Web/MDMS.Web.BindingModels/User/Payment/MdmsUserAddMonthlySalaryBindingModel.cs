using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.BindingModels.User.Payment
{
    public class MdmsUserAddMonthlySalaryBindingModel : IMapFrom<MDMSUserServiceModel>, IMapTo<MonthlySalaryServiceModel>,IHaveCustomMappings
    {
        [Range(ModelConstants.MonthMin, ModelConstants.MonthMax, ErrorMessage = ModelConstants.MonthRangeErrorMessage)]
        public int Month { get; set; } = DateTime.UtcNow.Month;

        [Range(ModelConstants.YearMin, ModelConstants.YearMax, ErrorMessage = ModelConstants.YearRangeErrorMessage)]
        public int Year { get; set; } = DateTime.UtcNow.Year;

        [Required]
        public string MechanicId { get; set; }

        [Required]
        public string Name{ get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal AdditionalOnHourPayment { get; set; }

        [Required]
        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal BaseSalary { get; set; }

        [Range(ModelConstants.IntPositiveMin, ModelConstants.IntMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public double HoursWorked { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MDMSUserServiceModel, MdmsUserAddMonthlySalaryBindingModel>()
                .ForMember(dest => dest.MechanicId, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(x => x.UserName));
        }
    }
}
