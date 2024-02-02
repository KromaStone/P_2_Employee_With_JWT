using Employee_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {            
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
