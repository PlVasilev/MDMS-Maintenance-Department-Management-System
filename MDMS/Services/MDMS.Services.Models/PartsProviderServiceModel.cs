using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
    public class PartsProviderServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<PartServiceModel> PartsBought { get; set; } = new HashSet<PartServiceModel>();
    }
}
