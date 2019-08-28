using System.Reflection;
using MDMS.Data.Models;
using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Tests.Common
{
    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(PartServiceModel).GetTypeInfo().Assembly,
                typeof(Part).GetTypeInfo().Assembly);
        }
    }
}
