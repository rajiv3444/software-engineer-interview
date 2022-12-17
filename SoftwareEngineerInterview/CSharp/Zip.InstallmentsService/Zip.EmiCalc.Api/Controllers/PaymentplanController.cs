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
            // inject dependences
            this._premiumCalculator = premiumCalculator;
        }


        // GET: api/<Paymentplan>
        [HttpGet]
        [Route("paymentPlan-withCharges")]
        public IActionResult PaymentPlanWithCharges(PaymentOrderRequest paymentOrderRequest)
        {
            if (paymentOrderRequest is null)
            {
                throw new ArgumentNullException(nameof(paymentOrderRequest));
            }

            // model validation
            if (!ModelState.IsValid)
            {
                var paymentChargesResult = this._premiumCalculator.CalculateChargesWithDates(paymentOrderRequest.OrderAmount, paymentOrderRequest.InstallmentCount, paymentOrderRequest.FrequencyOfDaysCount);
                PremiumPaymentPlan premiumPlanResponse = new PremiumPaymentPlan()
                {
                    PremiumDatesWithCharges = paymentChargesResult
                };
                return Ok(premiumPlanResponse);
            }

            return BadRequest("Invalid input Data");
        }

        /*
        // GET: api/<Paymentplan>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orderAmount = 100;
            var installmentCount = 4;
            // validation
            if (orderAmount <= 0)
            {
                return BadRequest();
            }
            var res = this._premiumCalculator.CalculatePremiumAmount(orderAmount, installmentCount);

            return Ok(res);
        }
        */


    }
}
