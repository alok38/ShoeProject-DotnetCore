using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeCart.Models;
using ShoeCart.Repository;

namespace ShoeCart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repository;
        public AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            return Ok(_repository.GetAllAdmins());

        }

        [HttpPost]
        public IActionResult Create([FromBody] Admin admin)
        {
            return Ok(_repository.Add(admin));

        }
        [HttpGet("{id}", Name = "GetAdmin")]
        public IActionResult GetAdmin(int id)

        {
            Admin admin = _repository.GetAdmin(id);
            if (admin == null)
            {
                NotFound();
            }

            return Ok(admin);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Admin admin)
        {
            return Ok(_repository.Update(admin));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            _repository.Remove(id);
            return NoContent();
        }

    }
}
