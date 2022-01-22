using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.Models;

namespace Unluco.Egitim.HW1.Api.DbOperations
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }
    }
}
