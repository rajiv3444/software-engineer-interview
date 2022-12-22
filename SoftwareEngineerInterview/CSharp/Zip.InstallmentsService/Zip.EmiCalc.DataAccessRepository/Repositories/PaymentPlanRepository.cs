using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.EmiCalc.DataAccessRepository.EFModels;

namespace Zip.EmiCalc.DataAccessRepository.Repositories
{
    public class PaymentPlanRepository : IPaymentPlanRepository
    {
        private readonly ILogger _logger;
        public readonly zipCoContext _zipCoContext;
        public PaymentPlanRepository(zipCoContext zipCoContext, ILogger logger)
        {
            _zipCoContext = zipCoContext;
            _logger = logger;
        }
        
        public void PersistPaymentPlan(decimal totalAmount, int numberOfInstallment, int frequencyDays)
        {
            using (var transaction = _zipCoContext.Database.BeginTransaction())
            {

                try
                {
                    var order = new Orderr()
                    {
                        OrderAmount = totalAmount,
                        OrderDate = DateTime.Now,
                        OrderId = Guid.NewGuid().ToString()
                    };

                    this._zipCoContext.Add(order);
                    this._zipCoContext.SaveChanges();

                    var paymentPlan = new PaymentPlan()
                    {
                        OrderRefId = order.OrderId,
                        FrequencyInDays = frequencyDays,
                        InstalmentCount = numberOfInstallment,
                        PerInstalmentCharge = totalAmount,
                    };

                    this._zipCoContext.Add(paymentPlan);
                    this._zipCoContext.SaveChanges();

                    // complete the transaction with COMMIT
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError("Error occured while saving payment plan. DB TRANSACTION HAS BEEN ROLLED BACK", ex);
                    throw;
                }
            }
        }

        public PaymentPlan RetrivePaymentPlan(int orderId)
        {
            try
            {
                return this._zipCoContext.PaymentPlan.Where(p => p.OrderRefId.Equals(orderId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while retriving payment plan", ex);
                throw;
            }
        }
    }
}
