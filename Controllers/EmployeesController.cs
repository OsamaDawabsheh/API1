using API1.Data;
using API1.DTOs.Employees;
using API1.Models;
using Azure.Core;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var employees = context.Employees.ToList();
            var empDto = employees.Adapt<IEnumerable<GetEmployeeDto>>();
            return Ok(empDto);
        }


        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            var empDto = employee.Adapt<GetEmployeeDto>();

            return Ok(empDto);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateEmployeeDto request)
        {
            context.Employees.Add(request.Adapt<Employee>());
            context.SaveChanges();
            return Ok(request);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id , CreateEmployeeDto request)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            request.Adapt(employee);
            context.SaveChanges();
            return Ok(request);
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            context.Employees.Remove(employee);
            context.SaveChanges();
            return Ok(employee);
        }


    }
}
