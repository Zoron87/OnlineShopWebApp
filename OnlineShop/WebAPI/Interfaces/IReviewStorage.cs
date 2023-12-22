using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IReviewStorage
    {
        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <returns></returns>
        Task<List<ReviewDB>> GetAllAsync();

        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        Task<List<ReviewDB>> GetAllByProductIdAsync(Guid productId);

        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="productId">Id отзыва</param>
        /// <returns></returns>
        Task<bool> TryToDeleteByIdAsync(Guid productId);

        /// <summary>
        /// Добавление отзыва
        /// </summary>
        /// <param name="review">Отзыв</param>
        /// <returns></returns>
        Task<ReviewDB> AddAsync(ReviewDB review);
    }
}
