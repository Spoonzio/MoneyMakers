using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMaker.Models
{

    public class Alert
    {
        [Key]
        [ForeignKey("UserId")]
        public string? UserId { get; set; }

        [Key]
        [ForeignKey("CurrencySym")]
        public string? FromCurrency { get; set; }

        [Key]
        [ForeignKey("CurrencySym")]
        public string? ToCurrency { get; set; }

        [Required]
        public string? AlertName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [Required]
        public bool isBelow { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float ConditionValue { get; set; }


    }
}