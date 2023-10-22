using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage="Не указана электронная почта пользователя")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указано пароль пользователя")]
        public string Password { get; set; }
        public string IsRememberMe { get; set; }
    }
}
