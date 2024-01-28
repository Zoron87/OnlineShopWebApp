using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указана электронная почта пользователя")]
        [EmailAddress(ErrorMessage = "Укажите корректный электронный адрес пользователя")]
        [RegularExpression("^[a-zA-Z0-9._-]+@[а-яА-Яa-zA-Z0-9._-]+\\.[а-яА-Яa-zA-Z0-9_-]+$", ErrorMessage = "Укажите корректный электронный адрес пользователя")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Длина строки email должна быть от {2} до {1} символов")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль пользователя")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина строки пароля должна быть от {2} до {1} символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль пользователя")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина строки подтверждающего пароля должна быть от {2} до {1} символов")]
        [Compare("Password", ErrorMessage = "Введенные пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public bool IsRememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
