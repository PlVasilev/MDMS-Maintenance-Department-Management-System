using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MDMS.Data;
using Mdms.Data.Models;
using MDMS.Data.Models;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MDMS.Tests.ServiceTests
{
    public class RepairServiceTests
    {
        private IRepairService _repairService;

        private List<InternalRepair> GetInternalRepairDummyData()
        {
            return new List<InternalRepair>()
            {

                new InternalRepair
                {
                    Id = "ir1",
                    Name = "Internal_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57",
                    Description = "Bolt Change",
                    Vehicle = new Vehicle()
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
                        AcquiredOn = DateTime.ParseExact("1/12/2019 11:23", "M/d/yyyy hh:mm",
                            CultureInfo.InvariantCulture),
                        ManufacturedOn = DateTime.ParseExact("10/24/2019 11:23", "M/d/yyyy hh:mm",
                            CultureInfo.InvariantCulture),
                        IsActive = true,
                        VehicleProvider = new VehicleProvider()
                        {
                            Name = "Mercedes"
                        },

                    },
                    Mileage = 1000,
                    RepairedSystemId = "rs1",
                    StartedOn = DateTime.UtcNow.AddDays(-1),
                    FinishedOn = DateTime.UtcNow.AddDays(-11),
                    MdmsUser = new MdmsUser()
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
                        {
                            new MonthlySalary()
                            {
                                Name = "S1_2019_2",
                                Month = 1,
                                Year = 2019,
                                HoursWorked = 10,
                                BaseSalary = 3000,
                                MechanicId = "U1",
                                TotalSalary = 3500m
                            }
                        }
                    },
                    InternalRepairParts = new List<InternalRepairPart>
                    {
                        new InternalRepairPart
                        {
                            Part = new Part
                            {
                                Id = "P1",
                                Name = "Blot 10.5x2",
                                Price = 10.2M,
                                UsedCount = 10,
                                Stock = 90,
                                AcquiredFrom = new PartsProvider()
                                {
                                    Name = "Metal Strong"
                                }
                            },
                            InternalRepairId = "ir1",
                            Quantity = 10
                        }
                    },
                    RepairCost = 152m,
                    HoursWorked = 1,
                    RepairedSystem = new RepairedSystem
                    {
                        Name = "BodyWork"
                    }

                },
                new InternalRepair
                {
                    Id = "ir2",
                    Name = "Internal_Breaking_Mercedes_Actros_12345678901234564_2019/08/23_15:57",
                    Description = "Bolt Change2",
                    Vehicle = new Vehicle()
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
                        IsInRepair = true,
                        AcquiredOn = DateTime.ParseExact("1/12/2019 11:23", "M/d/yyyy hh:mm",
                            CultureInfo.InvariantCulture),
                        ManufacturedOn = DateTime.ParseExact("10/24/2019 11:23", "M/d/yyyy hh:mm",
                            CultureInfo.InvariantCulture),
                        IsActive = true,
                        VehicleProvider = new VehicleProvider()
                        {
                            Name = "Mercedes"
                        },

                    },
                    Mileage = 1000,
                    RepairedSystemId = "rs1",
                    StartedOn = DateTime.UtcNow.AddDays(-4),
                    FinishedOn = null,
                    MdmsUser = new MdmsUser()
                    {
                        Id = "U1",
                        UserName = "Pesho",
                        FirstName = "Pesho",
                        LastName = "Peshov",
                        AdditionalOnHourPayment = 50m,
                        BaseSalary = 3000m,
                        Email = "Pesho@peshov.com,",
                        IsRepairing = true,
                        IsDeleted = false,
                        IsAuthorized = true,
                        Salaries = new List<MonthlySalary>
                        {
                            new MonthlySalary()
                            {
                                Name = "S1_2019_2",
                                Month = 1,
                                Year = 2019,
                                HoursWorked = 10,
                                BaseSalary = 3000,
                                MechanicId = "U1",
                                TotalSalary = 3500m
                            }
                        }
                    },
                    RepairCost = 0m,
                    HoursWorked = 0,
                    InternalRepairParts = new List<InternalRepairPart>
                    {
                        new InternalRepairPart
                        {
                            Part = new Part
                            {
                                Id = "P11",
                                Name = "Blot 10.5x2",
                                Price = 10.2M,
                                UsedCount = 10,
                                Stock = 90,
                                AcquiredFrom = new PartsProvider()
                                {
                                    Name = "Metal Strong"
                                }
                            },
                            InternalRepairId = "ir1",
                            Quantity = 10
                        }
                    },
                    RepairedSystem = new RepairedSystem
                    {
                        Name = "Electrical"
                    }
                }

            };

        }

        private List<ExternalRepair> GetIExternalRepairDummyData()
        {
            return new List<ExternalRepair>()
            {

                new ExternalRepair
                {
                    Id = "ir1",
                    Name = "External_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57",
                    Description = "Bolt Change",
                    Vehicle = new Vehicle()
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
                        AcquiredOn = DateTime.ParseExact("1/12/2019 11:23", "M/d/yyyy hh:mm",
                            CultureInfo.InvariantCulture),
                        ManufacturedOn = DateTime.ParseExact("10/24/2019 11:23", "M/d/yyyy hh:mm",
                            CultureInfo.InvariantCulture),
                        IsActive = true,
                        VehicleProvider = new VehicleProvider()
                        {
                            Name = "Mercedes"
                        },
                    },
                    Mileage = 1000,
                    RepairedSystemId = "rs1",
                    StartedOn = DateTime.Now.AddDays(-2),
                    FinishedOn = DateTime.Now.AddDays(-7),
                    MdmsUser = new MdmsUser()
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
                        {
                            new MonthlySalary()
                            {
                                Name = "S1_2019_2",
                                Month = 1,
                                Year = 2019,
                                HoursWorked = 10,
                                BaseSalary = 3000,
                                MechanicId = "U1",
                                TotalSalary = 3500m
                            }
                        }
                    },
                    PartsCost = 500,
                    LaborCost = 200,
                    RepairCost = 700,
                    ExternalRepairProvider = new ExternalRepairProvider()
                    {
                        Name = "BTS"
                    },
                    RepairedSystem = new RepairedSystem
                    {
                        Name = "BodyWork"
                    }

                },
                new ExternalRepair
                {
                    Id = "ir2",
                    Name = "Internal_Breaking_Mercedes_Actros_12345678901234564_2019/08/25_15:57",
                    Description = "Bolt Change2",
                    VehicleId = "V1",
                    Mileage = 1000,
                    RepairedSystemId = "rs1",
                    StartedOn = DateTime.Now.AddDays(-1),
                    FinishedOn = null,
                    MdmsUserId = "U1",
                    RepairCost = 0m,
                    LaborCost = 0,
                    PartsCost = 0,
                    ExternalRepairProvider = new ExternalRepairProvider()
                    {
                        Name = "SilverStar"
                    },
                    MdmsUser = new MdmsUser()
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
                    {
                        new MonthlySalary()
                        {
                            Name = "S1_2019_2",
                            Month = 1,
                            Year = 2019,
                            HoursWorked = 10,
                            BaseSalary = 3000,
                            MechanicId = "U1",
                            TotalSalary = 3500m
                        }
                    }
                },
                }

            };

        }

        private List<ExternalRepairProvider> GetExternalRepairProviderDummyData()
        {
            return new List<ExternalRepairProvider>()
            {
                new ExternalRepairProvider()
                {
                    Name = "BTS"
                }
            };
        }

        private async Task SeedInternalRepair(MdmsDbContext context)
        {
            context.AddRange(GetInternalRepairDummyData());
            await context.SaveChangesAsync();
        }

        private async Task SeedExternalRepair(MdmsDbContext context)
        {
            context.AddRange(GetIExternalRepairDummyData());
            await context.SaveChangesAsync();
        }

        private async Task SeedExternalRepairProvider(MdmsDbContext context)
        {
            context.AddRange(GetExternalRepairProviderDummyData());
            await context.SaveChangesAsync();
        }

        public RepairServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task CreateExternalRepairProvider_WithCorrectData_ShouldSuccessfullyCreateExternalRepairProvider()
        {
            string errorMessagePrefix = "RepairService SeedExternalRepair() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            bool actualResult = await _repairService.CreateExternalRepairProvider(
                new ExternalRepairProviderServiceModel()
                {
                    Name = "BTS2"
                });
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateExternalRepairProvider_WithDublicateName_ShouldFailToCreateExternalRepairProvider()
        {
            string errorMessagePrefix = "RepairService CreateExternalRepairProvider() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepairProvider(context);
            _repairService = new RepairService(context);

            bool actualResult = await _repairService.CreateExternalRepairProvider(
                new ExternalRepairProviderServiceModel()
                {
                    Name = "BTS"
                });
            Assert.False(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateInternal_WithCorrectData_ShouldSuccessfullyCreateInternalRepair()
        {
            string errorMessagePrefix = "RepairService CreateInternal() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            InternalRepairServiceModel repair = new InternalRepairServiceModel()
            {
                Id = "ir4",
                Name = "",
                Description = "Bolt Change2",
                VehicleId = "V1",
                Mileage = 1000,
                RepairedSystemId = "rs1",
                StartedOn = DateTime.UtcNow,
                FinishedOn = null,
                RepairCost = 0m,
                HoursWorked = 0,
                RepairedSystem = new RepairedSystemServiceModel()
                {
                    Name = "Engine"
                },
                MdmsUserId = "U1",
            };

            bool actualResult = await _repairService.CreateInternal(repair);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateInternal_NotExistentVehicle_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            InternalRepairServiceModel repair = new InternalRepairServiceModel()
            {
                Id = "ir2",
                Name = "Internal_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57",
                Description = "Bolt Change2",
                VehicleId = "v1",
                Mileage = 1000,
                RepairedSystemId = "rs1",
                StartedOn = DateTime.UtcNow,
                FinishedOn = null,
                MdmsUserId = "u1",
                RepairCost = 0m,
                HoursWorked = 0,
                RepairedSystem = new RepairedSystemServiceModel()
                {
                    Name = "Engine"
                }
            };

            await Assert.ThrowsAsync<NullReferenceException>(() => _repairService.CreateInternal(repair));

        }

        [Fact]
        public async Task CreateExternal_WithCorrectData_ShouldSuccessfullyCreateInternalRepair()
        {
            string errorMessagePrefix = "RepairService CreateExternal() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            ExternalRepairServiceModel repair = new ExternalRepairServiceModel()
            {
                Id = "ir4",
                Name = "",
                Description = "Bolt Change2",
                VehicleId = "V1",
                Mileage = 1000,
                RepairedSystemId = "rs1",
                StartedOn = DateTime.UtcNow,
                FinishedOn = null,
                RepairCost = 0m,
                RepairedSystem = new RepairedSystemServiceModel()
                {
                    Name = "Engine"
                },
                ExternalRepairProvider = new ExternalRepairProviderServiceModel()
                {
                    Name = "BTS"
                },
                MdmsUserId = "U1",
            };

            bool actualResult = await _repairService.CreateExternal(repair);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateExternal_NotExistentVehicle_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            ExternalRepairServiceModel repair = new ExternalRepairServiceModel()
            {
                Id = "ir2",
                Name = "",
                Description = "Bolt Change2",
                VehicleId = "v1",
                Mileage = 1000,
                RepairedSystemId = "rs1",
                StartedOn = DateTime.UtcNow,
                FinishedOn = null,
                MdmsUserId = "u1",
                RepairCost = 0m,
                RepairedSystem = new RepairedSystemServiceModel()
                {
                    Name = "Engine"
                }
            };
            await Assert.ThrowsAsync<NullReferenceException>(() => _repairService.CreateExternal(repair));
        }

        [Fact]
        public async Task
            EditExternalRepairDescription_WithCorrectData_ShouldSuccessfullyEditExternalRepairDescription()
        {
            string errorMessagePrefix = "RepairService EditExternalRepairDescription() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            bool actualResult = await _repairService.EditExternalRepairDescription("ir2", "Edited");
            Assert.True(actualResult, errorMessagePrefix);
        }


        [Fact]
        public async Task
            EditInternalRepairDescription_WithCorrectData_ShouldSuccessfullyEditInternalRepairDescription()
        {
            string errorMessagePrefix = "RepairService EditExternalRepairDescription() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            bool actualResult = await _repairService.EditInternalRepairDescription("ir2", "Edited");
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task EditExternalRepairDescription_WithWrongId_ThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                _repairService.EditExternalRepairDescription("ir20", "Edited"));
        }

        [Fact]
        public async Task EditInternalRepairDescription_WithWrongId_ThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                _repairService.EditExternalRepairDescription("ir20", "Edited"));
        }

        [Fact]
        public async Task FinalizeExternal_WithCorrectData_ShouldSuccessfullyFinalizeExternal()
        {
            string errorMessagePrefix = "RepairService FinalizeExternal() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            ExternalRepairServiceModel externalRepairServiceModel = new ExternalRepairServiceModel
            {
                Id = "ir2",
                Name = "Internal_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57",
                Description = "Bolt Change2",
                VehicleId = "V1",
                Mileage = 1000,
                RepairedSystemId = "rs1",
                StartedOn = DateTime.Now.AddDays(-1),
                FinishedOn = DateTime.Now,
                MdmsUserId = "U1",
                RepairCost = 0m,
                LaborCost = 220,
                PartsCost = 110,
                ExternalRepairProvider = new ExternalRepairProviderServiceModel()
                {
                    Name = "SilverStar"
                }
            };

            bool actualResult = await _repairService.FinalizeExternal(externalRepairServiceModel);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task FinalizeExternal_WithRepairIdWithNotNullAsFinishedOn_ShouldFailToFinalizeExternal()
        {
            string errorMessagePrefix = "RepairService FinalizeExternal() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            ExternalRepairServiceModel externalRepairServiceModel = new ExternalRepairServiceModel
            {
                Id = "ir1",
            };

            bool actualResult = await _repairService.FinalizeExternal(externalRepairServiceModel);
            Assert.False(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task FinalizeInternal_WithCorrectData_ShouldSuccessfullyFinalizeInternal()
        {
            string errorMessagePrefix = "RepairService FinalizeInternal() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            bool actualResult = await _repairService.FinalizeInternal("ir1", 6);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task FinalizeInternal_WithWrongId_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                _repairService.FinalizeInternal("ir20", 8));
        }

        [Fact]
        public async Task GetInternalRepairIdByName_WithCorrectData_ShouldSuccessfullyGetInternalRepairIdByName()
        {
            string errorMessagePrefix = "RepairService GetInternalRepairIdByName() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            string actualResult =
                await _repairService.GetInternalRepairIdByName(
                    "Internal_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57");
            string expectedResult = context.InternalRepairs.SingleOrDefault(x =>
                x.Name == "Internal_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57")?.Id;
            Assert.True(actualResult == expectedResult, errorMessagePrefix);
        }

        [Fact]
        public async Task GetInternalRepairIdByName_WithWrongName_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                _repairService.GetInternalRepairIdByName("Wrong Repair"));
        }

        [Fact]
        public async Task GetInternalRepairByName_WithExistentName_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetInternalRepairByName() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            InternalRepairServiceModel expectedData = context.InternalRepairs
                .SingleOrDefault(x => x.Name == "Internal_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57")
                .To<InternalRepairServiceModel>();
            InternalRepairServiceModel actualData = _repairService
                .GetInternalRepairByName("Internal_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57").Result;

            Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(expectedData.Name == actualData.Name,
                errorMessagePrefix + " " + "Name is not returned properly.");
            Assert.True(expectedData.Description == actualData.Description,
                errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.Mileage == actualData.Mileage,
                errorMessagePrefix + " " + "Mileage is not returned properly.");
            Assert.True(expectedData.RepairedSystemId == actualData.RepairedSystemId,
                errorMessagePrefix + "RepairedSystemId" + "Price is not returned properly.");
            Assert.True(expectedData.StartedOn == actualData.StartedOn,
                errorMessagePrefix + " " + "StartedOn is not returned properly.");
            Assert.True(expectedData.FinishedOn == actualData.FinishedOn,
                errorMessagePrefix + " " + "FinishedOn is not returned properly.");
            Assert.True(expectedData.Vehicle.Id == actualData.Vehicle.Id,
                errorMessagePrefix + " " + "Vehicle.Id is not returned properly.");
            Assert.True(expectedData.MdmsUser.Id == actualData.MdmsUser.Id,
                errorMessagePrefix + " " + "MdmsUser.Id is not returned properly.");
            Assert.True(expectedData.RepairedSystem.Name == actualData.RepairedSystem.Name,
                errorMessagePrefix + " " + "RepairedSystem.Name is not returned properly.");
            Assert.True(expectedData.InternalRepairParts.Sum(x => x.Quantity) ==
                actualData.InternalRepairParts.Sum(x => x.Quantity),
                errorMessagePrefix + " " + "InternalRepairParts.Sum is not returned properly.");
        }

        [Fact]
        public async Task GetInternalRepairByName_WithWrongName_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _repairService.GetInternalRepairByName("Wrong Repair"));
        }

        [Fact]
        public async Task GetExternalRepairByName_WithExistentName_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetExternalRepairByName() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            ExternalRepairServiceModel expectedData = context.ExternalRepairs.SingleOrDefault(x =>
                    x.Name == "External_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57")
                .To<ExternalRepairServiceModel>();
            ExternalRepairServiceModel actualData = _repairService
                .GetExternalRepairByName("External_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57").Result;

            Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(expectedData.Name == actualData.Name,
                errorMessagePrefix + " " + "Name is not returned properly.");
            Assert.True(expectedData.Description == actualData.Description,
                errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.Mileage == actualData.Mileage,
                errorMessagePrefix + " " + "Mileage is not returned properly.");
            Assert.True(expectedData.RepairedSystemId == actualData.RepairedSystemId,
                errorMessagePrefix + "RepairedSystemId" + "Price is not returned properly.");
            Assert.True(expectedData.StartedOn == actualData.StartedOn,
                errorMessagePrefix + " " + "StartedOn is not returned properly.");
            Assert.True(expectedData.FinishedOn == actualData.FinishedOn,
                errorMessagePrefix + " " + "FinishedOn is not returned properly.");
            Assert.True(expectedData.Vehicle.Id == actualData.Vehicle.Id,
                errorMessagePrefix + " " + "Vehicle.Id is not returned properly.");
            Assert.True(expectedData.MdmsUser.Id == actualData.MdmsUser.Id,
                errorMessagePrefix + " " + "MdmsUser.Id is not returned properly.");
            Assert.True(expectedData.RepairedSystem.Name == actualData.RepairedSystem.Name,
                errorMessagePrefix + " " + "RepairedSystem.Name is not returned properly.");
            Assert.True(expectedData.ExternalRepairProvider.Name == actualData.ExternalRepairProvider.Name,
                errorMessagePrefix + " " + "ExternalRepairProvider.Name is not returned properly.");
        }

        [Fact]
        public async Task GetExternalRepairByName_WithWrongName_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _repairService.GetExternalRepairByName("Wrong Repair"));
        }

        [Fact]
        public async Task AddPartsToInternalRepair_WithCorrectData_ShouldSuccessfullyGetInternalRepairIdByName()
        {
            string errorMessagePrefix = "RepairService AddPartsToInternalRepair() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            List<InternalRepairPartServiceModel> internalRepairPartServiceModel =
                new List<InternalRepairPartServiceModel>()
                {
                    new InternalRepairPartServiceModel()
                    {
                        Part = new PartServiceModel()
                        {
                            Id = "P1",
                            Name = "Blot 10.5x2",
                            Price = 10.2M,
                            UsedCount = 10,
                            Stock = 90,
                            AcquiredFrom = new PartsProviderServiceModel()
                            {
                                Name = "Metal Strong"
                            }
                        },
                        InternalRepairId = "ir1",
                        Quantity = 10
                    }
                };

            bool actualResult = await _repairService.AddPartsToInternalRepair(internalRepairPartServiceModel);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task AddPartsToInternalRepair_WithWrongInternalRepairId_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            List<InternalRepairPartServiceModel> internalRepairPartServiceModel =
                new List<InternalRepairPartServiceModel>()
                {
                    new InternalRepairPartServiceModel()
                    {
                        Part = new PartServiceModel()
                        {
                            Id = "P1",
                            Name = "Blot 10.5x2",
                            Price = 10.2M,
                            UsedCount = 10,
                            Stock = 90,
                            AcquiredFrom = new PartsProviderServiceModel()
                            {
                                Name = "Metal Strong"
                            }
                        },
                        InternalRepairId = "ir100",
                        Quantity = 10
                    }
                };

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                _repairService.AddPartsToInternalRepair(internalRepairPartServiceModel));
        }

        [Fact]
        public async Task GetExternalActiveRepair_WithExistentName_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetExternalActiveRepair() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            ExternalRepairServiceModel expectedData = context.ExternalRepairs.SingleOrDefault(x =>
                    x.Name == "External_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57")
                .To<ExternalRepairServiceModel>();
            ExternalRepairServiceModel actualData = _repairService
                .GetExternalActiveRepair("External_Breaking_Mercedes_Actros_12345678901234564_2019/08/27_15:57").Result;

            Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(expectedData.Name == actualData.Name,
                errorMessagePrefix + " " + "Name is not returned properly.");
            Assert.True(expectedData.Description == actualData.Description,
                errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.Mileage == actualData.Mileage,
                errorMessagePrefix + " " + "Mileage is not returned properly.");
            Assert.True(expectedData.RepairedSystemId == actualData.RepairedSystemId,
                errorMessagePrefix + "RepairedSystemId" + "Price is not returned properly.");
            Assert.True(expectedData.StartedOn == actualData.StartedOn,
                errorMessagePrefix + " " + "StartedOn is not returned properly.");
            Assert.True(expectedData.FinishedOn == actualData.FinishedOn,
                errorMessagePrefix + " " + "FinishedOn is not returned properly.");
            Assert.True(expectedData.Vehicle.Id == actualData.Vehicle.Id,
                errorMessagePrefix + " " + "Vehicle.Id is not returned properly.");
            Assert.True(expectedData.MdmsUser.Id == actualData.MdmsUser.Id,
                errorMessagePrefix + " " + "MdmsUser.Id is not returned properly.");
            Assert.True(expectedData.RepairedSystem.Name == actualData.RepairedSystem.Name,
                errorMessagePrefix + " " + "RepairedSystem.Name is not returned properly.");
            Assert.True(expectedData.ExternalRepairProvider.Name == actualData.ExternalRepairProvider.Name,
                errorMessagePrefix + " " + "FinishedOn is not returned properly.");
        }

        [Fact]
        public async Task GetExternalActiveRepair_WithWrongName_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _repairService.GetExternalActiveRepair("Wrong Repair"));
        }

        [Fact]
        public async Task GetActiveRepair_WithExistentId_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetInternalRepairByName() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            InternalRepairServiceModel expectedData = context.InternalRepairs.SingleOrDefault(x => x.Id == "ir2")
                .To<InternalRepairServiceModel>();
            InternalRepairServiceModel actualData = await _repairService.GetActiveRepair("U1");

            Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(expectedData.Name == actualData.Name,
                errorMessagePrefix + " " + "Name is not returned properly.");
            Assert.True(expectedData.Description == actualData.Description,
                errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.Mileage == actualData.Mileage,
                errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.RepairedSystemId == actualData.RepairedSystemId,
                errorMessagePrefix + "RepairedSystemId" + "Price is not returned properly.");
            Assert.True(expectedData.StartedOn == actualData.StartedOn,
                errorMessagePrefix + " " + "StartedOn is not returned properly.");
            Assert.True(expectedData.FinishedOn == actualData.FinishedOn,
                errorMessagePrefix + " " + "FinishedOn is not returned properly.");
            Assert.True(expectedData.Vehicle.Id == actualData.Vehicle.Id,
                errorMessagePrefix + " " + "FinishedOn is not returned properly.");
            Assert.True(expectedData.MdmsUser.Id == actualData.MdmsUser.Id,
                errorMessagePrefix + " " + "FinishedOn is not returned properly.");
            Assert.True(expectedData.RepairedSystem.Name == actualData.RepairedSystem.Name,
                errorMessagePrefix + " " + "FinishedOn is not returned properly.");
            Assert.True(expectedData.InternalRepairParts.Sum(x => x.Quantity) ==
                actualData.InternalRepairParts.Sum(x => x.Quantity),
                errorMessagePrefix + " " + "FinishedOn is not returned properly.");
        }

        [Fact]
        public async Task GetActiveRepair_WithWrongId_ShouldReturnFalse()
        {
            string errorMessagePrefix = "RepairService GetActiveRepair() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            InternalRepairServiceModel actualData = await _repairService.GetActiveRepair("Wrong");

            Assert.False(actualData.Id != null, errorMessagePrefix + " " + "Id is not returned properly.");
        }

        [Fact]
        public async Task GetActiveRepairs_WithExistentId_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetActiveRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            List<ExternalRepairServiceModel> expectedDatas = context.ExternalRepairs.Where(x => x.FinishedOn == null)
                .To<ExternalRepairServiceModel>().ToList();
           List<ExternalRepairServiceModel> actualDatas = _repairService.GetActiveRepairs("U1").ToList();

           for (int i = 0; i < expectedDatas.Count; i++)
           {
               var expectedData = expectedDatas[i];
               var actualData = actualDatas[i];

               Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
               Assert.True(expectedData.Name == actualData.Name,
                   errorMessagePrefix + " " + "Name is not returned properly.");
               Assert.True(expectedData.Description == actualData.Description,
                   errorMessagePrefix + " " + "Price is not returned properly.");
               Assert.True(expectedData.Mileage == actualData.Mileage,
                   errorMessagePrefix + " " + "Mileage is not returned properly.");
               Assert.True(expectedData.RepairedSystemId == actualData.RepairedSystemId,
                   errorMessagePrefix + "RepairedSystemId" + "Price is not returned properly.");
               Assert.True(expectedData.StartedOn == actualData.StartedOn,
                   errorMessagePrefix + " " + "StartedOn is not returned properly.");
               Assert.True(expectedData.FinishedOn == actualData.FinishedOn,
                   errorMessagePrefix + " " + "FinishedOn is not returned properly.");
               Assert.True(expectedData.Vehicle.Id == actualData.Vehicle.Id,
                   errorMessagePrefix + " " + "Vehicle.Id is not returned properly.");
               Assert.True(expectedData.MdmsUser.Id == actualData.MdmsUser.Id,
                   errorMessagePrefix + " " + "MdmsUser.Id is not returned properly.");
               Assert.True(expectedData.RepairedSystem.Name == actualData.RepairedSystem.Name,
                   errorMessagePrefix + " " + "RepairedSystem.Name is not returned properly.");
               Assert.True(expectedData.ExternalRepairProvider.Name == actualData.ExternalRepairProvider.Name,
                   errorMessagePrefix + " " + "ExternalRepairProvider.Name is not returned properly.");
            }
        }

        [Fact]
        public async Task GetActiveRepairs_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "RepairService GetActiveRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _repairService = new RepairService(context);

            List<ExternalRepairServiceModel> actualResults = await Task.Run((() => 
                _repairService.GetActiveRepairs("U1").ToList()));
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllRepairedSystems_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetAllRepairedSystems() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            List<RepairedSystemServiceModel> actualResults = await _repairService.GetAllRepairedSystems().ToListAsync();
            List<RepairedSystemServiceModel> expectedResults = context.RepairedSystems.To<RepairedSystemServiceModel>().OrderBy(x => x.Name).ToList();

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
            string errorMessagePrefix = "VehicleService GetAllVehicleProviders() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _repairService = new RepairService(context);

            List<RepairedSystemServiceModel> actualResults = await _repairService.GetAllRepairedSystems().ToListAsync();
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllExternalRepairProviders_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetAllExternalRepairProviders() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            List<ExternalRepairProviderServiceModel> actualResults = await _repairService.GetAllExternalRepairProviders().ToListAsync();
            List<ExternalRepairProviderServiceModel> expectedResults = context.ExternalRepairProviders.To<ExternalRepairProviderServiceModel>().OrderBy(x => x.Name).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllExternalRepairProviders_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "VehicleService GetAllExternalRepairProviders() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _repairService = new RepairService(context);

            List<ExternalRepairProviderServiceModel> actualResults = await _repairService.GetAllExternalRepairProviders().ToListAsync();
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllExternalActiveRepairs_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetAllExternalActiveRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            List<ExternalRepairServiceModel> actualResults = _repairService.GetAllExternalActiveRepairs().Result.ToList();
            List<ExternalRepairServiceModel> expectedResults = context.ExternalRepairs.To<ExternalRepairServiceModel>()
                .Where(x => x.FinishedOn == null)
                .OrderByDescending(x => x.StartedOn)
                .ToList();

            for (int i = 0; i < actualResults.Count; i++)
            {
                var expectedData = expectedResults[i];
                var actualData = actualResults[i];

                Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(expectedData.Name == actualData.Name,
                    errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedData.Description == actualData.Description,
                    errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedData.Mileage == actualData.Mileage,
                    errorMessagePrefix + " " + "Mileage is not returned properly.");
                Assert.True(expectedData.RepairedSystemId == actualData.RepairedSystemId,
                    errorMessagePrefix + "RepairedSystemId" + "Price is not returned properly.");
                Assert.True(expectedData.StartedOn == actualData.StartedOn,
                    errorMessagePrefix + " " + "StartedOn is not returned properly.");
                Assert.True(expectedData.FinishedOn == actualData.FinishedOn,
                    errorMessagePrefix + " " + "FinishedOn is not returned properly.");
                Assert.True(expectedData.Vehicle.Id == actualData.Vehicle.Id,
                    errorMessagePrefix + " " + "Vehicle.Id is not returned properly.");
                Assert.True(expectedData.MdmsUser.Id == actualData.MdmsUser.Id,
                    errorMessagePrefix + " " + "MdmsUser.Id is not returned properly.");
                Assert.True(expectedData.RepairedSystem.Name == actualData.RepairedSystem.Name,
                    errorMessagePrefix + " " + "RepairedSystem.Name is not returned properly.");
                Assert.True(expectedData.ExternalRepairProvider.Name == actualData.ExternalRepairProvider.Name,
                    errorMessagePrefix + " " + "ExternalRepairProvider.Name is not returned properly.");

            }
        }

        [Fact]
        public async Task GetAllExternalActiveRepairs_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "VehicleService GetAllExternalActiveRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _repairService = new RepairService(context);

            List<ExternalRepairServiceModel> actualResults = await Task.Run((() =>
                _repairService.GetAllExternalActiveRepairs().Result.ToList()));
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllInternalActiveRepairs_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetAllInternalActiveRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            List<InternalRepairServiceModel> actualResults = _repairService.GetAllInternalActiveRepairs().Result.ToList();
            List<InternalRepairServiceModel> expectedResults = context.InternalRepairs.To<InternalRepairServiceModel>()
                .Where(x => x.FinishedOn == null)
                .OrderByDescending(x => x.StartedOn)
                .ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
               
                    var expectedData = expectedResults[i];
                    var actualData = actualResults[i];

                    Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
                    Assert.True(expectedData.Name == actualData.Name,
                        errorMessagePrefix + " " + "Name is not returned properly.");
                    Assert.True(expectedData.Description == actualData.Description,
                        errorMessagePrefix + " " + "Price is not returned properly.");
                    Assert.True(expectedData.Mileage == actualData.Mileage,
                        errorMessagePrefix + " " + "Mileage is not returned properly.");
                    Assert.True(expectedData.RepairedSystemId == actualData.RepairedSystemId,
                        errorMessagePrefix + "RepairedSystemId" + "Price is not returned properly.");
                    Assert.True(expectedData.StartedOn == actualData.StartedOn,
                        errorMessagePrefix + " " + "StartedOn is not returned properly.");
                    Assert.True(expectedData.FinishedOn == actualData.FinishedOn,
                        errorMessagePrefix + " " + "FinishedOn is not returned properly.");
                    Assert.True(expectedData.Vehicle.Id == actualData.Vehicle.Id,
                        errorMessagePrefix + " " + "Vehicle.Id is not returned properly.");
                    Assert.True(expectedData.MdmsUser.Id == actualData.MdmsUser.Id,
                        errorMessagePrefix + " " + "MdmsUser.Id is not returned properly.");
                    Assert.True(expectedData.RepairedSystem.Name == actualData.RepairedSystem.Name,
                        errorMessagePrefix + " " + "RepairedSystem.Name is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllInternalActiveRepairs_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "VehicleService GetAllInternalActiveRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _repairService = new RepairService(context);

            List<InternalRepairServiceModel> actualResults = await Task.Run((() =>
                _repairService.GetAllInternalActiveRepairs().Result.ToList()));
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllInternalRepairs_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetAllInternalRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedInternalRepair(context);
            _repairService = new RepairService(context);

            List<InternalRepairServiceModel> actualResults = _repairService.GetAllInternalRepairs().ToList();
            List<InternalRepairServiceModel> expectedResults = context.ExternalRepairs
                .OrderByDescending(x => x.StartedOn).To<InternalRepairServiceModel>()
                .OrderByDescending(x => x.StartedOn)
                .ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {

                var expectedData = expectedResults[i];
                var actualData = actualResults[i];

                Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(expectedData.Name == actualData.Name,
                    errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedData.Description == actualData.Description,
                    errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedData.Mileage == actualData.Mileage,
                    errorMessagePrefix + " " + "Mileage is not returned properly.");
                Assert.True(expectedData.RepairedSystemId == actualData.RepairedSystemId,
                    errorMessagePrefix + "RepairedSystemId" + "Price is not returned properly.");
                Assert.True(expectedData.StartedOn == actualData.StartedOn,
                    errorMessagePrefix + " " + "StartedOn is not returned properly.");
                Assert.True(expectedData.FinishedOn == actualData.FinishedOn,
                    errorMessagePrefix + " " + "FinishedOn is not returned properly.");
                Assert.True(expectedData.Vehicle.Id == actualData.Vehicle.Id,
                    errorMessagePrefix + " " + "Vehicle.Id is not returned properly.");
                Assert.True(expectedData.MdmsUser.Id == actualData.MdmsUser.Id,
                    errorMessagePrefix + " " + "MdmsUser.Id is not returned properly.");
                Assert.True(expectedData.RepairedSystem.Name == actualData.RepairedSystem.Name,
                    errorMessagePrefix + " " + "RepairedSystem.Name is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllInternalRepairs_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "VehicleService GetAllInternalRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _repairService = new RepairService(context);

            List<InternalRepairServiceModel> actualResults = await Task.Run((() =>
                _repairService.GetAllInternalRepairs().ToList()));
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllExternalRepairs_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "RepairService GetAllExternalRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedExternalRepair(context);
            _repairService = new RepairService(context);

            List<ExternalRepairServiceModel> actualResults = _repairService.GetAllExternalRepairs().OrderByDescending(x => x.StartedOn).ToList();
            List<ExternalRepairServiceModel> expectedResults = context.ExternalRepairs.To<ExternalRepairServiceModel>()
                .OrderByDescending(x => x.StartedOn)
                .ToList();

            for (int i = 0; i < actualResults.Count; i++)
            {
                var expectedData = expectedResults[i];
                var actualData = actualResults[i];

                Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(expectedData.Name == actualData.Name,
                    errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedData.Description == actualData.Description,
                    errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedData.Mileage == actualData.Mileage,
                    errorMessagePrefix + " " + "Mileage is not returned properly.");
                Assert.True(expectedData.RepairedSystemId == actualData.RepairedSystemId,
                    errorMessagePrefix + "RepairedSystemId" + "Price is not returned properly.");
                Assert.True(expectedData.StartedOn == actualData.StartedOn,
                    errorMessagePrefix + " " + "StartedOn is not returned properly.");
                Assert.True(expectedData.FinishedOn == actualData.FinishedOn,
                    errorMessagePrefix + " " + "FinishedOn is not returned properly.");
                Assert.True(expectedData.Vehicle.Id == actualData.Vehicle.Id,
                    errorMessagePrefix + " " + "Vehicle.Id is not returned properly.");
                Assert.True(expectedData.MdmsUser.Id == actualData.MdmsUser.Id,
                    errorMessagePrefix + " " + "MdmsUser.Id is not returned properly.");
                Assert.True(expectedData.RepairedSystem.Name == actualData.RepairedSystem.Name,
                    errorMessagePrefix + " " + "RepairedSystem.Name is not returned properly.");
                Assert.True(expectedData.ExternalRepairProvider.Name == actualData.ExternalRepairProvider.Name,
                    errorMessagePrefix + " " + "ExternalRepairProvider.Name is not returned properly.");

            }
        }

        [Fact]
        public async Task GetAllExternalRepairs_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "VehicleService GetAllExternalRepairs() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _repairService = new RepairService(context);

            List<ExternalRepairServiceModel> actualResults = await Task.Run((() =>
                _repairService.GetAllExternalRepairs().OrderBy(x => x.StartedOn).ToList()));
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }
    }
}


