namespace Zip.EmiCalc.BusinessLogic.Payment
{
    public class PremiumCalculator : IPremiumCalculator
    {
        
        public Dictionary<DateTime, decimal> CalculateChargesWithDates(decimal totalAmount, int numberOfInstallment, int frequencyDays)
        {
            var chargesWithDates = new Dictionary<DateTime, decimal>();
            try
            {
                // As per Usersotry A.C.: the 1st date of installment charges will begin with order placement date.
                // hence, take order placement date as of today when API is hit, and charges are calculated.
                // To Do/Enhancement: we can go with this date with taking as input for API
                var orderPlecementDate = new DateTime();
                var chargePerInstallment = CalculatePremiumAmount(totalAmount, numberOfInstallment);

                // compose the charges dates with amount
                for (int i = 0; i < numberOfInstallment; i++)
                {
                    chargesWithDates.Add(orderPlecementDate, chargePerInstallment);
                    orderPlecementDate = orderPlecementDate.AddDays(frequencyDays);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return chargesWithDates;
        }

        public decimal CalculatePremiumAmount(decimal totalAmount, int numberOfInstallment)
        {
            try
            {
                return totalAmount / numberOfInstallment;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}