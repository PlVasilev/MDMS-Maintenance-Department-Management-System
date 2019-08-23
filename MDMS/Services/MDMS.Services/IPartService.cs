using System.Linq;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IPartService
    {
        Task<bool> Create(PartServiceModel partServiceModel);
        Task<bool> AddStock(string name, int addedStock);
        Task<bool> CreatePartProvider(PartsProviderServiceModel partsProviderServiceModel);
        Task<bool> EditPart(PartServiceModel partServiceModel);
        Task<bool> DeletePart(string name);

        IQueryable<PartsProviderServiceModel> GetAllPartProviders();
        IQueryable<PartServiceModel> GetAllParts();

        Task<PartServiceModel> GetPartByName(string name); 
    }
}
