using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MDMS.Data;
using MDMS.Data.Models;
using MDMS.Services;
using MDMS.Services.Mapping;
using MDMS.Services.Models;
using MDMS.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;


namespace MDMS.Tests.ServiceTests
{
    public class PartServiceTests
    {
        private IPartService _partService;

        private List<Part> GetPartGetDummyData()
        {
            return new List<Part>()
            {
                new Part
                {
                    Id = "P1",
                    Name = "Blot 10.5x2",
                    Price = 10.2M,
                    UsedCount = 10,
                    Stock = 90,
                    AcquiredFrom = new PartsProvider()
                    {
                        Name = "Metal Strong"
                    },  InternalRepairParts = new List<InternalRepairPart>
                    {
                        new InternalRepairPart
                        {
                            InternalRepair = new InternalRepair
                            {
                                Id = "ir1",
                                Name = "Internal_Breaking_Mercedes_Acteos_12345678901234564_2019/08/27_15:57",
                                Description = "Bolt Change",
                                VehicleId = "v1",
                                Mileage = 1000,
                                RepairedSystemId = "rs1",
                                StartedOn = DateTime.Now.AddDays(-7),
                                FinishedOn =DateTime.Now.AddDays(-1),
                                MdmsUserId = "u1",
                                RepairCost = 122.2m,
                                HoursWorked = 1

                            },
                            PartId = "p1",
                            Quantity = 10
                        }
                    }

                },
                new Part
                {
                    Id = "P2",
                    Name = "Break Pad For Truck",
                    Price = 240.15M,
                    UsedCount = 0,
                    Stock = 10,
                    AcquiredFrom = new PartsProvider()
                    {
                        Name = "Brembo"
                    }
                }
            };
        }

        private List<PartsProvider> GetPartProviderDummyData()
        {
            return new List<PartsProvider>()
            {  new PartsProvider
                {
                    Name = "Metal Strong"
                },
                new PartsProvider
                {
                    Name = "Brembo"
                }
            };
        }

        private async Task SeedData(MdmsDbContext context)
        {
            context.AddRange(GetPartGetDummyData());
            await context.SaveChangesAsync();
        }

        public PartServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetAllParts_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "PartService GetAllParts() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _partService = new PartService(context);

            var criteria = "None";

            List<PartServiceModel> actualResults = await _partService.GetAllParts(criteria).ToListAsync();
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllParts_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllParts() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            var criteria = "None";
            List<PartServiceModel> actualResults = await _partService.GetAllParts(criteria).ToListAsync();
            List<PartServiceModel> expectedResults = GetPartGetDummyData().To<PartServiceModel>().OrderBy(x => x.Name).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.UsedCount == actualEntry.UsedCount, errorMessagePrefix + " " + "UsedCount is not returned properly.");
                Assert.True(expectedEntry.Stock == actualEntry.Stock, errorMessagePrefix + " " + "Stock is not returned properly.");
                Assert.True(expectedEntry.AcquiredFrom.Name == actualEntry.AcquiredFrom.Name, errorMessagePrefix + " " + "AquiredFrom is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllParts_WithDummyDataOrderByPriceAscending_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllParts() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            var criteria = "Price From Lowest To Highest";
            List<PartServiceModel> actualResults = await _partService.GetAllParts(criteria).ToListAsync();
            List<PartServiceModel> expectedResults = GetPartGetDummyData().To<PartServiceModel>().OrderBy(x => x.Price).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.UsedCount == actualEntry.UsedCount, errorMessagePrefix + " " + "UsedCount is not returned properly.");
                Assert.True(expectedEntry.Stock == actualEntry.Stock, errorMessagePrefix + " " + "Stock is not returned properly.");
                Assert.True(expectedEntry.AcquiredFrom.Name == actualEntry.AcquiredFrom.Name, errorMessagePrefix + " " + "AquiredFrom is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllParts_WithDummyDataOrderByPriceDescending_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllParts() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            var criteria = "Price From Highest To Lowest";
            List<PartServiceModel> actualResults = await _partService.GetAllParts(criteria).ToListAsync();
            List<PartServiceModel> expectedResults = GetPartGetDummyData().To<PartServiceModel>().OrderByDescending(x => x.Price).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.UsedCount == actualEntry.UsedCount, errorMessagePrefix + " " + "UsedCount is not returned properly.");
                Assert.True(expectedEntry.Stock == actualEntry.Stock, errorMessagePrefix + " " + "Stock is not returned properly.");
                Assert.True(expectedEntry.AcquiredFrom.Name == actualEntry.AcquiredFrom.Name, errorMessagePrefix + " " + "AquiredFrom is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllParts_WithDummyDataOrderByStockAscending_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllParts() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            var criteria = "Stock From Lowest To Highest";
            List<PartServiceModel> actualResults = await _partService.GetAllParts(criteria).ToListAsync();
            List<PartServiceModel> expectedResults = GetPartGetDummyData().To<PartServiceModel>().OrderBy(x => x.Stock).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.UsedCount == actualEntry.UsedCount, errorMessagePrefix + " " + "UsedCount is not returned properly.");
                Assert.True(expectedEntry.Stock == actualEntry.Stock, errorMessagePrefix + " " + "Stock is not returned properly.");
                Assert.True(expectedEntry.AcquiredFrom.Name == actualEntry.AcquiredFrom.Name, errorMessagePrefix + " " + "AquiredFrom is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllParts_WithDummyDataOrderByStockDescending_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllParts() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            var criteria = "Stock From Highest To Lowest";
            List<PartServiceModel> actualResults = await _partService.GetAllParts(criteria).ToListAsync();
            List<PartServiceModel> expectedResults = GetPartGetDummyData().To<PartServiceModel>().OrderByDescending(x => x.Stock).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.UsedCount == actualEntry.UsedCount, errorMessagePrefix + " " + "UsedCount is not returned properly.");
                Assert.True(expectedEntry.Stock == actualEntry.Stock, errorMessagePrefix + " " + "Stock is not returned properly.");
                Assert.True(expectedEntry.AcquiredFrom.Name == actualEntry.AcquiredFrom.Name, errorMessagePrefix + " " + "AquiredFrom is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllParts_WithDummyDataOrderByUsedCountAscending_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllParts() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            var criteria = "Used From Lowest To Highest";
            List<PartServiceModel> actualResults = await _partService.GetAllParts(criteria).ToListAsync();
            List<PartServiceModel> expectedResults = GetPartGetDummyData().To<PartServiceModel>().OrderBy(x => x.UsedCount).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.UsedCount == actualEntry.UsedCount, errorMessagePrefix + " " + "UsedCount is not returned properly.");
                Assert.True(expectedEntry.Stock == actualEntry.Stock, errorMessagePrefix + " " + "Stock is not returned properly.");
                Assert.True(expectedEntry.AcquiredFrom.Name == actualEntry.AcquiredFrom.Name, errorMessagePrefix + " " + "AquiredFrom is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllParts_WithDummyDataOrderByUsedCountDescending_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllParts() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            var criteria = "Used From Highest To Lowest";
            List<PartServiceModel> actualResults = await _partService.GetAllParts(criteria).ToListAsync();
            List<PartServiceModel> expectedResults = GetPartGetDummyData().To<PartServiceModel>().OrderByDescending(x => x.UsedCount).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.UsedCount == actualEntry.UsedCount, errorMessagePrefix + " " + "UsedCount is not returned properly.");
                Assert.True(expectedEntry.Stock == actualEntry.Stock, errorMessagePrefix + " " + "Stock is not returned properly.");
                Assert.True(expectedEntry.AcquiredFrom.Name == actualEntry.AcquiredFrom.Name, errorMessagePrefix + " " + "AquiredFrom is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllPartProviders_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "PartService GetAllPartProviders() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            _partService = new PartService(context);

            List<PartsProviderServiceModel> actualResults = await _partService.GetAllPartProviders().ToListAsync();
            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllPartProviders_WithDummyPartProviderDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetAllPartProviders() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            List<PartsProviderServiceModel> actualResults = await _partService.GetAllPartProviders().ToListAsync();
            List<PartsProviderServiceModel> expectedResults = GetPartProviderDummyData().To<PartsProviderServiceModel>().OrderBy(x => x.Name).ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned properly.");
            }
        }

        [Fact]
        public async Task GetPartByName_WithNonExistentName_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _partService.GetPartByName("Name"));
        }


        [Fact]
        public async Task GetPartByName_WithExistentName_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "PartService GetPartByName() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            PartServiceModel expectedData = context.Parts.SingleOrDefault(x => x.Name == "Blot 10.5x2").To<PartServiceModel>();
            PartServiceModel actualData = await _partService.GetPartByName("Blot 10.5x2");

            Assert.True(expectedData.Name == actualData.Name, errorMessagePrefix + " " + "Name is not returned properly.");
            Assert.True(expectedData.Price == actualData.Price, errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.UsedCount == actualData.UsedCount, errorMessagePrefix + " " + "UsedCount is not returned properly.");
            Assert.True(expectedData.Stock == actualData.Stock, errorMessagePrefix + " " + "Stock is not returned properly.");
            Assert.True(expectedData.AcquiredFrom.Name == actualData.AcquiredFrom.Name, errorMessagePrefix + " " + "AquiredFrom is not returned properly.");
        }

        [Fact]
        public async Task CreatePart_WithCorrectData_ShouldSuccessfullyCreatePart()
        {
            string errorMessagePrefix = "PartService GetPartByName() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            PartServiceModel part = new PartServiceModel()
            {
                Id = "P3",
                Name = "Break Pad For Trailer",
                Price = 140.15M,
                UsedCount = 0,
                Stock = 5,
                AcquiredFrom = new PartsProviderServiceModel()
                {
                    Name = "Brembo"
                }
            };

            bool actualResult = await _partService.Create(part);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreatePart_NotExistentPartProvider_ShouldNotCreatePart()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _partService.Create(new PartServiceModel()
            {
                Id = "P3",
                Name = "Break Pad For Trailer",
                Price = 140.15M,
                UsedCount = 0,
                Stock = 5,
                AcquiredFrom = context.Parts.SingleOrDefault(x => x.Name == "Trembol").To<PartsProviderServiceModel>()
            }));

        }

        [Fact]
        public async Task CreatePartProvider_WithCorrectData_ShouldSuccessfullyCreatePartProvider()
        {
            string errorMessagePrefix = "PartService CreatePartProvider() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            bool actualResult = await _partService.CreatePartProvider(new PartsProviderServiceModel()
            {
                Name = "Brembo2"
            });
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task CreatePartProvider_WithDublicateName_ShouldFailToCreatePartProvider()
        {
            string errorMessagePrefix = "PartService CreatePartProvider() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            bool actualResult = await _partService.CreatePartProvider(new PartsProviderServiceModel()
            {
                Name = "Brembo"
            });
            Assert.False(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task EditPart_WithWrongData_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _partService.EditPart(
                context.Parts.SingleOrDefault(x => x.Name == "Break Pad For Trailer")
                    .To<PartServiceModel>()));
        }

        [Fact]
        public async Task DeletePart_WithCorrectData_ShouldDeletePart()
        {
            string errorMessagePrefix = "PartService DeletePart() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            bool actualResult = await _partService.DeletePart("Break Pad For Truck");
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task DeletePart_WithNonExistedPartNameData_ShouldThrowExceptionDeletePart()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _partService.DeletePart("name"));
        }

        [Fact]
        public async Task AddStockPart_WithCorrectData_ShouldAddStock()
        {
            string errorMessagePrefix = "PartService AddStock() method does not work properly.";

            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            bool actualResult = await _partService.AddStock("Blot 10.5x2",5);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task AddStockPart_WithNonExistingName_ShouldThrowException()
        {
            var context = MdmsDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            _partService = new PartService(context);

            await Assert.ThrowsAsync<NullReferenceException>(() => _partService.AddStock("name",5));
        }

    }
}
