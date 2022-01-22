using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.Models;

namespace Unluco.Egitim.HW1.Api.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EmployeeDbContext(serviceProvider.GetRequiredService<DbContextOptions<EmployeeDbContext>>()))
            {
                if (context.Employees.Any()) return;

                context.Employees.AddRange(

                    new Employee { Id = 1, Name = "Hasan", PhoneNumber = "12354679", CompanyName = "A Company", ProjectName = "qbitra" },
                    new Employee { Id = 2, Name = "Mert", PhoneNumber = "987654321", CompanyName = "B Company", ProjectName = "zozi" },
                    new Employee { Id = 3, Name = "Murat", PhoneNumber = "564987321", CompanyName = "C Company", ProjectName = "zoqlab" }
                );
                context.SaveChanges();
            }
        }
    }
}
