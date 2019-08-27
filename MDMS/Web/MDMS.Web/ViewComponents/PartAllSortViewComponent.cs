using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                "None",
                "Price From Lowest To Highest",
                "Price From Highest To Lowest",
                "Stock From Lowest To Highest",
                "Stock From Highest To Lowest",
                "Used From Lowest To Highest",
                "Used From Highest To Lowest"
            };
            var partAllSortViewComponentModels = await Task.Run((() => 
                orderByList
                .Select(vt => new PartAllSortViewComponentViewModel() {Name = vt})
                .ToList())); 

            return View(partAllSortViewComponentModels);
        }
    }
}
