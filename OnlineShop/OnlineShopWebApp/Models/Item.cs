using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Item
    {
        public int Id { get; }

        [Required(ErrorMessage = "Не указано наименование продукта")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Длина строки имени должна быть от {2} до {1} символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана стоимость продукта")]
        [Range(1.0, 9999999.99, ErrorMessage = "Введите стоимость в диапазоне от {1} до {2}")]
        [RegularExpression("^[0-9]{1,7}([\\.][0-9]{1,2})?$", ErrorMessage = "Некорректное значение стоимости товара")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание продукта")]
        [StringLength(999, MinimumLength = 10, ErrorMessage = "Описание продукта должно составлять от {2} до {1} символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "НЕ указано изображение продукта")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Изображение продукта должно составлять от {2} до {1} символов")]
        public string ImagePath { get; set; }
    }
}