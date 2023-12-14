using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProfileViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Email пользователя обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный email пользователя")]
        [RegularExpression("^[a-zA-Z0-9._-]+@[а-яА-Яa-zA-Z0-9._-]+\\.[а-яА-Яa-zA-Z0-9_-]+$", ErrorMessage = "Укажите корректный электронный адрес пользователя")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Допустимое количество символов от {2} до {1}")]
        public string Name { get; set; }

        [Phone(ErrorMessage = "Указан некорректный телефон получателя")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина строки телефона должна быть от {2} до {1} символов")]
        [RegularExpression("((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}", ErrorMessage = "Указан некорректный телефон получателя")]
        public string Phone { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Длина строки email должна быть от {2} до {1} символов")]
        public string Address { get; set; }
        public string AvatarImagepath { get; set; }
        public IFormFile UploadedFile {get; set;}
    }
}
