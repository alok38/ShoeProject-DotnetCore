using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeCart.Models;
using ShoeCart.Repository;

namespace ShoeCart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IReviewRepository _repository;
        public ReviewController(IReviewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllReviews()
        {
            return Ok(_repository.GetAllReviews());

        }

        [HttpPost]
        public IActionResult Create([FromBody] Review review)
        {
            return Ok(_repository.Add(review));

        }
        [HttpGet("{id}", Name = "GetReview")]
        public IActionResult GetReview(int id)

        {
            Review review = _repository.GetReview(id);
            if (review == null)
            {
                NotFound();
            }

            return Ok(review);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Review review)
        {
            return Ok(_repository.Update(review));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Remove(id);
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetAllReviewsByShoeId")]
        public IActionResult GetAllReviewsByShoeId(int id)
        {
            return Ok(_repository.ReviewsByShoeId(id));
        }

        [HttpGet]
        public IActionResult SortByRating()
        {
            return Ok(_repository.SortByRatingPositive());
        }

        [HttpGet]
        public IActionResult SortByRatingBad()
        {
            return Ok(_repository.SortByRatingCritical());
        }
        [HttpGet]
        public IActionResult SortByReviewTimeNew()
        {
            return Ok(_repository.SortByReviewTimeNewest());
        }
        [HttpGet]
        public IActionResult SortByTimeOld()
        {
            return Ok(_repository.SortByReviewTimeOldest());
        }
    }
}
