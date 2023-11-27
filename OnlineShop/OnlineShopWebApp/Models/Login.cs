using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указана электронная почта пользователя")]
        [EmailAddress(ErrorMessage = "Укажите корректный электронный адрес пользователя")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Длина строки email должна быть от {2} до {1} символов")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль пользователя")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина строки пароля должна быть от {2} до {1} символов")]
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
