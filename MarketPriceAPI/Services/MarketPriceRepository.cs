using MarketPriceAPI.DTOs;
using MarketPriceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPriceAPI.Services
{
    public class MarketPriceRepository : IMarketPriceRepository
    {
        private MarketDataDBContext _context;

        public MarketPriceRepository(MarketDataDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instrument>> GetAllInstruments()
        {
            var result = _context.Instrument.OrderBy(i => i.InstrumentId);
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<MarketPrice>> GetAllPricesOfInstruments()
        {
            var result = _context.MarketPrice.OrderBy(p => p.PriceId);
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<MarketPrice>> GetAllPricesByInstrumentId(int instrumentId)
        {
            var result = _context.MarketPrice.Where(p => p.InstrumentId == instrumentId).OrderBy(p => p.Date);
            return await result.ToListAsync();
        }

        public async Task AddPrice(int instrumentId, MarketPrice marketPrice)
        {
            var existingInstrumentId = _context.Instrument.Where(i => i.InstrumentId == instrumentId);
            if (existingInstrumentId != null)
            {
                _context.MarketPrice.Add(marketPrice);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MarketPrice> GetSpecificPrice(int priceId) 
        {
            var existingPrice = _context.MarketPrice.Where(p => p.PriceId == priceId);
            return await existingPrice.FirstOrDefaultAsync();
        }

        public async Task<ActionResult<MarketPrice>> DeletePrice(int priceId)
        {
            var marketPriceToDelete = await _context.MarketPrice.FindAsync(priceId);
            _context.MarketPrice.Remove(marketPriceToDelete);
            await _context.SaveChangesAsync();
            return marketPriceToDelete;
        }

        public async Task<bool> PriceExist(int priceId)
        {
            return await _context.MarketPrice.AnyAsync<MarketPrice>(p => p.PriceId == priceId);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();           
        }
    }
}
