using System.ComponentModel.DataAnnotations;

namespace OnlineShop.DB.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Создан")]
        Created,
        [Display(Name = "Оплачен")]
        Paid,
        [Display(Name = "В обработке")]
        Processed,
        [Display(Name = "В пути")]
        Delivering,
        [Display(Name = "Доставлен")]
        Delivered,
        [Display(Name = "Отменен")]
        Canceled
    }
}
