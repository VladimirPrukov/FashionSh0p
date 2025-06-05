using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FashionWave.Models
{
    public class OrderCreateViewModel
    {
        [Required(ErrorMessage = "Полето 'Име и фамилия' е задължително")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Полето 'Адрес' е задължително")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Полето 'Телефон' е задължително")]
        [Phone(ErrorMessage = "Невалиден телефонен номер")]
        public string Phone { get; set; }

        public double Total { get; set; }

        public List<CartItem> CartItems { get; set; } = new();
    }
}
