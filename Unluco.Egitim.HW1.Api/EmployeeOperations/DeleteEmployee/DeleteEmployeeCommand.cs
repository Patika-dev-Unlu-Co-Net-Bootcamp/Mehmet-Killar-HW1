using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.DbOperations;

namespace Unluco.Egitim.HW1.Api.EmployeeOperations.DeleteEmployee
{
    public class DeleteEmployeeCommand
    {
        private readonly EmployeeDbContext _dbContext;
        public int EmployeeId;

        public DeleteEmployeeCommand(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var employee = _dbContext.Employees.SingleOrDefault(x => x.Id == EmployeeId);
            if (employee is null)
                throw new InvalidOperationException("Silinecek müşteri bulunamadı");
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }
    }
}
