using System.ComponentModel.DataAnnotations;

namespace MoneyMaker.ViewModels
{
    public class CreateAlertViewModel
    {
        public CreateAlertViewModel(string fromCurrency, string toCurrency)
        {
            this.FromCurrency = fromCurrency;
            this.ToCurrency = toCurrency;
        }

        [Required]
        public string? FromCurrency { get; set; }

        [Required]
        public string? ToCurrency { get; set; }
    }
}
