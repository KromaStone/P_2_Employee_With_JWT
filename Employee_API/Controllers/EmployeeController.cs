using Employee_API.Data;
using Employee_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_API.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Employees.ToList());
            
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            return Ok(employee);
        }


        [HttpPost]
        public IActionResult AddEmployee([FromBody]Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok("Employee Added");
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            var emplyeeInDb = _context.Employees.FirstOrDefault();
            if (emplyeeInDb == null) return NotFound("Id doesn't Exist in Database");
            if (!ModelState.IsValid) return BadRequest();
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok("Employee Updated");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id) 
        {
            var employeeInDb= _context.Employees.Find(id);  
            if(employeeInDb == null) return NotFound("Id doesn't Exist in Database");
            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();
            return Ok("Employee Deleted");
        }
    }
}

//git 2ok