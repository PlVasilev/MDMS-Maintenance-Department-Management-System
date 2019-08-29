using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Data;
using Mdms.Data.Models;
using MDMS.Data.Models;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Tests.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace MDMS.Tests.ServiceTests
{
    public class FakeUserManager : UserManager<MdmsUser>
    {
        public FakeUserManager()
            : base(new Mock<IUserStore<MdmsUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<MdmsUser>>().Object,
                new IUserValidator<MdmsUser>[0],
                new IPasswordValidator<MdmsUser>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<MdmsUser>>>().Object)
        { }
    }
    public class UserServiceTests
    {
        private IUserService _userService;

        private List<MdmsUser> GetUserDummyData()
        {

            return new List<MdmsUser>()
            {
                new MdmsUser()
                {
                    Id = "U1",
                    UserName = "Pesho",
                    FirstName = "Pesho",
                    LastName = "Peshov",
                    AdditionalOnHourPayment = 50m,
                    BaseSalary = 3000m,
                    Email = "Pesho@peshov.com,",
                    IsRepairing = false,
                    IsDeleted = false,
                    IsAuthorized = true,
                    Salaries = new List<MonthlySalary>
                    {new MonthlySalary()
                    {
                        Name = "S1_2019_2",
                        Month = 1,
                        Year = 2019,
                        HoursWorked = 10,
                        BaseSalary = 3000,
                        MechanicId = "U1",
                        TotalSalary = 3500m
                    }}
                },
                new MdmsUser()
                {
                Id = "U2",
                UserName = "Pesho2",
                FirstName = "Pesho2",
                LastName = "Peshov2",
                AdditionalOnHourPayment = 0m,
                BaseSalary = 3000m,
                Email = "Pesho2@peshov2.com,",
                IsRepairing = true,
                IsDeleted = false,
                IsAuthorized = true,
                },
                new MdmsUser()
                {
                    Id = "U3",
                    UserName = "Pesho3",
                    FirstName = "Pesho3",
                    LastName = "Peshov3",
                    AdditionalOnHourPayment = 0m,
                    BaseSalary = 3000m,
                    Email = "Pesho3@peshov3.com,",
                    IsRepairing = false,
                    IsDeleted = false,
                    IsAuthorized = false
                },
                new MdmsUser()
                {
                Id = "U4",
                UserName = "Pesho4",
                FirstName = "Pesho4",
                LastName = "Peshov4",
                AdditionalOnHourPayment = 0m,
                BaseSalary = 3000m,
                Email = "Pesho4@peshov4.com,",
                IsRepairing = false,
                IsDeleted = true,
                IsAuthorized = false
            }
            };

        }


        private List<MonthlySalary> AddSalaries()
        {
            return new List<MonthlySalary>()
            { new MonthlySalary()
            {
                Name = "S1_2019_2",
                Month = 2,
                Year = 2019,
                HoursWorked = 10,
                BaseSalary = 3000,
                MechanicId = "U1",
                TotalSalary = 3500m
                }
            };
        }

        private async Task SeedDataSalary(MdmsDbContext context)
        {
            context.AddRange(AddSalaries());
            await context.SaveChangesAsync();
        }

        private async Task SeedData(MdmsDbContext context)
        {
            context.AddRange(GetUserDummyData());
            await context.SaveChangesAsync();
        }

        public UserServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetCurrentUserByUsername_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "UserService GetCurrentUserByUsername() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);

            _userService = new UserService(new FakeUserManager(), context);

            MDMSUserServiceModel actualResults = await _userService.GetCurrentUserByUsername("Pesho");
            MDMSUserServiceModel expectedResults = context.Users.SingleOrDefault(x => x.UserName == "Pesho").To<MDMSUserServiceModel>();

            Assert.True(actualResults.Id == expectedResults.Id, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(actualResults.Name == expectedResults.Name, errorMessagePrefix + " " + "Name is not returned properly.");
            Assert.True(actualResults.FirstName == expectedResults.FirstName, errorMessagePrefix + " " + "FirstName is not returned properly.");
            Assert.True(actualResults.LastName == expectedResults.LastName, errorMessagePrefix + " " + "LastName is not returned properly.");
            Assert.True(actualResults.Email == expectedResults.Email, errorMessagePrefix + " " + "Email is not returned properly.");
            Assert.True(actualResults.AdditionalOnHourPayment == expectedResults.AdditionalOnHourPayment, errorMessagePrefix + " " + "AdditionalOnHourPayment is not returned properly.");
            Assert.True(actualResults.BaseSalary == expectedResults.BaseSalary, errorMessagePrefix + " " + "BaseSalary is not returned properly.");
            Assert.True(actualResults.IsDeleted == expectedResults.IsDeleted, errorMessagePrefix + " " + "IsDeleted is not returned properly.");
            Assert.True(actualResults.IsRepairing == expectedResults.IsRepairing, errorMessagePrefix + " " + "IsRepairing is not returned properly.");
            Assert.True(actualResults.IsAuthorized == expectedResults.IsAuthorized, errorMessagePrefix + " " + "IsAuthorized is not returned properly.");
        }

        [Fact]
        public async Task GetCurrentUserByUsername_WithNonExistentName_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _userService.GetCurrentUserByUsername("Name"));
        }

        [Fact]
        public async Task GetAllUsers_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "UserService GetAllUsers() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            List<MDMSUserServiceModel> actualResults = await _userService.GetAllUsers().ToListAsync();
            List<MDMSUserServiceModel> expectedResults = context.Users.To<MDMSUserServiceModel>().OrderBy(x => x.Name).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(actualEntry.Id == expectedEntry.Id, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(actualEntry.Name == expectedEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(actualEntry.FirstName == expectedEntry.FirstName, errorMessagePrefix + " " + "FirstName is not returned properly.");
                Assert.True(actualEntry.LastName == expectedEntry.LastName, errorMessagePrefix + " " + "LastName is not returned properly.");
                Assert.True(actualEntry.Email == expectedEntry.Email, errorMessagePrefix + " " + "Email is not returned properly.");
                Assert.True(actualEntry.AdditionalOnHourPayment == expectedEntry.AdditionalOnHourPayment, errorMessagePrefix + " " + "AdditionalOnHourPayment is not returned properly.");
                Assert.True(actualEntry.BaseSalary == expectedEntry.BaseSalary, errorMessagePrefix + " " + "BaseSalary is not returned properly.");
                Assert.True(actualEntry.IsDeleted == expectedEntry.IsDeleted, errorMessagePrefix + " " + "IsDeleted is not returned properly.");
                Assert.True(actualEntry.IsRepairing == expectedEntry.IsRepairing, errorMessagePrefix + " " + "IsRepairing is not returned properly.");
                Assert.True(actualEntry.IsAuthorized == expectedEntry.IsAuthorized, errorMessagePrefix + " " + "IsAuthorized is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllUsers_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "UserService GetAllUsers() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _userService = new UserService(new FakeUserManager(), context);

            List<MDMSUserServiceModel> actualResults = await _userService.GetAllUsers().ToListAsync();
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task DeleteUser_WithCorrectData_ShouldDeleteUser()
        {
            string errorMessagePrefix = "UserService DeleteUser() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            bool actualResult = await _userService.DeleteUser("U1");
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task DeleteUser_WithNonExistedId_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _userService.DeleteUser("idzzzzzz"));
        }

        [Fact]
        public async Task RestoreUser_WithCorrectData_ShouldRestoreUser()
        {
            string errorMessagePrefix = "UserService RestoreUser() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            bool actualResult = await _userService.RestoreUser("U4");
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task RestoreUser_WithNonExistedId_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _userService.RestoreUser("idzzzzzz"));
        }

        [Fact]
        public async Task ActivateUser_WithNonExistedId_ShouldThrowExceptionActivateUser()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _userService.ActivateUser("idzzzzzz"));
        }

        [Fact]
        public async Task DeActivateUser_WithNonExistedId_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _userService.DeActivateUser("idzzzzzz"));
        }

        [Fact]
        public async Task AddSalary_WithCorrectData_ShouldSuccessfullyAddSalary()
        {
            string errorMessagePrefix = "UserService AddSalary() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            bool actualResult = await _userService.AddSalary(new MonthlySalaryServiceModel()
            {
                Name = "S2",
                Month = 2,
                Year = 2019,
                HoursWorked = 5,
            });
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task AddSalary_WithDublicateName_ShouldFailToAddSalary()
        {
            string errorMessagePrefix = "UserService AddSalary() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedDataSalary(context);
            _userService = new UserService(new FakeUserManager(), context);

            bool actualResult = await _userService.AddSalary(new MonthlySalaryServiceModel()
            {
                Name = "S1",
                Month = 2,
                Year = 2019,
                HoursWorked = 5,
                MechanicId = "U1"
            });
            Assert.False(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task EditPayment_WithCorrectData_ShouldSuccessfullyEditPayment()
        {
            string errorMessagePrefix = "UserService EditPayment() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);
            MDMSUserServiceModel user = await _userService.GetCurrentUserByUsername("Pesho");
            user.AdditionalOnHourPayment = 60;
            user.BaseSalary = 4000;

            bool actualResult = await _userService.EditPayment(user);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task EditPayment_WithWrongId_ShouldFailToAddSalary()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _userService = new UserService(new FakeUserManager(), context);

            MDMSUserServiceModel user = await _userService.GetCurrentUserByUsername("Pesho");
            user.Id = "NoId";
            user.AdditionalOnHourPayment = 60;
            user.BaseSalary = 4000;

            await Assert.ThrowsAsync<NullReferenceException>(() => _userService.EditPayment(user));
        }
    }


}
