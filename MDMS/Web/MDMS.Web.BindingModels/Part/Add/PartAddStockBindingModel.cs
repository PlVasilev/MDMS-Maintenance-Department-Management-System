using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDMS.Web.BindingModels.Part.Add
{
    public class PartAddStockBindingModel
    {
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = " Must Be positive Number")]
        public int Quantity { get; set; }
    }
}
