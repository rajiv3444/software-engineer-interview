using System.ComponentModel.DataAnnotations;

namespace Zip.EmiCalc.Api.Models
{
    public class PaymentOrderRequest
    {
        [Required]
        public decimal OrderAmount { get; set; }
        [Required]
        public int InstallmentCount { get; set; }
        [Required]
        public int FrequencyOfDaysCount { get; set; }
    }
}
