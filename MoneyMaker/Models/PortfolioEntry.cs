using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMaker.Models
{
    public class PortfolioEntry
    {
        [Key]
        [ForeignKey("UserId")]
        public string? UserId { get; set; }

        [Key]
        [Required]
        [ForeignKey("CurrencySym")]
        public string? EntryCurrencySym { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public float EntryValue { get; set; }
    }
}