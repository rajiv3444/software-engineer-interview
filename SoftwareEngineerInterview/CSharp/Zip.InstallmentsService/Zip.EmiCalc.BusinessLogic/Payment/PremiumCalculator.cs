﻿using Microsoft.Extensions.Logging;

namespace Zip.EmiCalc.BusinessLogic.Payment
{
    public class PremiumCalculator : IPremiumCalculator
    {
        private readonly ILogger _logger;
        private readonly string _bal = "BAL: ";
        public PremiumCalculator(ILogger logger)
        {
            this._logger = logger;
        }
        /// <summary>
        /// This method will calculate installment instalment charges with its payment dates based on privided input data like number of installment, frequency
        /// </summary>
        /// <param name="totalAmount">this is total amont for which order is placed</param>
        /// <param name="numberOfInstallment">number of installment specified </param>
        /// <param name="frequencyDays">frequency in terms of number of days specified for installmet</param>
        /// <returns></returns>
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
                _logger.LogError($"{_bal} Error occured while calculating the charge with payment dates");
                throw;
            }

            return chargesWithDates;
        }

        /// <summary>
        /// This method gets the per unit charges for one installment based on the number of installment the user have speviied
        /// </summary>
        /// <param name="totalAmount">this is he total amount of order placed</param>
        /// <param name="numberOfInstallment">number of installment specified </param>
        /// <returns></returns>
        public decimal CalculatePremiumAmount(decimal totalAmount, int numberOfInstallment)
        {
            try
            {
                return totalAmount / numberOfInstallment;
            }
            catch (Exception)
            {
                _logger.LogError($"{_bal} Error occured while calculating the premium amount");
                throw;
            }
        }
    }
}