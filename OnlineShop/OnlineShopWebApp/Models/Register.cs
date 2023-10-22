using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage="Не указана электронная почта пользователя")]
        public string Email { get; set; }
        [Required(ErrorMessage="Не указан пароль пользователя")]
        public string Password { get; set; }
        [Required(ErrorMessage="Не указан повторный пароль пользователя")]
        public string ConfirmPassword { get; set; }
        public string IsRememberMe { get; set; }
    }
}
