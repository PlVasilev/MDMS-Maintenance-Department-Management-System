using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IUserService
    {
        Task<MDMSUserServiceModel> GetCurrentUserByUsername(string username);
        Task<MDMSUserServiceModel> GetCurrentUserByEmail(string email);

       
    }
}
