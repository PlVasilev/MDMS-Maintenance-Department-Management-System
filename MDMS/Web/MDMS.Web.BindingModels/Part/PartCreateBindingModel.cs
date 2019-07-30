using System;
using Microsoft.AspNetCore.Http;

namespace MDMS.Web.BindingModels
{
    public class PartCreateBindingModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    } 
}
