using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPriceAPI.DTOs
{
    public class InstrumentDto
    {
        public int InstrumentId { get; set; }
        public int ClassId { get; set; }
        public string InstrumentName { get; set; }
    }
}
