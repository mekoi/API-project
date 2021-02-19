using System;
using System.Collections.Generic;
using System.Text;

namespace MarketDataAPIClient
{
    public class MarketPrice
    {
        public int PriceId { get; set; }
        public int InstrumentId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            string format;
            format = $"Price Id: {PriceId} - Instrument Id: {InstrumentId} - Date: {Date} - Price: {Price}";
            return format;
        }
    }
}
