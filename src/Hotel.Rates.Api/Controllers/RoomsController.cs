using Hotel.Rates.Core.Enum;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomServices;

        public RoomsController(IRoomService roomServices)
        {
            this._roomServices = roomServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var verify = _roomServices.Get();
            if (verify.ResponseCode == ResponseCode.Success)
                return Ok(verify.Result);

            return BadRequest(verify.Error);
        }
    }
}
