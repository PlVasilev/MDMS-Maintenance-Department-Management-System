using MDMS.Data.Models;
using MDMS.Services.Mapping;

namespace MDMS.Services.Models
{
    public abstract class BaseServiceModel: IMapFrom<Base>, IMapTo<Base>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
