using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeCart.Models;
using ShoeCart.Repository;

namespace ShoeCart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            return Ok(_repository.Add(order));

        }
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetOrder(int id)

        {
            Order order = _repository.GetOrder(id);
            if (order == null)
            {
                NotFound();
            }

            return Ok(order);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            _repository.Remove(id);
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetAllShoesByOrderId")]
        public IActionResult GetAllShoesByOrderId(int id)
        {
            return Ok(_repository.GetShoesByOrderId(id));
        }
    }
}
