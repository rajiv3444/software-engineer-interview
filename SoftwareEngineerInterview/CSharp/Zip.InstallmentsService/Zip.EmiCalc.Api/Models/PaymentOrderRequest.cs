using System.ComponentModel.DataAnnotations;

namespace Zip.EmiCalc.Api.Models
{
    public class PaymentOrderRequest
    {
        // Fluent validation is used for model validation
        public decimal OrderAmount { get; set; }
        public int InstallmentCount { get; set; }
        public int FrequencyOfDaysCount { get; set; }
    }
}
