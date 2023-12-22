using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Email пользователя обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный email пользователя")]
        [RegularExpression("^[a-zA-Z0-9._-]+@[а-яА-Яa-zA-Z0-9._-]+\\.[а-яА-Яa-zA-Z0-9_-]+$", ErrorMessage = "Укажите корректный электронный адрес пользователя")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Пароль пользователя обязателен")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Password { get; set; }
    }
}
