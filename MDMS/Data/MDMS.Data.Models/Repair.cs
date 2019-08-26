using System;
using System.ComponentModel.DataAnnotations;
using Mdms.Data.Models;
using MDMS.GlobalConstants;

namespace MDMS.Data.Models
{
   public abstract class Repair : Base
    {
        [Required]
        [MaxLength(ModelConstants.NameLengthLg, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthStringLg)]
        public string Description { get; set; }

        [Required]
        public string VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [Range(ModelConstants.IntPositiveMin, ModelConstants.IntMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public int Mileage { get; set; }

        [Required]
        public string RepairedSystemId { get; set; }
        public RepairedSystem RepairedSystem { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartedOn { get; set; }

        public DateTime? FinishedOn { get; set; } = null;

        [Required]
        public string MdmsUserId { get; set; }
        public MdmsUser MdmsUser { get; set; }

        [Range(typeof(decimal), ModelConstants.DecimalPositiveMin, ModelConstants.DecimalMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public decimal RepairCost { get; set; } 
    }
}
