using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrderDetailsViewModel
    {
        public int Id { get; }

        [Required(ErrorMessage = "Не указано имя получателя товара")]
        [RegularExpression("^[a-zA-Zа-яА-ЯёЁ\\s]+$", ErrorMessage = "В имени получателя допустимо использовать только буквы")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки имени должна быть от {2} до {1} символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан телефон получателя")]
        [Phone(ErrorMessage = "Указан некорректный телефон получателя")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина строки телефона должна быть от {2} до {1} символов")]
        [RegularExpression("((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}", ErrorMessage = "Указан некорректный телефон получателя")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указана электронная почта получателя")]
        [EmailAddress(ErrorMessage = "Указан некорректный электронный адрес получателя")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Длина строки телефона должна быть от {2} до {1} символов")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан адрес получателя товара")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Длина строки адреса должна быть от {2} до {1} символов")]
        public string Address { get; set; }

        public DeliveryTypeViewModel? Delivery { get; set; }

        [Required(ErrorMessage = "Не указана предпочтительная дата доставки")]        
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "Не выбран способ оплаты")]
        public PayTypeViewModel? Pay { get; set; }

        [StringLength(255, MinimumLength = 0, ErrorMessage = "Длина строки адреса должна быть от {2} до {1} символов")]
        public string Comment { get; set; }

        public List<CartItemViewModel> Items { get; set; }

        public OrderDetailsViewModel()
        {
            DeliveryDate = DateTime.Now;
            Pay = PayTypeViewModel.Нет;
            Delivery = DeliveryTypeViewModel.Нет;
            Comment = string.Empty;
            Items = new List<CartItemViewModel>();
        }

        public decimal Cost()
        {
            return Items.Sum(el => el.Product.Cost * el.Quantity);
        }
    }
}
