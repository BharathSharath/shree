using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using YourApplication.Models;

namespace YourApplication.Data
{
    public class DbInitializer
    {
        public void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (!context.KYC.Any())
            {
                context.KYC.AddRange(
                    new KYC { KYCID = 100145, Name = "SomeName", Gender = "Male" },
                    new KYC { KYCID = 100146, Name = "AnotherName", Gender = "Female" }
                );

                context.SaveChanges();
            }

            if (!context.Project.Any())
            {
                context.Project.AddRange(
                    new Project { ProjectID = "P1001", ProjectName = "PElectronics", KYCID = 100145 },
                    new Project { ProjectID = "P1002", ProjectName = "PComputers", KYCID = 100145 },
                    new Project { ProjectID = "P1003", ProjectName = "PComputers", KYCID = 100146 }
                );

                context.SaveChanges();
            }
        }
    }
}
