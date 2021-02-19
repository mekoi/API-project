using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPriceAPI.DTOs
{
    public class MarketPriceForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a valid Price Id.")]
        public int PriceId { get; set; }

        [Required(ErrorMessage = "You should provide a valid Instrument Id.")]
        public int InstrumentId { get; set; }

        [Required(ErrorMessage = "You should provide a valid Date.")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date in the format dd/mm/yyyy hh:mm")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You should provide a valid Price.")]
        public double Price { get; set; }

    }
}
