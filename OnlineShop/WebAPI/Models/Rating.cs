using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    /// <summary>
    /// Рейтинг
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Id рейтинга
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id продукта
        /// </summary>
        [Required(ErrorMessage = "Не указан продукт")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        public double Grade { get; set; }

        public Rating()
        {
            CreateDate = DateTime.Now;
        }
    }
}
