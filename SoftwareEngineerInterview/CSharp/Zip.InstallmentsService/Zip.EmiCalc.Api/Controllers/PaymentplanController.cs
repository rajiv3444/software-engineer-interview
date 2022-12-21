using Microsoft.AspNetCore.Mvc;
//using Zip.EmiCalc.Api.Models;
using Zip.EmiCalc.BusinessLogic.Payment;
using Zip.EmiCalc.RequestResponseModels.ResponseModels;


namespace Zip.EmiCalc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentplanController : ControllerBase
    {
        private readonly IPremiumCalculator _premiumCalculator;
        private readonly ILogger _logger;

        public PaymentplanController(IPremiumCalculator premiumCalculator, ILogger logger)
        {
            this._premiumCalculator = premiumCalculator;
            this._logger = logger;
        }


        /// <summary>
        /// This API will respond you with payment plan (dates and charges) based on your choosen installment count and the frequency
        /// </summary>
        /// <param name="paymentOrderRequest">Properties like 'Order Amount', 'installment Amount','Frequency in Days' </param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">There must be valid data provided to consume this API</exception>
        [HttpGet]
        [Route("payment-plan")]
        public IActionResult PaymentPlanWithCharges(decimal orderAmount, int installmentCount, int frequencyOfDaysCount)
        {
            try
            {
                // model validation - using Fluent validation
                if (ModelState.IsValid && isDataValid(orderAmount, installmentCount, frequencyOfDaysCount))
                {
                    var paymentChargesResult = this._premiumCalculator.CalculateChargesWithDates(orderAmount, installmentCount, frequencyOfDaysCount);
                    PremiumPaymentPlan premiumPlanResponse = new()
                    {
                        PremiumDatesWithCharges = paymentChargesResult
                    };
                    return Ok(premiumPlanResponse);
                }
            }
            catch (Exception ex)
            {

                this._logger.LogError("Error occured while calculating payment plan. Exception: ", ex);
            }
            
            
            return BadRequest();
        }

        private bool isDataValid(decimal orderAmount, int installmentCount, int frequencyOfDaysCount)
        {
            return orderAmount > 0 && installmentCount > 0 && frequencyOfDaysCount > 0;
        }
    }
}
