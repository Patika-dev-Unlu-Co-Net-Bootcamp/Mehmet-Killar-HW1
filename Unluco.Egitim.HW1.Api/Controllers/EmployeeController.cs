using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unluco.Egitim.HW1.Api.Models;

namespace Unluco.Egitim.HW1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public List<Employee> employeeList = new List<Employee>()
        {
            new Employee{Id=1,Name="Hasan",PhoneNumber="12354679",CompanyName="A Company",ProjectName="qbitra"},
            new Employee{Id=2,Name="Mert",PhoneNumber="987654321",CompanyName="B Company",ProjectName="zozi"},
            new Employee{Id=3,Name="Murat",PhoneNumber="564987321",CompanyName="C Company",ProjectName="zoqlab"}
        };

        [HttpGet("get")]
        public IActionResult Get([FromQuery] string reverse)
        {
            try
            {
                var employees = new List<Employee>();
                if (reverse==null || reverse == "")
                {
                    employees = employeeList;
                    if (employees != null) return Ok(employees);
                    else return NotFound();
                }
                else
                {
                    employees = employeeList.OrderByDescending(m => m.Id).ToList();
                    return Ok(employees);
                }
                               
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
     
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var employee = employeeList.SingleOrDefault(m => m.Id==id);
                if (employee != null) return Ok(employee);                
                else return NotFound();                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]Employee employee)
        {
            try
            {
                var _employee = employeeList.SingleOrDefault(m => m.Id == employee.Id);
                if (_employee != null) return NotFound();
                else
                {
                    Employee newEmployee = new Employee();
                    newEmployee.Id = employee.Id;
                    newEmployee.Name = employee.Name;
                    newEmployee.PhoneNumber = employee.PhoneNumber;
                    newEmployee.CompanyName = employee.CompanyName;
                    newEmployee.ProjectName = employee.ProjectName;

                    employeeList.Add(newEmployee);
                    return Created("Created", newEmployee);
                }
                    
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id,[FromBody] Employee employee)
        {
            try
            {
                Employee _employee = (Employee)employeeList.SingleOrDefault(m => m.Id == id);
                if (_employee != null)
                {
                    _employee.Id = employee.Id;
                    _employee.Name = employee.Name;
                    _employee.PhoneNumber = employee.PhoneNumber;
                    _employee.CompanyName = employee.CompanyName;
                    _employee.ProjectName = employee.ProjectName;

                    return Ok(_employee);
                }
                else return NotFound();                
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPatch("patch/{id}/")]
        public IActionResult Patch(int id, [FromQuery]string projectName)
        {
            try
            {
                Employee _employee = (Employee)employeeList.SingleOrDefault(m => m.Id == id);
                if (_employee != null) {
                    _employee.ProjectName = projectName;
                    return Ok(_employee); 
                } 
                else return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Employee _employee = (Employee)employeeList.SingleOrDefault(m => m.Id == id);
                if (_employee != null)
                {
                    employeeList.Remove(_employee);
                    return Ok();
                } 
                else return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }

}
