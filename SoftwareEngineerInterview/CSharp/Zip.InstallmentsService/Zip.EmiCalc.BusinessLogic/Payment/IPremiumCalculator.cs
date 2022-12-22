using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.EmiCalc.BusinessLogic.Payment
{
    public interface IPremiumCalculator
    {
        public decimal CalculatePremiumAmount(decimal totalAmount, int numberOfInstallment);
        public Dictionary<DateTime, decimal> CalculateChargesWithDates(decimal totalAmount, int numberOfInstallment, int frequencyDays);

        public void SavePaymentPlan(decimal totalAmount, int numberOfInstallment, int frequencyDays);
        
    }
}
