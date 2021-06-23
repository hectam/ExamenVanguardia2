using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Models
{
	public class RatePlanDto
	{
        public long RatePlanId { get; set; }
        public string RatePlanName { get; set; }
        public int RatePlanType { get; set; }
        public double Price { get; set; }

        public IEnumerable<SeasonDto> Seasons { get; set; }
        public IEnumerable<RoomDto> Rooms { get; set; }
    }
}
