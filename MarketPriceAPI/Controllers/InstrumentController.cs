using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MarketPriceAPI.DTOs;
using MarketPriceAPI.Services;
using MarketPriceLibrary.Models;

namespace MarketPriceAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InstrumentController : ControllerBase
    {
        private IMarketPriceRepository _marketPriceRepository;
        private readonly IMapper _mapper;

        public InstrumentController(IMarketPriceRepository marketPriceRepository, IMapper mapper)
        {
            _marketPriceRepository = marketPriceRepository;
            _mapper = mapper;
        }

        //GET: api/<controller>
        [HttpGet]
        [Route("/api/allInstruments")]
        public async Task<ActionResult<Instrument>> GetAllInstruments()
        {
            var allInstruments = await _marketPriceRepository.GetAllInstruments();
            var results = _mapper.Map<IEnumerable<InstrumentDto>>(allInstruments);
            return Ok(results);
        }
    }
}