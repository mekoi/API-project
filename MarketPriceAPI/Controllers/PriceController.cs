using AutoMapper;
using MarketPriceAPI.DTOs;
using MarketPriceAPI.Services;
using MarketPriceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private IMarketPriceRepository _marketPriceRepository;
        private readonly IMapper _mapper;

        public PriceController(IMarketPriceRepository marketPriceRepository, IMapper mapper)
        {
            _marketPriceRepository = marketPriceRepository;
            _mapper = mapper;
        }

        //GET ALL: api/<controller>
        [HttpGet]
        [Route("/api/allPricesOfInstruments.{format}"),FormatFilter]
        public async Task<ActionResult<Instrument>> GetAllPricesOfInstruments()
        {
            var allPricesOfInstruments = await _marketPriceRepository.GetAllPricesOfInstruments();
            var results = _mapper.Map<IEnumerable<MarketPriceDto>>(allPricesOfInstruments);
            return Ok(results);
        }

        //GET BY ID: api/<controller>
        [HttpGet("{instrumentId}")] 
        public async Task<ActionResult<Instrument>> GetAllPricesByInstrumentId(int instrumentId)
        {
            var allPricesOfInstrument = await _marketPriceRepository.GetAllPricesByInstrumentId(instrumentId);

            if (allPricesOfInstrument == null)
            {
                return NotFound();  
            }

            var results = _mapper.Map<IEnumerable<InstrumentPricesDto>>(allPricesOfInstrument);
            return Ok(results);
        }

        //POST: api/<controller>
        //[HttpPost("{instrumentId}/marketprice")]
        [HttpPost]
        public async Task<ActionResult<Instrument>> CreatePrice(int instrumentId, [FromBody] MarketPriceForCreationDto marketPriceForCreationDto)
        {
            if (marketPriceForCreationDto == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var finalMarketPrice = _mapper.Map<MarketPrice>(marketPriceForCreationDto);
            await _marketPriceRepository.AddPrice(instrumentId, finalMarketPrice);

            return Ok();
        }

        //PUT: api/<controller>
        [HttpPut("{priceId}")]
        public async Task<IActionResult> UpdatePrice(int priceId, [FromBody] MarketPriceForUpdateDto marketPriceForUpdateDto)
        {
            if (marketPriceForUpdateDto == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _marketPriceRepository.PriceExist(priceId)) 
            {
                return NotFound();
            }

            var existingMarketPrice = await _marketPriceRepository.GetSpecificPrice(priceId);

            if (existingMarketPrice == null) 
            {
                return NotFound();
            }
            
            _mapper.Map(marketPriceForUpdateDto, existingMarketPrice);
            await _marketPriceRepository.Save();
            return NoContent();
        }

        // DELETE: api/price/5
        [HttpDelete("{priceId}")]
        public async Task<ActionResult<MarketPrice>> DeletePrice(int priceId)
        {
            var priceToDelete = await _marketPriceRepository.GetSpecificPrice(priceId);   
            if (priceToDelete == null)
            {
                return NotFound();
            }

            await _marketPriceRepository.DeletePrice(priceId);

            return priceToDelete;
        }

    }
}
