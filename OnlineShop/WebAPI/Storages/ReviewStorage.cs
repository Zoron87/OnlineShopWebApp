using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Storages
{
    public class ReviewStorage : IReviewStorage
    {
        private readonly ReviewDatabaseContext _databaseContext;
        
        public ReviewStorage(ReviewDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<List<ReviewDB>> GetAllAsync()
        {
            return await _databaseContext.Reviews.ToListAsync();
        }

        public async Task<List<ReviewDB>> GetAllByProductIdAsync(Guid productId)
        {
            return await _databaseContext.Reviews.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<bool> TryToDeleteByIdAsync(Guid productId)
        {
            var review = await _databaseContext.Reviews.FirstOrDefaultAsync(x => x.Id == productId);
            if (review != null)
            {
                _databaseContext.Reviews.Remove(review);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ReviewDB> AddAsync(ReviewDB review)
        {
            var reviews = await GetAllByProductIdAsync(review.ProductId);
            var reviewsAverage = reviews.Select(x => x.Grade).Average();
            var rating = new Rating() { ProductId = review.ProductId, Grade = Math.Round(reviewsAverage, 2) };
            review.Rating = rating;
            await _databaseContext.Reviews.AddAsync(review);
            await _databaseContext.SaveChangesAsync();
            return review;
        }
    }
}
