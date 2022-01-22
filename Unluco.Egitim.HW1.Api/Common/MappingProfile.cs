using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.Models;
using static Unluco.Egitim.HW1.Api.EmployeeOperations.CreateEmployee.CreateEmployeeCommand;
using static Unluco.Egitim.HW1.Api.EmployeeOperations.UpdateEmployee.UpdateEmployeeCommand;

namespace Unluco.Egitim.HW1.Api.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeModel, Employee>();
            CreateMap<UpdateEmployeeModel, Employee>();
        }
    }
}
