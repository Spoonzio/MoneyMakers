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
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public float ConditionValue { get; set; }


    }
}