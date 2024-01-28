using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class ReviewViewModel
    {
        /// <summary>
        /// Id продукта
        /// </summary>
        [Required(ErrorMessage = "Не указан продукт")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Id пользователя, оставившего отзыв
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Текст отзыва
        /// </summary>
        [Required(ErrorMessage = "Не указан текст отзыва")]
        public string? Text { get; set; }

        /// <summary>
        /// Оценка (количество звезд)
        /// </summary>
        [Range(0, 5, ErrorMessage = "Оценка может быть от 0 до 5 баллов")]
        public int Grade { get; set; }
    }
}
