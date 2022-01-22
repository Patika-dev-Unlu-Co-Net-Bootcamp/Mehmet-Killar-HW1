using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.DbOperations;

namespace Unluco.Egitim.HW1.Api.EmployeeOperations.GetEmployeeById
{
    public class GetEmployeeByIdQuery
    {
        private readonly EmployeeDbContext _dbContext;
        public int EmployeeId { get; set; }

        private readonly IMapper _mapper;

        public GetEmployeeByIdQuery(EmployeeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetByIdEmployeeModel Handle()
        {
                var employee = _dbContext.Employees.SingleOrDefault(m => m.Id == EmployeeId);
            if (employee is null) throw new InvalidOperationException("Müşteri Bulunamadı");
            GetByIdEmployeeModel vm = _mapper.Map<GetByIdEmployeeModel>(employee);
            return vm;
        }
    }
    public class GetByIdEmployeeModel
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProjectName { get; set; }
    }
}
