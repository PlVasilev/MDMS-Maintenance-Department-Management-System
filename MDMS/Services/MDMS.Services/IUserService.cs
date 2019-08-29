using System.Linq;
using System.Threading.Tasks;
using MDMS.Services.Models;

namespace MDMS.Services
{
    public interface IUserService
    {
        Task<bool> DeleteUser(string id);
        Task<bool> RestoreUser(string id);
        Task<bool> ActivateUser(string id);
        Task<bool> DeActivateUser(string id);
        Task<bool> AddSalary(MonthlySalaryServiceModel monthlySalaryServiceModel);
        Task<bool> EditPayment(MDMSUserServiceModel userServiceModel);

        Task<MDMSUserServiceModel> GetCurrentUserByUsername(string username);
        IQueryable<MDMSUserServiceModel> GetAllUsers();


    }
}
