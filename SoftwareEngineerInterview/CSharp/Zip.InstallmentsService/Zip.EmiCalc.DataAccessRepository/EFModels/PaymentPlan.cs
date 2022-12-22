using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zip.EmiCalc.DataAccessRepository.EFModels
{
    public partial class PaymentPlan
    {
        public int PlanId { get; set; }
        public string? OrderRefId { get; set; }
        public decimal PerInstalmentCharge { get; set; }
        public int InstalmentCount { get; set; }
        public int FrequencyInDays { get; set; }
    }
}
