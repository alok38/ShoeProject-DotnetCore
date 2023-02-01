using ShoeCart.DataAccessLayer;
using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ShoeStoreContext _Shoecontext;
        public ReviewRepository(ShoeStoreContext context)
        {
            _Shoecontext = context;
        }

        public Review Add(Review review)
        {
            _Shoecontext.Reviews.Add(review);
            _Shoecontext.SaveChanges();
            return review;
        }
        public IEnumerable<Review> GetAllReviews()
        {
            return _Shoecontext.Reviews.ToList();
        }
        public Review GetReview(int id)
        {
            return _Shoecontext.Reviews.FirstOrDefault(x => x.ReviewId == id);
        }
        public bool Remove(int id)

        {
            var ReviewToRemove = GetReview(id);
            _Shoecontext.Reviews.Remove(ReviewToRemove);
            _Shoecontext.SaveChanges();
            return true;
        }
        public bool Update(Review review)
        {
            var ReviewToUpdate = GetReview(review.ReviewId);
            ReviewToUpdate.Feedback = review.Feedback;
            ReviewToUpdate.CustomerName = review.CustomerName;
            ReviewToUpdate.Rating = review.Rating;
            _Shoecontext.SaveChanges();
            return true;
        }
        public IEnumerable<Review> ReviewsByShoeId(int id)
        {
            var ReviewList = (from review in _Shoecontext.Reviews
                            where review.ShoeId == id
                            select review).ToList();
            return ReviewList;
        }
        public IEnumerable<Review>SortByRatingCritical()
        {
            var ReviewList = (from review in _Shoecontext.Reviews
                            orderby review.Rating 
                            select review).ToList();
            return ReviewList;
        }
        public IEnumerable<Review> SortByRatingPositive()
        {
            var ReviewList = (from review in _Shoecontext.Reviews
                            orderby review.Rating descending
                            select review).ToList();
            return ReviewList;
        }
        public IEnumerable<Review> SortByReviewTimeNewest()
        {
            var ReviewList = (from review in _Shoecontext.Reviews
                            orderby review.ReviewTime descending
                            select review).ToList();
            return ReviewList;
        }
        public IEnumerable<Review> SortByReviewTimeOldest()
        {
            var ReviewList = (from review in _Shoecontext.Reviews
                              orderby review.ReviewTime 
                              select review).ToList();
            return ReviewList;
        }
    }
}
