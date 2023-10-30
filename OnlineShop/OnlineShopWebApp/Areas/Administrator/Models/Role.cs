using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Administrator.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Имя роли указывать обязательно")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Название роли должно содержать от {2} до {1} символов")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
