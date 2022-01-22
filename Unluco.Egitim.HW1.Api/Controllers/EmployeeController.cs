using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.DbOperations;
using Unluco.Egitim.HW1.Api.EmployeeOperations.CreateEmployee;
using Unluco.Egitim.HW1.Api.EmployeeOperations.DeleteEmployee;
using Unluco.Egitim.HW1.Api.Models;
using FluentValidation;
using static Unluco.Egitim.HW1.Api.EmployeeOperations.CreateEmployee.CreateEmployeeCommand;
using Unluco.Egitim.HW1.Api.EmployeeOperations.GetEmployeeById;
using Unluco.Egitim.HW1.Api.EmployeeOperations.GetEmployees;
using Unluco.Egitim.HW1.Api.EmployeeOperations.UpdateEmployee;
using static Unluco.Egitim.HW1.Api.EmployeeOperations.UpdateEmployee.UpdateEmployeeCommand;

namespace Unluco.Egitim.HW1.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _dbcontext;
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeDbContext dbcontext,IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string reverse)
        {
            GetEmployeesQuery query = new GetEmployeesQuery(_dbcontext,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
     
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdEmployeeModel result;
            GetEmployeeByIdQuery query = new GetEmployeeByIdQuery(_dbcontext, _mapper);
            query.EmployeeId = id;
            GetEmployeeByIdQueryValidator validator = new GetEmployeeByIdQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateEmployeeModel employee)
        {
            CreateEmployeeCommand command = new CreateEmployeeCommand(_dbcontext, _mapper);
            command.Model = employee;
            CreateEmployeeCommandValidator validator = new CreateEmployeeCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id,[FromBody] UpdateEmployeeModel employee)
        {
            UpdateEmployeeCommand command = new UpdateEmployeeCommand(_dbcontext);
            command.EmployeeId = Convert.ToInt32(id);
            UpdateEmployeeCommandValidator validator = new UpdateEmployeeCommandValidator();
            validator.ValidateAndThrow(command);
            command.Model = employee;
            return Ok();

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteEmployeeCommand command = new DeleteEmployeeCommand(_dbcontext);
            command.EmployeeId = id;
            DeleteEmployeeCommandValidator validator = new DeleteEmployeeCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }

}
