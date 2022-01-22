using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.DbOperations;
using Unluco.Egitim.HW1.Api.Models;

namespace Unluco.Egitim.HW1.Api.EmployeeOperations.GetEmployees
{
    public class GetEmployeesQuery
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetEmployeesQuery(EmployeeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetEmployeeModel> Handle()
        {
            var employeelist = _dbContext.Employees.OrderBy(x => x.Id).ToList<Employee>();
            List<GetEmployeeModel> vm = _mapper.Map<List<GetEmployeeModel>>(employeelist);
             return vm;
        }

        public class GetEmployeeModel
        {
            public string Name { get; set; }
            public string CompanyName { get; set; }
            public string PhoneNumber { get; set; }
            public string ProjectName { get; set; }
        }
    }
}
