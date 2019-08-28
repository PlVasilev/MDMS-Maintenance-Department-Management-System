using System;
using MDMS.Data;
using Microsoft.EntityFrameworkCore;

namespace MDMS.Tests.Common
{
   public static class MdmsDbContextInMemoryFactory
    {
        public static MdmsDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<MdmsDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new MdmsDbContext(options);
        }
    }
}
