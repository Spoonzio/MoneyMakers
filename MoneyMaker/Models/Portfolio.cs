using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMaker.Models
{
    public class Portfolio
    {
        [Key]
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [Required]
        [ForeignKey("CurrencySym")]
        public string? EntryCurrencySym { get; set; }

        [Required]
        public int Value { get; set; }
    }
}