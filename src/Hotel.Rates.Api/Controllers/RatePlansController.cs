﻿using Hotel.Rates;
using Hotel.Rates.Core.Enum;
using Hotel.Rates.Core.Interfaces;
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
    public class RatePlansController : ControllerBase
    {
        private readonly IRatePlanService ratePlanService;

        public RatePlansController(IRatePlanService ratePlanService)
        {
            this.ratePlanService = ratePlanService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = ratePlanService.GetAll();
            if (result.ResponseCode == ResponseCode.Success)
                return Ok(result.Result);


            return BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = ratePlanService.Get(id);
            if (result.ResponseCode == ResponseCode.Success)
                return Ok(result.Result);

            return BadRequest(result.Error);
        }
    }
}
