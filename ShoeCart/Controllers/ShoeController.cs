using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeCart.Models;
using ShoeCart.Repository;

namespace ShoeCart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private readonly IShoeRepository _repository;
        public ShoeController(IShoeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllShoes()
        {
            return Ok(_repository.GetAllShoes());

        }

        [HttpPost]
        public IActionResult Create([FromBody] Shoe shoe)
        {
            return Ok(_repository.Add(shoe));

        }
        [HttpGet("{id}", Name = "GetShoe")]
        public IActionResult GetShoe(int id)

        {
            Shoe shoe = _repository.GetShoe(id);
            if (shoe == null)
            {
                NotFound();
            }

            return Ok(shoe);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Shoe shoe)
        {
          
            return Ok(_repository.Update(shoe));

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            _repository.Remove(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult SortShoesByName()
        {
            return Ok(_repository.SortByName());

        }
        [HttpGet]
        public IActionResult SortShoesByNameDescending()
        {
            return Ok(_repository.SortByNameDescending());

        }
        [HttpGet]
        public IActionResult SortShoesByBrand()
        {
            return Ok(_repository.SortByBrand());

        }

        [HttpGet]
        public IActionResult SortShoesByBrandDescending()
        {
            return Ok(_repository.SortByBrandDescending());

        }
        [HttpGet]
        public IActionResult SortShoesByPriceDescending()
        {
            return Ok(_repository.SortByPriceDescending());

        }
        [HttpGet]
        public IActionResult SortShoesByPrice()
        {
            return Ok(_repository.SortByPrice());

        }
        [HttpGet]
        public IActionResult SortShoesBySizeDescending()
        {
            return Ok(_repository.SortBySizeDescending());

        }
        [HttpGet]
        public IActionResult SortShoesBySize()
        {
            return Ok(_repository.SortBySize());

        }
    }
}

