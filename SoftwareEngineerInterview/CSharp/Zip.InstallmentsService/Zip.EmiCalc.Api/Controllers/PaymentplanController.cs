using Microsoft.AspNetCore.Mvc;
using Zip.EmiCalc.Api.Models;
using Zip.EmiCalc.BusinessLogic.Payment;


namespace Zip.EmiCalc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentplanController : ControllerBase
    {
        private readonly IPremiumCalculator _premiumCalculator;
        public PaymentplanController(IPremiumCalculator premiumCalculator)
        {
            this._premiumCalculator = premiumCalculator;
        }


        /// <summary>
        /// This API will respond you with payment plan (dates and charges) based on your choosen installment count and the frequency
        /// </summary>
        /// <param name="paymentOrderRequest">Properties like 'Order Amount', 'installment Amount','Frequency in Days' </param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">There must be valid data provided to consume this API</exception>
        [HttpGet]
        [Route("payment-plan")]
        public IActionResult PaymentPlanWithCharges([FromBody] PaymentOrderRequest paymentOrderRequest)
        {
            // model validation - using Fluent validation
            if (paymentOrderRequest is not null && !ModelState.IsValid)
            {
                var paymentChargesResult = this._premiumCalculator.CalculateChargesWithDates(paymentOrderRequest.OrderAmount, paymentOrderRequest.InstallmentCount, paymentOrderRequest.FrequencyOfDaysCount);
                PremiumPaymentPlan premiumPlanResponse = new()
                {
                    PremiumDatesWithCharges = paymentChargesResult
                };
                return Ok(premiumPlanResponse);
            }
            
            return BadRequest();
        }
    }
}
