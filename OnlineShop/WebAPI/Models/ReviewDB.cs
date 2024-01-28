namespace WebAPI.Models
{
    public class ReviewDB
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public string? Text { get; set; }

        public int Grade { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid RatingId { get; set; }

        public Rating? Rating { get; set; }

        public Status Status { get; set; }

        public ReviewDB()
        {
            CreateDate = DateTime.Now;
        }
    }
}
