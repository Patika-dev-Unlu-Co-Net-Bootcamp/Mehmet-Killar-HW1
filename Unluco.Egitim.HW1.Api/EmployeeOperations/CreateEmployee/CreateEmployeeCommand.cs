using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.DbOperations;
using Unluco.Egitim.HW1.Api.Models;

namespace Unluco.Egitim.HW1.Api.EmployeeOperations.CreateEmployee
{
    public class CreateEmployeeCommand
    {
        public CreateEmployeeModel Model { get; set; }

        private readonly EmployeeDbContext _dbContext;

        private readonly IMapper _mapper;

        public CreateEmployeeCommand(EmployeeDbContext dbcontext,IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var employee = _dbContext.Employees.SingleOrDefault(m => m.Name == Model.Name);
            if (employee != null) throw new InvalidOperationException("Müşteri zaten mevcut");

            employee = _mapper.Map<Employee>(Model);
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();            
        }

       
        public class CreateEmployeeModel
        {
            public string Name { get; set; }
            public string CompanyName { get; set; }
            public string PhoneNumber { get; set; }
            public string ProjectName { get; set; }
        }
    }
}
