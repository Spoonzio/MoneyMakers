using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoneyMaker.ViewModels
{
    public class ConvertViewModel
    {
        [Required]
        [Display(Name = "From Currency")]
        public string? FromCurrency { get; set; }

        [Required]
        [Display(Name = "Alert Currency")]
        public string? AlertCurrency { get; set; }
    
        [Required]
        [DataType(DataType.Currency)]
        public float FromValue { get; set; }

        [DataType(DataType.Currency)]
        public float ToValue { get; set; }
        [DataType(DataType.Currency)]
        public float AlertValue { get; set; }

        [Required]
        [Display(Name = "To Currency")]
        public string? ToCurrency { get; set; }

        public Dictionary<string, float>? ChartData { get; set; }
    }
}
