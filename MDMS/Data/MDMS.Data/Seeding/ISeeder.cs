using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDMS.Data.Seeding
{
   public interface ISeeder
    {
        Task Seed();
    }
}
