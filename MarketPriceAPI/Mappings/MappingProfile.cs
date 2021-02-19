using AutoMapper;
using MarketPriceAPI.DTOs;
using MarketPriceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPriceAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Instrument, InstrumentDto>();
            CreateMap<MarketPrice, MarketPriceDto>();
            CreateMap<MarketPrice, InstrumentPricesDto>();
            CreateMap<MarketPriceForCreationDto, MarketPrice>();
            CreateMap<MarketPriceForUpdateDto, MarketPrice>();    
        }
    }
}
