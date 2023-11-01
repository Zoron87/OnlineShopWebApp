using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShopWebApp.Models
{
    public class ShopUser
    {
        public Guid Id = Guid.NewGuid();

        [Required(ErrorMessage = "Email пользователя обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный email пользователя")]
        [RegularExpression("^[a-zA-Z0-9._-]+@[а-яА-Яa-zA-Z0-9._-]+\\.[а-яА-Яa-zA-Z0-9_-]+$", ErrorMessage = "Укажите корректный электронный адрес пользователя")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Role { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пароль пользователя обязателен")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Password { get; set; }
    }
}
