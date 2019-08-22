using System.Linq;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IPartService
    {
        Task<bool> Create(PartServiceModel partServiceModel);

        Task<bool> CreatePartProvider(PartsProviderServiceModel partsProviderServiceModel);

        IQueryable<PartsProviderServiceModel> GetAllPartProviders();

        IQueryable<PartServiceModel> GetAllParts();

        Task<PartServiceModel> GetPartByName(string name); 
    }
}
