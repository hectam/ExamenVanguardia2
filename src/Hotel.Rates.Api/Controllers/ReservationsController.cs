
using Hotel.Rates.Core.Enum;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService<double> reservationService;

        public ReservationsController(IReservationService<double> reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpPost("Night")]
        
        public IActionResult PostNightPlan([FromBody]ReservationModelDto reservationModel)
        {
            var checkNightPlan = reservationService.NightlyPlan(reservationModel);
            if (checkNightPlan.ResponseCode == ResponseCode.Success)
                return Ok(checkNightPlan.Result);

            return BadRequest(checkNightPlan.Error);

        }

        [HttpPost("Interval")]

        public IActionResult PostIntervalPlan([FromBody] ReservationModelDto reservationModel)
        {
            var checkIntervalPlan = reservationService.IntervalPlan(reservationModel);
            if (checkIntervalPlan.ResponseCode == ResponseCode.Success)
                return Ok(checkIntervalPlan.Result);

            return BadRequest(checkIntervalPlan.Error);

        }
    }
}
