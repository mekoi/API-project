﻿using MarketPriceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPriceAPI.DTOs
{
    public class InstrumentPricesDto
    {
        public int PriceId { get; set; }
        public int InstrumentId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
