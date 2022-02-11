using System.ComponentModel.DataAnnotations;

namespace MoneyMaker.Models
{
    public class Currency
    {
        [Key]
        [Required]
        public string CurrencySym { get; set; }

        [Required]
        public string CurrencyFullName { get; set; }

    }
}