using System;
using System.Collections.Generic;

namespace MarketPriceLibrary.Models
{
    public partial class Instrument
    {
        public Instrument()
        {
            MarketPrice = new HashSet<MarketPrice>();
        }

        public int InstrumentId { get; set; }
        public int ClassId { get; set; }
        public string InstrumentName { get; set; }

        public virtual AssetClass Class { get; set; }
        public virtual ICollection<MarketPrice> MarketPrice { get; set; }
    }
}
