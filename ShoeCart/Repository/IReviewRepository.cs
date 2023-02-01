using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetAllReviews();
        public Review GetReview(int id);
        public Review Add(Review review);
        public bool Update(Review review);
        public bool Remove(int id);
        public IEnumerable<Review> ReviewsByShoeId(int id);
        public IEnumerable<Review> SortByRatingCritical();
        public IEnumerable<Review> SortByRatingPositive();
        public IEnumerable<Review> SortByReviewTimeNewest();
        public IEnumerable<Review> SortByReviewTimeOldest();
    }
}
