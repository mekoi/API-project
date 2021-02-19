using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPriceAPI.DTOs;
using MarketPriceLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketPriceAPI.Services
{
    public interface IMarketPriceRepository
    {
        Task<IEnumerable<Instrument>> GetAllInstruments();

        Task<IEnumerable<MarketPrice>> GetAllPricesOfInstruments();

        Task<IEnumerable<MarketPrice>> GetAllPricesByInstrumentId(int instrumentId);

        Task<MarketPrice> GetSpecificPrice(int priceId);

        Task AddPrice(int instrumentId, MarketPrice marketPrice);

        //void DeletePrice(int priceId);
        Task<ActionResult<MarketPrice>> DeletePrice(int priceId);

        Task<bool> PriceExist(int priceId);

        Task Save ();
    }
}
