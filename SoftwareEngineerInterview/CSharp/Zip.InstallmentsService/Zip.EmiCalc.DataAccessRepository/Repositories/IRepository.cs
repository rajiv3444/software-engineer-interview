﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.EmiCalc.DataAccessRepository.EFModels;

namespace Zip.EmiCalc.DataAccessRepository.Repositories
{
    internal interface IRepository
    {
        PaymentPlan GetOrderById(string orderId);
        void Save();

    }
}
