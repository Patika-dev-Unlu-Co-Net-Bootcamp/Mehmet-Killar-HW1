using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.DbOperations;

namespace Unluco.Egitim.HW1.Api.EmployeeOperations.UpdateEmployee
{
    public class UpdateEmployeeCommand
    {
        public UpdateEmployeeModel Model { get; set; }
        private readonly EmployeeDbContext _dbContext;
        public int EmployeeId { get; set; }

        public UpdateEmployeeCommand(EmployeeDbContext dbContext)
        {
            var employee = _dbContext.Employees.SingleOrDefault(x => x.Id == EmployeeId);
            if (employee is null)
                throw new InvalidOperationException("Kitap mevcut değil");
            employee.Name = employee.Name != default ? Model.Name : employee.Name;
            employee.PhoneNumber = employee.PhoneNumber != default ? Model.PhoneNumber : employee.PhoneNumber;
            employee.CompanyName = employee.CompanyName != default ? Model.CompanyName : employee.CompanyName;
            employee.ProjectName = employee.ProjectName != default ? Model.ProjectName : employee.ProjectName;

            _dbContext.SaveChanges();
        }

        public class UpdateEmployeeModel
        {
            public string Name { get; set; }
            public string CompanyName { get; set; }
            public string PhoneNumber { get; set; }
            public string ProjectName { get; set; }
        }
    }
}
