using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeCart.Models;
using ShoeCart.Repository;

namespace ShoeCart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repository;
        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cart cart)
        {
            return Ok(_repository.Add(cart));

        }
        [HttpGet("{id}", Name = "GetCart")]
        public IActionResult GetCart(int id)

        {
            Cart cart = _repository.GetCart(id);
            if (cart == null)
            {
                NotFound();
            }

            return Ok(cart);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            _repository.Remove(id);
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetAllCartsByCustomerId")]
        public IActionResult GetAllCartsByCustomerId(int id)
        {
            return Ok(_repository.GetCartsByCustomerId(id));
        }
       
    }
}
