﻿using MDMS.Services.Mapping;
using MDMS.Services.Models;

namespace MDMS.Web.ViewModels.User
{
   public class MDMSUserAllViewModel : IMapFrom<MDMSUserServiceModel>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public bool IsRepairing { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BaseSalary { get; set; }
        public string Email { get; set; }
        public decimal AdditionalOnHourPayment { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAuthorized { get; set; } = false;
    }
}
