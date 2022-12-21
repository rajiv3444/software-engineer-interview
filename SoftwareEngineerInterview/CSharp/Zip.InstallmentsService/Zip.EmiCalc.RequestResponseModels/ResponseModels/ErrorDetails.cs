using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zip.EmiCalc.RequestResponseModels.ResponseModels
{
    public class ErrorDetails
    {
        public string? Type { get; set; }
        public string? Title { get; set; }
        public int? StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
