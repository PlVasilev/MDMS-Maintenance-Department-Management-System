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
    public class ReportServiceTests
    {
        private IReportService _reportService;

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
                            },

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

        private List<MonthlySalary> SeedMonthlySalaries()
        {
            return new List<MonthlySalary>
            {
                new MonthlySalary()
                {
                    Name = "S1_2019_2",
                    Month = 2,
                    Year = 2019,
                    HoursWorked = 10,
                    BaseSalary = 3000,
                    MechanicId = "U1",
                    Mechanic = new MdmsUser()
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
                    },
                    TotalSalary = 3500m
                },
                new MonthlySalary()
                {
                    Name = "S1_2019_4",
                    Month = 4,
                    Year = 2019,
                    HoursWorked = 10,
                    BaseSalary = 3000,
                    MechanicId = "U1",
                    Mechanic = new MdmsUser()
                    {
                        Id = "U1",
                        UserName = "Pesho",
                        FirstName = "Pesho",
                        LastName = "Peshov",
                        AdditionalOnHourPayment = 50m,
                        BaseSalary = 3400m,
                        Email = "Pesho@peshov.com,",
                        IsRepairing = true,
                        IsDeleted = false,
                        IsAuthorized = true,
                    },
                    TotalSalary = 3500m
                }
            };
        }

        private List<Report> SeedReports()
        {
            return new List<Report>
            {
                new Report()
                {
                    Name = "Custom_2019_1_2019_12",
                    StartMonth = 1,
                    StartYear = 2019,
                    EndMonth = 12,
                    EndYear = 2019,
                    IsDeleted = false,
                    VehiclesInReport = new List<Vehicle>()
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
                            },

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
            }
        },new Report()
                {
                    Name = "Custom_2018_12_2019_12",
                    StartMonth = 12,
                    StartYear = 2018,
                    EndMonth = 12,
                    EndYear = 2019,
                    IsDeleted = false,
                    VehiclesInReport = new List<Vehicle>()
            {
                new Vehicle
                {
                    Id = "V3",
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
                            Id = "ir12",
                            Name = "Internal_Breaking_Mercedes_Acteos_12345678901234564_2019/08/27_15:57",
                            Description = "Bolt Change",
                            VehicleId = "v1",
                            Mileage = 1000,
                            RepairedSystemId = "rs1",
                            StartedOn = DateTime.Now.AddDays(-7),
                            FinishedOn = DateTime.Now.AddDays(-1),
                            MdmsUserId = "u1",
                            InternalRepairParts = new List<InternalRepairPart>
                            {
                                new InternalRepairPart
                                {
                                    Part = new Part
                                    {
                                        Id = "P12",
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
                            },
                            MdmsUser = new MdmsUser()
                            {
                                Id = "U12",
                                UserName = "Pesho",
                                FirstName = "Pesho",
                                LastName = "Peshov",
                                AdditionalOnHourPayment = 50m,
                                BaseSalary = 3000m,
                                Email = "Pesho@peshov.com,",
                                IsRepairing = false,
                                IsDeleted = false,
                                IsAuthorized = true,
                            },

                        }

                    },VehicleType = new VehicleType
                    {
                        Name = "Truck1"
                    },
                    IsDeleted = false

                },
                new Vehicle
                {
                    Id = "V4",
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
                            Id = "ir12",
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
                        Name = "Car1"
                    },
                    IsDeleted = false
                }
            }
        },
            };
        }
        private async Task SeedVehicleAndMonthlySalarytData(MdmsDbContext context)
        {
            context.AddRange(GetVehicleDummyData());
            context.AddRange(SeedMonthlySalaries());
            await context.SaveChangesAsync();
        }

        private async Task SeedReportData(MdmsDbContext context)
        {
            context.AddRange(SeedReports());

            await context.SaveChangesAsync();
        }

        public ReportServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task CreateCustomReport_WithCorrectData_ShouldSuccessfullyCreateCustomReport()
        {
            string errorMessagePrefix = "ReportService CreateCustomReport() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedVehicleAndMonthlySalarytData(context);
            _reportService = new ReportService(context);

            ReportServiceModel report = new ReportServiceModel()
            {
                StartYear = 2019,
                StartMonth = 1,
                EndYear = 2019,
                EndMonth = 12
            };

            bool actualResult = await _reportService.CreateCustomReport(report);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateCustomReport_NotExistentPartProvider_ShouldNotCreatePart()
        {
            string errorMessagePrefix = "ReportService CreateCustomReport() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedVehicleAndMonthlySalarytData(context);
            _reportService = new ReportService(context);

            ReportServiceModel report = new ReportServiceModel()
            {
                StartYear = 0,
                StartMonth = 12,
                EndYear = 2019,
                EndMonth = 1
            };

            bool actualResult = await _reportService.CreateCustomReport(report);
            Assert.False(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task DeleteReport_WithCorrectData_ShouldSuccessfullyDeleteReport()
        {
            string errorMessagePrefix = "ReportService DeleteReport() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedReportData(context);
            _reportService = new ReportService(context);

            bool actualResult = await _reportService.DeleteReport("Custom_2019_1_2019_12");
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task DeleteReport_WithNonExistentName_ShouldSuccessThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedReportData(context);
            _reportService = new ReportService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _reportService.DeleteReport("idzzzzzz"));
        }


        [Fact]
        public async Task GetReportDetails_WithCorrectData_ShouldSuccessfullyGetReportDetails()
        {
            string errorMessagePrefix = "ReportService GetReportDetails() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedReportData(context);
            _reportService = new ReportService(context);

            ReportServiceModel actualReportData = await _reportService.GetReportDetails("Custom_2019_1_2019_12");
            ReportServiceModel expectedReportData = context.Reports
                .SingleOrDefaultAsync(x => x.Name == "Custom_2019_1_2019_12")
                .Result.To<ReportServiceModel>();

            var actualVehicles = actualReportData.VehiclesInReport.ToList();
            var expectedVehicles = expectedReportData.VehiclesInReport.ToList();

            Assert.True(actualReportData.Id == expectedReportData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(actualReportData.Name == expectedReportData.Name, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(actualReportData.StartYear == expectedReportData.StartYear, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(actualReportData.EndYear == expectedReportData.EndYear, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(actualReportData.StartMonth == expectedReportData.StartMonth, errorMessagePrefix + " " + "Id is not returned properly.");
            Assert.True(actualReportData.EndMonth == expectedReportData.EndMonth, errorMessagePrefix + " " + "Id is not returned properly.");


            for (int i = 0; i < actualReportData.VehiclesInReport.Count; i++)
            {
                var actualData = actualVehicles[i];
                var expectedData = expectedVehicles[i];

                Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(expectedData.Name == actualData.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedData.Price == actualData.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedData.Picture == actualData.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
                Assert.True(expectedData.Depreciation == actualData.Depreciation, errorMessagePrefix + "Depreciation" + "Depreciation is not returned properly.");
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
        }



        [Fact]
        public async Task GetReportDetails_WithNonExistentName_ShouldSuccessThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedReportData(context);
            _reportService = new ReportService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _reportService.GetReportDetails("Name"));
        }

        [Fact]
        public async Task GetAllReports_WithCorrectData_ShouldSuccessfullyGetAllReport()
        {
            string errorMessagePrefix = "ReportService GetAllReports() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedReportData(context);
            _reportService = new ReportService(context);

            List<ReportServiceModel> actualReportDataList = _reportService.GetAllReports().ToList();
            List<ReportServiceModel> expectedReportDataList = context.Reports.OrderBy(x => x.Name).To<ReportServiceModel>().ToList();

            for (int j = 0; j < actualReportDataList.Count; j++)
            {
                var actualReportData = actualReportDataList[j];
                var expectedReportData = expectedReportDataList[j];

                var actualVehicles = actualReportDataList[j].VehiclesInReport.ToList();
                var expectedVehicles = expectedReportDataList[j].VehiclesInReport.ToList();

                Assert.True(actualReportData.Id == expectedReportData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(actualReportData.Name == expectedReportData.Name, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(actualReportData.StartYear == expectedReportData.StartYear, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(actualReportData.EndYear == expectedReportData.EndYear, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(actualReportData.StartMonth == expectedReportData.StartMonth, errorMessagePrefix + " " + "Id is not returned properly.");
                Assert.True(actualReportData.EndMonth == expectedReportData.EndMonth, errorMessagePrefix + " " + "Id is not returned properly.");


                for (int i = 0; i < actualReportData.VehiclesInReport.Count; i++)
                {
                    var actualData = actualVehicles[i];
                    var expectedData = expectedVehicles[i];

                    Assert.True(expectedData.Id == actualData.Id, errorMessagePrefix + " " + "Id is not returned properly.");
                    Assert.True(expectedData.Name == actualData.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                    Assert.True(expectedData.Price == actualData.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                    Assert.True(expectedData.Picture == actualData.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
                    Assert.True(expectedData.Depreciation == actualData.Depreciation, errorMessagePrefix + "Depreciation" + "Depreciation is not returned properly.");
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
            }
        }



        [Fact]
        public async Task GetAllReports_WithNonExistentName_ShouldReturnEmptyCollection()
        {
            string errorMessagePrefix = "ReportService GetAllReports() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedReportData(context);
            _reportService = new ReportService(context);

            List<ReportServiceModel> actualResults = await _reportService.GetAllReports().ToListAsync();
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }
    }
}
