﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class OrderMiddle
    {
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

        public DeliveryType? Delivery { get; set; }

        [Required(ErrorMessage = "Не указана предпочтительная дата доставки")]        
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "Не выбран способ оплаты")]
        public PayType? Pay { get; set; }

        [StringLength(255, MinimumLength = 0, ErrorMessage = "Длина строки адреса должна быть от {2} до {1} символов")]
        public string Comment { get; set; }

        public Cart Cart { get; set; }

        public OrderMiddle()
        {
            DeliveryDate = DateTime.Now;
            Pay = null;
            Delivery = null;
        }
    }
}