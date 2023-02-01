using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeCart.Models;
using ShoeCart.Repository;

namespace ShoeCart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_repository.GetAllCustomers());

        }

        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            if (customer.Age > 13 && customer.Age < 100)
            {
                return Ok(_repository.Add(customer));
            }
            else
            {
                return BadRequest();
            }
           
        }
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int id)

        {
            Customer customer = _repository.GetCustomer(id);
            if (customer == null)
            {
                NotFound();
            }

            return Ok(customer);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Customer customer)
        {
            return Ok(_repository.Update(customer));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            _repository.Remove(id);
            return NoContent();
        }

    }
}
