using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zip.EmiCalc.DataAccessRepository.EFModels
{
    public partial class Orderr
    {
        public string OrderId { get; set; }
        public decimal OrderAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
