using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
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
                IsActive=employee.IsActive
            };

            var savedEmployee = employeeService.Create(tempUser);
            return CreatedAtAction(nameof(Get), new { id = savedEmployee.Id }, savedEmployee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Employee employee)
        {
            var existingEmployee = employeeService.Get(id);

            if (existingEmployee == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            employeeService.Update(id, employee);

            return NoContent();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var employee = employeeService.Get(id);

            if (employee == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            employeeService.Remove(employee.Id);

            return Ok($"Employee with Id = {id} deleted");
        }

        //login api/<EmployeesController>/5


        [HttpGet("{employeeId}/{password}")]
        public ActionResult<Employee> GetByEmployeeId(string employeeId, string password)
        {
            var employee = employeeService.GetByeEmployeeId(employeeId);
            if (employee == null)
            {
                return NotFound($"Employee with Id = {employeeId} not found");
            }
            if (employee.Password == password)
            {
                return Ok($"Employee with Id = {employeeId} logged in");
            }
            if (employee.Password != password)
            {
                return Ok($"Hey!! {employeeId} you entered Invalid Password");
            }
            else
            {
                return NotFound($"Employee with Id = {employeeId} not found");
            }
        }
        





    }
}
