using System.ComponentModel.DataAnnotations;
using MDMS.GlobalConstants;

namespace MDMS.Web.BindingModels.Part.Add
{
    public class PartAddStockBindingModel
    {
        public string Name { get; set; }

        [Range(ModelConstants.IntPositiveMin, ModelConstants.IntMax, ErrorMessage = ModelConstants.PositiveNumberErrorMessage)]
        public int Quantity { get; set; }
    }
}
