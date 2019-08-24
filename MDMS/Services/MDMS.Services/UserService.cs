using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDMS.Data;
using Mdms.Data.Models;
using MDMS.Data.Models;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<MdmsUser> _userManager;
        private readonly MdmsDbContext _context;

        public UserService(UserManager<MdmsUser> userManager, MdmsDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<MDMSUserServiceModel> GetCurrentUserByUsername(string username) => await Task.Run((() => 
            _userManager.Users.SingleOrDefault(u => username == u.UserName).To<MDMSUserServiceModel>()));

        public async Task<MDMSUserServiceModel> GetCurrentUserByEmail(string email) => await Task.Run((() =>
            _userManager.Users.SingleOrDefault(u => email == u.Email).To<MDMSUserServiceModel>()));


        public async Task<bool> DeleteUser(string id)
        {
            var user = _context.Users.Find(id);
            user.IsDeleted = true;
            _context.Update(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> RestoreUser(string id)
        {
            var user = _context.Users.Find(id);
            user.IsDeleted = false;
            _context.Update(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> ActivateUser(string id)
        {
            var user = _context.Users.Find(id);
            user.IsAuthorized = true;
            await _userManager.AddToRoleAsync(user, "User");
            _context.Update(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeActivateUser(string id)
        {
            var user = _context.Users.Find(id);
            user.IsAuthorized = false;
            await _userManager.RemoveFromRoleAsync(user, "User");
            _context.Update(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddSalary(MonthlySalaryServiceModel monthlySalaryServiceModel)
        {
            var salary = monthlySalaryServiceModel.To<MonthlySalary>();
            salary.Name = monthlySalaryServiceModel.Name + "_" + monthlySalaryServiceModel.Year + "_" +
                          monthlySalaryServiceModel.Month;

            if (await _context.MonthlySalaries.AnyAsync(x=> x.Name == salary.Name)) return false;
            
            salary.HoursWorked = _context.InternalRepairs
                .Where(x => x.FinishedOn != null && (x.MdmsUserId == monthlySalaryServiceModel.MechanicId
                             && x.FinishedOn.Value.Month == monthlySalaryServiceModel.Month
                                && x.FinishedOn.Value.Year == monthlySalaryServiceModel.Year))
                .Sum(x => x.HoursWorked);
            salary.TotalSalary = (decimal)salary.HoursWorked * salary.AdditionalOnHourPayment + salary.BaseSalary;

            await _context.MonthlySalaries.AddAsync(salary);
            var result = _context.SaveChangesAsync();
            return await result > 0;
        }

        public async Task<bool> EditPayment(MDMSUserServiceModel serviceModel)
        {
            var user = await _context.Users.FindAsync(serviceModel.Id);
            user.BaseSalary = serviceModel.BaseSalary;
            user.AdditionalOnHourPayment = serviceModel.AdditionalOnHourPayment;
            _context.Update(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public IQueryable<MDMSUserServiceModel> GetAllUsers() => _context.Users.To<MDMSUserServiceModel>();

    }
}
