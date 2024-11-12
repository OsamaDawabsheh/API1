using API1.Models;
using Microsoft.EntityFrameworkCore;

namespace API1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }

   
}
