using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
    public class PartsProviderServiceModel : BaseServiceModel
    {
        public ICollection<PartServiceModel> PartsBought { get; set; } = new HashSet<PartServiceModel>();
    }
}
