using System.Linq;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Models;
using MDMS.GlobalConstants;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Services
{
    public class PartService : IPartService
    {
        private readonly MdmsDbContext _context;

        public PartService(MdmsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(PartServiceModel partServiceModel)
        {
            if (_context.Parts.Any(v => v.Name == partServiceModel.Name))
                return false;

            Part part = AutoMapper.Mapper.Map<Part>(partServiceModel);
            part.AcquiredFrom = await GetPartProviderByName(partServiceModel.AcquiredFrom.Name);
            _context.Parts.Add(part);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddStock(string name, int addedStock)
        {
            var part = await _context.Parts.SingleOrDefaultAsync(x => x.Name == name);
            part.Stock += addedStock;
            _context.Update(part);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        private async Task<PartsProvider> GetPartProviderByName(string acquiredFromName) =>
            await _context.PartsProviders.SingleOrDefaultAsync(x => x.Name == acquiredFromName);

        public async Task<bool> CreatePartProvider(PartsProviderServiceModel partsProviderServiceModel)
        {
            if (_context.PartsProviders.Any(v => v.Name == partsProviderServiceModel.Name))
                return false;

            PartsProvider provider = AutoMapper.Mapper.Map<PartsProvider>(partsProviderServiceModel);
            _context.PartsProviders.Add(provider);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> EditPart(PartServiceModel partServiceModel)
        {
            var part = partServiceModel.To<Part>();
            part.AcquiredFrom = await GetPartProviderByName(partServiceModel.AcquiredFrom.Name);
            _context.Parts.Update(part);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeletePart(string name)
        {
            var part = await _context.Parts.SingleOrDefaultAsync(x => x.Name == name);
            part.IsDeleted = true;
            _context.Parts.Update(part);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


        public IQueryable<PartsProviderServiceModel> GetAllPartProviders() => _context.PartsProviders.OrderBy(x => x.Name).To<PartsProviderServiceModel>();
        public IQueryable<PartServiceModel> GetAllParts(string criteria)
        {
            switch (criteria)
            {
                case ServiceConstants.PartOrderByPriceAscending: return PartOrderByPriceAscending();
                case ServiceConstants.PartOrderByPriceDescending: return PartOrderByPriceDescending();
                case ServiceConstants.PartOrderByStockAscending: return PartOrderByStockAscending();
                case ServiceConstants.PartOrderByStockDescending: return PartOrderByStockDescending();
                case ServiceConstants.PartOrderByUsedCountAscending: return PartOrderByUsedCountAscending();
                case ServiceConstants.PartOrderByUsedCountDescending: return PartOrderByUsedCountDescending();
                default: return _context.Parts.Where(x => x.IsDeleted == false).OrderBy(x => x.Name).To<PartServiceModel>();
            }
        }

        public async Task<PartServiceModel> GetPartByName(string name) => await Task.Run(()
            => _context.Parts
                .Include(x => x.InternalRepairParts).ThenInclude(x => x.InternalRepair)
                .Include(x => x.AcquiredFrom)
                .SingleOrDefaultAsync(x => x.Name == name && x.IsDeleted == false).Result.To<PartServiceModel>());

        private IQueryable<PartServiceModel> PartOrderByPriceAscending() => _context.Parts.Where(x => x.IsDeleted == false).OrderBy(x => x.Price).To<PartServiceModel>();
        private IQueryable<PartServiceModel> PartOrderByPriceDescending() => _context.Parts.Where(x => x.IsDeleted == false).OrderByDescending(x => x.Price).To<PartServiceModel>();
        private IQueryable<PartServiceModel> PartOrderByStockAscending() => _context.Parts.Where(x => x.IsDeleted == false).OrderBy(x => x.Stock).To<PartServiceModel>();
        private IQueryable<PartServiceModel> PartOrderByStockDescending() => _context.Parts.Where(x => x.IsDeleted == false).OrderByDescending(x => x.Stock).To<PartServiceModel>();
        private IQueryable<PartServiceModel> PartOrderByUsedCountAscending() => _context.Parts.Where(x => x.IsDeleted == false).OrderBy(x => x.UsedCount).To<PartServiceModel>();
        private IQueryable<PartServiceModel> PartOrderByUsedCountDescending() => _context.Parts.Where(x => x.IsDeleted == false).OrderByDescending(x => x.UsedCount).To<PartServiceModel>();



    
    }
}
