using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.EmiCalc.DataAccessRepository.EFModels;

namespace Zip.EmiCalc.DataAccessRepository.Repositories
{
    internal class Repository : IRepository
    {
        private readonly ILogger _logger;
        public readonly zipCoContext _zipCoContext;
        public Repository(zipCoContext zipCoContext, ILogger logger)
        {
            this._zipCoContext = zipCoContext;
            this._logger = logger;
        }

        public PaymentPlan GetOrderById(string orderId)
        {
            try
            {
                return _zipCoContext.PaymentPlan.Where(o => o.OrderRefId.Equals(orderId)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while Geting Order details", ex);
                throw;
            }
        }

        public void Save()
        {
            this._zipCoContext.SaveChanges();
        }
    }
}
