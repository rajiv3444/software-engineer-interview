using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.EmiCalc.RequestResponseModels.RequestModels
{
    public class PaymentOrderRequest
    {
        // Fluent validation is used for model validation
        public decimal OrderAmount { get; set; }
        public int InstallmentCount { get; set; }
        public int FrequencyOfDaysCount { get; set; }
    }
}
