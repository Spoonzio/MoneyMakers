using System.ComponentModel.DataAnnotations;

namespace MoneyMaker.ViewModels
{
    public class ConvertViewModel
    {
        [Required]
        [Display(Name = "From Currency")]
        public string? FromCurrency { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float FromValue { get; set; }

        [DataType(DataType.Currency)]
        public float ToValue { get; set; }

        [Required]
        [Display(Name = "To Currency")]
        public string? ToCurrency { get; set; }

        public Dictionary<string, float>? ChartData { get; set; }
    }
}
