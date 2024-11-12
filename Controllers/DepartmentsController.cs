using API1.Data;
using API1.DTOs.Departments;
using API1.Models;
using Azure.Core;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DepartmentsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var departments = context.Departments.Select(dep => new GetDepartmentDto { Id = dep.Id,Name =dep.Name,Description=dep.Description});
            return Ok(departments);
        }


        [HttpGet("GetDepartment")]
        public IActionResult GetEmployee(int id)
        {
            var department = context.Departments.Where(d => d.Id == id).Select(dep => new GetDepartmentDto { Id = dep.Id, Name = dep.Name, Description = dep.Description });
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost("Create")]

        public IActionResult Create(CreateDepartmentDto request)
        {
            Department department = new Department() {Name = request.Name, Description = request.Description };
            context.Departments.Add(department);
            context.SaveChanges();
            return Ok(request);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, CreateDepartmentDto request)
        {
            var department = context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            Department dep = new Department() { Name = request.Name, Description = request.Description };

            context.SaveChanges();
            return Ok(request);
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(int id)
        {
            var department = context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            context.Departments.Remove(department);
            context.SaveChanges();
            return Ok(department);
        }
    }
}
