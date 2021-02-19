using System;
using System.Collections.Generic;

namespace MarketPriceLibrary.Models
{
    public partial class AssetClass
    {
        public AssetClass()
        {
            Instrument = new HashSet<Instrument>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public virtual ICollection<Instrument> Instrument { get; set; }
    }
}
