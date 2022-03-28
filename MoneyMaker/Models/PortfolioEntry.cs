using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMaker.Models
{
    public class PortfolioEntry
    {
        [Key]
        [ForeignKey("UserId")]
        public string? UserId { get; set; }

        [Required]
        [ForeignKey("CurrencySym")]
        public string? EntryCurrencySym { get; set; }

        [Required]
        public float EntryValue { get; set; }
    }
}