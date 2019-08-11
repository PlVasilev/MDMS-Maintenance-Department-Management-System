using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IUserService
    {
        Task<MDMSUserServiceModel> GetCurrentUserByUsername(string username);
        Task<MDMSUserServiceModel> GetCurrentUserByEmail(string email);

        Task<bool> DeleteUser(string id);
        Task<bool> RestoreUser(string id);
        Task<bool> ActivateUser(string id);
        Task<bool> DeActivateUser(string id);
        Task<bool> EditPayment(MDMSUserServiceModel userServiceModel);
        IQueryable<MDMSUserServiceModel> GetAllUsers();


    }
}
