using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotel_management
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return customerService.Get();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = customerService.Get(id);

            if (customer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            return customer;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            Customer tempUser = new Customer()
            {
                Name = customer.Name,
                Gender = customer.Gender,
                Age = customer.Age,
                IdentityProof = customer.IdentityProof,
                Phone = customer.Phone,
                PaymentDetails = customer.PaymentDetails,
                IsActive = customer.IsActive
            };

            var savedCustomer = customerService.Create(tempUser);
            return CreatedAtAction(nameof(Get), new { id = savedCustomer.Id }, savedCustomer);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]

        public IActionResult Put(string id, [FromBody] Customer customer)
        {
            var customerFromDb = customerService.Get(id);

            if (customerFromDb == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            customerService.Update(id, customer);

            return NoContent();   
          
        }

        // DELETE api/<CustomersController>/5

        [HttpDelete("{id}")]

        public IActionResult Delete(string id)
        {
            var customerFromDb = customerService.Get(id);

            if (customerFromDb == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            customerService.Remove(customerFromDb.Id);

            return NoContent();
        }


    }
}





