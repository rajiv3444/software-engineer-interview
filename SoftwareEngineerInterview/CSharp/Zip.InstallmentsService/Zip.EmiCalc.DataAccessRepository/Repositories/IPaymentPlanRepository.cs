using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.EmiCalc.DataAccessRepository.EFModels;

namespace Zip.EmiCalc.DataAccessRepository.Repositories
{
    public interface IPaymentPlanRepository
    {
        public PaymentPlan RetrivePaymentPlan(int orderId);
        public void PersistPaymentPlan(decimal totalAmount, int numberOfInstallment, int frequencyDays);
    }
}
