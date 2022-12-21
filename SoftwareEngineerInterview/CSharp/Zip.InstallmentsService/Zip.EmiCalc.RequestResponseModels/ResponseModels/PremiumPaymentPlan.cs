using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.EmiCalc.RequestResponseModels.ResponseModels
{
    public class PremiumPaymentPlan
    {
        //public int PlanId { get; set; } = 1;
        //public string PlanName { get; set; }
        //public DateOnly StartDate { get; set; }
        //public DateOnly EndDate { get; set; } = new DateOnly();

        public Dictionary<DateTime, decimal> PremiumDatesWithCharges { get; set; } = new Dictionary<DateTime, decimal>();
    }
}
