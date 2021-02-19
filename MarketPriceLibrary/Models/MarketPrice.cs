using System;
using System.Collections.Generic;

namespace MarketPriceLibrary.Models
{
    public partial class MarketPrice
    {
        public int PriceId { get; set; }
        public int? InstrumentId { get; set; }
        public DateTime? Date { get; set; }
        public double? Price { get; set; }

        public virtual Instrument Instrument { get; set; }
    }
}
