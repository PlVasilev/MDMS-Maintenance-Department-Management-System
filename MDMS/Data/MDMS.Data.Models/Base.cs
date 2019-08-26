using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Data.Models
{
    public abstract class Base
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.NameLength, ErrorMessage = ModelConstants.StringLengthNameMessage + ModelConstants.NameLengthString)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
