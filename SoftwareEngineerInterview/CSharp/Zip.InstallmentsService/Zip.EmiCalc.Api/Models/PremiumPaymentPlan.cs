namespace Zip.EmiCalc.Api.Models
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
