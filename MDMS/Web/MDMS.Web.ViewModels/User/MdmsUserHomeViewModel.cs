using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.User
{
    public class MdmsUserHomeViewModel : IMapFrom<MDMSUserServiceModel>
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAuthorized { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
