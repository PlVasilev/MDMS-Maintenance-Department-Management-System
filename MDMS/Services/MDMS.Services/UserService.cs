using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mdms.Data.Models;
using MDMS.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<MdmsUser> _userManager;

        public UserService(UserManager<MdmsUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<MDMSUserServiceModel> GetCurrentUserByUsername(string username)
        {
            MDMSUserServiceModel userServiceModel = AutoMapper.Mapper.Map<MDMSUserServiceModel>(await _userManager.Users.SingleOrDefaultAsync(u => username == u.UserName));
            return userServiceModel;
        }

        public async Task<MDMSUserServiceModel> GetCurrentUserByEmail(string email)
        {
            MDMSUserServiceModel userServiceModel = AutoMapper.Mapper.Map<MDMSUserServiceModel>(await _userManager.Users.SingleOrDefaultAsync(u => email == u.Email));
            return userServiceModel;
        }
    }
}
