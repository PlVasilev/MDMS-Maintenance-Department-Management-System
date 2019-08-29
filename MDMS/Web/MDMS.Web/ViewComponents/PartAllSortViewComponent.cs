using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.GlobalConstants;
using MDMS.Web.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace MDMS.Web.ViewComponents
{
    public class PartAllSortViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<string> orderByList = new List<string>
            {
               ServiceConstants.PartOrderName,
               ServiceConstants.PartOrderByPriceAscending,
               ServiceConstants.PartOrderByPriceDescending,
               ServiceConstants.PartOrderByStockAscending,
               ServiceConstants.PartOrderByStockDescending,
               ServiceConstants.PartOrderByUsedCountAscending,
               ServiceConstants.PartOrderByUsedCountDescending,
            };
            var partAllSortViewComponentModels = await Task.Run((() => 
                orderByList
                .Select(vt => new PartAllSortViewComponentViewModel() {Name = vt})
                .ToList())); 

            return View(partAllSortViewComponentModels);
        }
    }
}
