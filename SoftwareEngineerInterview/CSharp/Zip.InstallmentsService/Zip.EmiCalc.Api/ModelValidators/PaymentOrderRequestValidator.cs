using FluentValidation;
//using Zip.EmiCalc.Api.Models;
using Zip.EmiCalc.RequestResponseModels.RequestModels;

namespace Zip.EmiCalc.Api.ModelValidators
{
    public class PaymentOrderRequestValidator: AbstractValidator<PaymentOrderRequest>
    {
        public PaymentOrderRequestValidator()
        {
            RuleFor(x => x.OrderAmount).NotNull().NotEmpty().InclusiveBetween(1,int.MaxValue);
            RuleFor(x => x.InstallmentCount).InclusiveBetween(1, int.MaxValue);
            RuleFor(x => x.FrequencyOfDaysCount).InclusiveBetween(1, int.MaxValue);
        }
    }
}
