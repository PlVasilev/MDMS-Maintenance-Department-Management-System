using System;
using System.Collections.Generic;
using System.Text;

namespace MDMS.Services.Models
{
    public abstract class BaseServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
