using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMaker.Models
{
    
    public class Alert
    {
        [Key]
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Key]
        [ForeignKey("CurrencySym")]
        public string FromCurrency { get; set; }

        [Key]
        [ForeignKey("CurrencySym")]
        public string ToCurrency { get; set; }

        [Required]
        public string AlertName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }


    }
}