using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Models;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MDMS.Tests.ServiceTests
{
    public class VehicleServiceTests
    {
        private IVehicleService _vehicleService;

        private List<Vehicle> GetVehicleDummyData()
        {
            return new List<Vehicle>()
            {
                new Vehicle
                {
                    Id = "V1",
                    Name = "Mercedes_Actros_12345678901234567",
                    Price = 1000000.2M,
                    Depreciation = 10000.1m,
                    Picture = "/Here/here/jpeg.png",
                    Make = "Mercedes",
                    Model = "Actros",
                    VSN = "12345678901234567",
                    Mileage = 1500,
                    RegistrationNumber = "CA5151AB",
                    IsInRepair = false,
                    AcquiredOn = DateTime.ParseExact("1/12/2019 11:23", "M/d/yyyy hh:mm", CultureInfo.InvariantCulture),
                    ManufacturedOn = DateTime.ParseExact("10/24/2019 11:23", "M/d/yyyy hh:mm", CultureInfo.InvariantCulture),
                    IsActive = true,
                    VehicleProvider = new VehicleProvider()
                    {
                        Name = "Mercedes"
                    },
                    InternalRepairs = new List<InternalRepair>

                    {
                        new InternalRepair
                        {
                            Id = "ir1",
                            Name = "Internal_Breaking_Mercedes_Acteos_12345678901234564_2019/08/27_15:57",
                            Description = "Bolt Change",
                            VehicleId = "v1",
                            Mileage = 1000,
                            RepairedSystemId = "rs1",
                            StartedOn = DateTime.Now.AddDays(-7),
                            FinishedOn = DateTime.Now.AddDays(-1),
                            MdmsUserId = "u1",
                            RepairCost = 122.2m,
                            HoursWorked = 1
                        }

                    },VehicleType = new VehicleType
                    {
                        Name = "Truck"
                    },
                    IsDeleted = false

                },
                new Vehicle
                {
                    Id = "V2",
                    Name = "Mercedes_S500_12345678901234568",
                    Price = 2000000.2M,
                    Depreciation = 20000.1m,
                    Picture = "/Here/here/jpeg2.png",
                    Make = "Mercedes",
                    Model = "S500",
                    VSN = "12345678901234568",
                    Mileage = 150000,
                    RegistrationNumber = "CA5152AB",
                    IsInRepair = false,
                    AcquiredOn = DateTime.ParseExact("11/21/2019 11:23", "M/d/yyyy hh:mm", CultureInfo.InvariantCulture),
                    ManufacturedOn = DateTime.ParseExact("10/21/2019 11:23", "M/d/yyyy hh:mm", CultureInfo.InvariantCulture),
                    IsActive = true,
                    VehicleProvider = new VehicleProvider()
                    {
                        Name = "AMG"
                    },
                    ExternalRepairs = new List<ExternalRepair>
                    {
                        new ExternalRepair
                        {
                            Id = "ir1",
                            Name = "External_Breaking_Mercedes_S500_12345678901234568_2019/08/27_15:57",
                            Description = "Bolt Change",
                            VehicleId = "v1",
                            Mileage = 1000,
                            RepairedSystemId = "rs1",
                            StartedOn = DateTime.Now.AddDays(-5),
                            FinishedOn = DateTime.Now.AddDays(-1),
                            MdmsUserId = "u1",
                            RepairCost = 3220.2m,
                            LaborCost = 1000m,
                            PartsCost = 2220.2m
                        }     
                     }   
                    ,VehicleType = new VehicleType
                    {
                        Name = "Car"
                    },
                    IsDeleted = false
                }
            };

        }


        private async Task SeedData(MdmsDbContext context)
        {
            context.AddRange(GetVehicleDummyData());
            await context.SaveChangesAsync();
        }

        public VehicleServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetAllVehicles_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "PartService GetAllVehicles() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _vehicleService = new VehicleService(context);

            List<VehicleServiceModel> actualResults = await _vehicleService.GetAllVehicles().ToListAsync();
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllVehicles_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllVehicles() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            List<VehicleServiceModel> actualResults = await _vehicleService.GetAllVehicles().ToListAsync();
            List<VehicleServiceModel> expectedResults = GetVehicleDummyData().To<VehicleServiceModel>().OrderBy(x => x.Name).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Id == actualEntry.Id, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.Depreciation == actualEntry.Depreciation, errorMessagePrefix + " " + "Depreciation is not returned properly.");
                Assert.True(expectedEntry.Model == actualEntry.Model, errorMessagePrefix + " " + "Model is not returned properly.");
                Assert.True(expectedEntry.Make == actualEntry.Make, errorMessagePrefix + " " + "Make is not returned properly.");
                Assert.True(expectedEntry.VSN == actualEntry.VSN, errorMessagePrefix + " " + "VSN is not returned properly.");
                Assert.True(expectedEntry.Mileage == actualEntry.Mileage, errorMessagePrefix + " " + "Mileage is not returned properly.");
                Assert.True(expectedEntry.RegistrationNumber == actualEntry.RegistrationNumber, errorMessagePrefix + " " + "RegistrationNumber is not returned properly.");
                Assert.True(expectedEntry.IsInRepair == actualEntry.IsInRepair, errorMessagePrefix + " " + "IsInRepair is not returned properly.");
                Assert.True(expectedEntry.AcquiredOn == actualEntry.AcquiredOn, errorMessagePrefix + " " + "AcquiredOn is not returned properly.");
                Assert.True(expectedEntry.ManufacturedOn == actualEntry.ManufacturedOn, errorMessagePrefix + " " + "ManufacturedOn is not returned properly.");
                Assert.True(expectedEntry.IsActive == actualEntry.IsActive, errorMessagePrefix + " " + "IsActive is not returned properly.");
                Assert.True(expectedEntry.IsDeleted == actualEntry.IsDeleted, errorMessagePrefix + " " + "IsDeleted is not returned properly.");
                Assert.True(expectedEntry.VehicleProvider.Name == actualEntry.VehicleProvider.Name, errorMessagePrefix + " " + "VehicleProviderName is not returned properly.");
                Assert.True(expectedEntry.VehicleType.Name == actualEntry.VehicleType.Name, errorMessagePrefix + " " + "VehicleTypeName is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllVehicleTypes_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "PartService GetAllVehicleTypes() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _vehicleService = new VehicleService(context);

            List<VehicleTypeServiceModel> actualResults = await _vehicleService.GetAllVehicleTypes().ToListAsync();
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllVehicleTypes_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllVehicleTypes() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            List<VehicleTypeServiceModel> actualResults = await _vehicleService.GetAllVehicleTypes().ToListAsync();
            List<VehicleTypeServiceModel> expectedResults = GetVehicleDummyData().Select(x => x.VehicleType).To<VehicleTypeServiceModel>().OrderBy(x => x.Name).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllVehicleProviders_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "PartService GetAllVehicleProviders() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _vehicleService = new VehicleService(context);

            List<VehicleProviderServiceModel> actualResults = await _vehicleService.GetAllVehicleProviders().ToListAsync();
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllVehicleProviders_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllVehicleProviders() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            List<VehicleProviderServiceModel> actualResults = await _vehicleService.GetAllVehicleProviders().ToListAsync();
            List<VehicleProviderServiceModel> expectedResults = GetVehicleDummyData().Select(x => x.VehicleProvider).To<VehicleProviderServiceModel>().OrderBy(x => x.Name).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
            }
        }

        [Fact]
        public async Task GetVehicleByName_WithNonExistentName_ShouldReturnNull()
        {
            string errorMessagePrefix = "PartService GetVehicleByName() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            Assert.True(_vehicleService.GetVehicleByName("Name").Result == null, errorMessagePrefix);
        }


        [Fact]
        public async Task GetVehicleByName_WithExistentName_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetVehicleByName() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            VehicleServiceModel expectedData = context.Vehicles.SingleOrDefault(x => x.Name == "Mercedes_Actros_12345678901234567").To<VehicleServiceModel>();
            VehicleServiceModel actualData =  _vehicleService.GetVehicleByName("Mercedes_Actros_12345678901234567").Result;

            Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(expectedData.Name == actualData.Name, errorMessagePrefix + " " + "Name is not returned properly.");
            Assert.True(expectedData.Price == actualData.Price, errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.Picture == actualData.Picture, errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.Depreciation == actualData.Depreciation, errorMessagePrefix + " " + "Depreciation is not returned properly.");
            Assert.True(expectedData.Model == actualData.Model, errorMessagePrefix + " " + "Model is not returned properly.");
            Assert.True(expectedData.Make == actualData.Make, errorMessagePrefix + " " + "Make is not returned properly.");
            Assert.True(expectedData.VSN == actualData.VSN, errorMessagePrefix + " " + "VSN is not returned properly.");
            Assert.True(expectedData.Mileage == actualData.Mileage, errorMessagePrefix + " " + "Mileage is not returned properly.");
            Assert.True(expectedData.RegistrationNumber == actualData.RegistrationNumber, errorMessagePrefix + " " + "RegistrationNumber is not returned properly.");
            Assert.True(expectedData.IsInRepair == actualData.IsInRepair, errorMessagePrefix + " " + "IsInRepair is not returned properly.");
            Assert.True(expectedData.AcquiredOn == actualData.AcquiredOn, errorMessagePrefix + " " + "AcquiredOn is not returned properly.");
            Assert.True(expectedData.ManufacturedOn == actualData.ManufacturedOn, errorMessagePrefix + " " + "ManufacturedOn is not returned properly.");
            Assert.True(expectedData.IsActive == actualData.IsActive, errorMessagePrefix + " " + "IsActive is not returned properly.");
            Assert.True(expectedData.IsDeleted == actualData.IsDeleted, errorMessagePrefix + " " + "IsDeleted is not returned properly.");
            Assert.True(expectedData.VehicleProvider.Name == actualData.VehicleProvider.Name, errorMessagePrefix + " " + "VehicleProviderName is not returned properly.");
            Assert.True(expectedData.VehicleType.Name == actualData.VehicleType.Name, errorMessagePrefix + " " + "VehicleTypeName is not returned properly.");
        }

        [Fact]
        public async Task CreateVehicleProvider_WithCorrectData_ShouldSuccessfullyVehicleProvider()
        {
            string errorMessagePrefix = "PartService CreateVehicleProvider() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            bool actualResult = await _vehicleService.CreateVehicleProvider(new VehicleProviderServiceModel()
            {
                Name = "BMW"
            });
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreatePartProvider_WithDublicateName_ShouldFailToVehicleProvider()
        {
            string errorMessagePrefix = "PartService CreateVehicleProvider() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            bool actualResult = await _vehicleService.CreateVehicleProvider(new VehicleProviderServiceModel()
            {
                Name = "Mercedes"
            });
            Assert.False(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateVehicleType_WithCorrectData_ShouldSuccessfullyCreateVehicleType()
        {
            string errorMessagePrefix = "PartService CreateVehicleType() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            bool actualResult = await _vehicleService.CreateVehicleType(new VehicleTypeServiceModel()
            {
                Name = "Van"
            });
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateVehicleType_WithDublicateName_ShouldFailToCreateVehicleType()
        {
            string errorMessagePrefix = "PartService CreateVehicleType() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            bool actualResult = await _vehicleService.CreateVehicleType(new VehicleTypeServiceModel()
            {
                Name = "Truck"
            });
            Assert.False(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateVehicle_WithCorrectData_ShouldSuccessfullyCreateVehicle()
        {
            string errorMessagePrefix = "VehicleService Create() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            VehicleServiceModel vehicle = new VehicleServiceModel()
            {
                Id = "V3",
                Name = "BMW_M5_12345678901234512",
                Price = 2000000.2M,
                Depreciation = 20000.1m,
                Picture = "/Here/here/jpeg2.png",
                Make = "BMW",
                Model = "S500",
                VSN = "12345678901234512",
                Mileage = 150000,
                RegistrationNumber = "CA5152AB",
                IsInRepair = false,
                AcquiredOn = DateTime.ParseExact("11/21/2018 11:23", "M/d/yyyy hh:mm", CultureInfo.InvariantCulture),
                ManufacturedOn = DateTime.ParseExact("1/21/2019 11:23", "M/d/yyyy hh:mm", CultureInfo.InvariantCulture),
                IsActive = true,
                VehicleProvider = new VehicleProviderServiceModel()
                {
                    Name = "Mercedes"
                },
                VehicleType = new VehicleTypeServiceModel()
                {
                    Name = "Car"
                },
                IsDeleted = false
            };

            bool actualResult = await _vehicleService.Create(vehicle);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateVehicle_NotExistentPartProvider_ShouldNotCreatePart()
        {
            string errorMessagePrefix = "VehicleService Create() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            var vehicle = new VehicleServiceModel()
            {
                Id = "V3",
                Name = "BMW_M5_12345678901234512",
                Price = 2000000.2M,
                Depreciation = 20000.1m,
                Picture = "/Here/here/jpeg2.png",
                Make = "BMW",
                Model = "S500",
                VSN = "12345678901234568",
                Mileage = 150000,
                RegistrationNumber = "CA5152AB",
                IsInRepair = false,
                AcquiredOn = DateTime.ParseExact("11/21/2018 11:23", "M/d/yyyy hh:mm", CultureInfo.InvariantCulture),
                ManufacturedOn = DateTime.ParseExact("1/21/2019 11:23", "M/d/yyyy hh:mm", CultureInfo.InvariantCulture),
                IsActive = true,
                VehicleProvider = new VehicleProviderServiceModel()
                {
                    Name = "Mercedes"
                },

                VehicleType = new VehicleTypeServiceModel()
                {
                    Name = "Car"
                },
                IsDeleted = false
            };

            bool actualResult = await _vehicleService.Create(vehicle);
            Assert.False(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task DeleteVehicle_WithCorrectData_ShouldDeletePart()
        {
            string errorMessagePrefix = "VehicleService DeleteVehicle() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            bool actualResult = await _vehicleService.DeleteVehicle("V1");
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task DeleteVehicle_WithNonExistedVehicleId_ShouldThrowExceptionDeletePart()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _vehicleService.DeleteVehicle("idzzzzzz"));
        }

        [Fact]
        public async Task EditVehicle_WithNonExistedVehicle_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _vehicleService = new VehicleService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _vehicleService.Edit(new VehicleServiceModel()));
        }

    }

}

