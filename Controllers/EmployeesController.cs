using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotel_management
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        
        // GET: api/<EmployeesController>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return employeeService.Get();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            var employee = employeeService.Get(id);

            if (employee == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return employee;
        }

        // POST api/<EmployeesController>
        [HttpPost("{IsAdmin}")]
        public ActionResult<Employee> Post(bool IsAdmin, [FromBody] Employee employee)
        {
            if (IsAdmin == false)
            {
                return NotFound("You are Not authorized to add employee");
            }

            Employee tempUser = new Employee()
            {
                Name = employee.Name,
                Gender=employee.Gender,
                Age=employee.Age,
                EmployeeId=employee.EmployeeId,
                Password=employee.Password,
                Salary = employee.Salary,
                Phone=employee.Phone,
                Email=employee.Email,
                Address=employee.Address,
                IsActive=employee.IsActive,
                IsAdmin=employee.IsAdmin
            };

            var savedEmployee = employeeService.Create(tempUser);
            return CreatedAtAction(nameof(Get), new { id = savedEmployee.Id }, savedEmployee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id,IsAdmin}")]
        public ActionResult Put(string id,bool IsAdmin, [FromBody] Employee employee)
        {
            if (IsAdmin == false)
            {
                return NotFound("You are Not authorized to update employee");
            }

            var existingEmployee = employeeService.Get(id);

            if (existingEmployee == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            employeeService.Update(id, employee);

            return NoContent();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id,IsAdmin}")]
        public ActionResult Delete(string id, bool IsAdmin)
        {
            if (IsAdmin == false)
            {
                return NotFound("You are Not authorized to delete employee");
            }

            var employee = employeeService.Get(id);

            if (employee == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            employeeService.Remove(employee.Id);

            return Ok($"Employee with Id = {id} deleted");
        }
        
         // Login api/<EmployeesController>
        [HttpPost]

        public ActionResult<Employee> Post(string EmployeeId, string Password)
        {
            if(EmployeeId==null || Password==null)
            {
                return NotFound("Please enter both EmployeeId and Password");
            }
            var employeee = employeeService.GetByEmployeeId(EmployeeId);

            if (employeee == null)
            {
                return NotFound($"Employee with EmployeeId = {EmployeeId} not found");
            }

            if(Password!= employeee.Password)
            {
                return NotFound("Password is incorrect");
            }          
            return employeee;
        }
    }
}
