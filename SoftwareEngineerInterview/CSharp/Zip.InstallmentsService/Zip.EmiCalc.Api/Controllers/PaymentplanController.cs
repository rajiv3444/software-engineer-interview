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

        // GET: api/<Paymentplan>
        [HttpGet]
        [Route("paymentPlan-withCharges")]
        public async Task<IActionResult>PaymentPlan()
        {
            var orderAmount = 100;
            var installmentCount = 4;
            var frequency = 14;
            // validation
            if (orderAmount <=0 || installmentCount <= 0 || frequency <= 0)
            {
                return BadRequest("Invalid input data");
            }

            var paymentChargesResult = this._premiumCalculator.CalculateChargesWithDates(orderAmount, installmentCount, frequency);
            //PremiumPaymentPlan premiumPlanResponse = new PremiumPaymentPlan()
            //{
            //    PremiumDatesWithCharges = paymentChargesResult
            //};

            return Ok(paymentChargesResult);
        }

    }
}
