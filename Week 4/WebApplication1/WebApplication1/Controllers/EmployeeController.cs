using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [Route("api/emp")]
    [ApiController]
    //[CustomAuthFilter]
    [Authorize(Roles ="Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> GetStandardEmployeeList()
        {
            var devDepartment = new Department { Id = 1, Name = "Development" };
            var hrDepartment = new Department { Id = 2, Name = "Human Resources" };

            var csharpSkill = new Skill { Id = 101, Name = "C#" };
            var sqlSkill = new Skill { Id = 102, Name = "SQL" };
            var adminSkill = new Skill { Id = 103, Name = "Administration" };

            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 80000,
                    Permanent = true,
                    Department = devDepartment,
                    Skills = new List<Skill> { csharpSkill, sqlSkill },
                    DateOfBirth = new DateTime(1990, 5, 15)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Salary = 65000,
                    Permanent = true,
                    Department = hrDepartment,
                    Skills = new List<Skill> { adminSkill },
                    DateOfBirth = new DateTime(1992, 8, 21)
                }
            };

            return employees;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Employee> Get()
        {
            return GetStandardEmployeeList();
        }
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmployee)
        {
            
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var employeeList = GetStandardEmployeeList();

            var employeeToUpdate = employeeList.FirstOrDefault(e => e.Id == id);

            if (employeeToUpdate == null)
            {
                return BadRequest("Invalid employee id");
            }

            employeeToUpdate.Name = updatedEmployee.Name;
            employeeToUpdate.Salary = updatedEmployee.Salary;
            employeeToUpdate.Permanent = updatedEmployee.Permanent;

            return Ok(employeeToUpdate);
        }

    }
}
