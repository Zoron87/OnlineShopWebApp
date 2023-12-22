using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class Mapping
    {
        public static ReviewDB ToReviewDB(this ReviewViewModel reviewViewModel)
        {
            var review = new ReviewDB();
            review.UserId = reviewViewModel.UserId;
            review.ProductId = reviewViewModel.ProductId;
            review.Text = reviewViewModel.Text;
            review.Grade = reviewViewModel.Grade;

            return review;
        }
    }
}
